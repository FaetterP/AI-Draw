using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Draw
{
    class MLP
    {
        private double etha = 0.1;
        private Random rnd = new Random();
        private double[][,] wmatrs;
        private double[][] training_inputs;
        private double[][] training_outputs;
        private double[][] layers;
        private double[][] errs;

        public MLP(int[] lengths, double[][] training_inputs, double[][] training_outputs)
        {
            this.training_inputs = training_inputs;
            this.training_outputs = training_outputs;

            layers = new double[lengths.Length][];
            for (int i = 0; i < lengths.Length; i++)
            {
                if (i < lengths.Length - 1)
                {
                    layers[i] = new double[lengths[i] + 1];
                    layers[i][lengths[i]] = 1;
                }
                else
                {
                    layers[i] = new double[lengths[i]];
                }
            }

            wmatrs = new double[lengths.Length - 1][,];
            for (int i = 0; i < lengths.Length - 1; i++)
            {
                wmatrs[i] = new double[lengths[i] + 1, lengths[i + 1]];
            }

            errs = new double[layers.Length - 1][];
            for (int i = 0; i < errs.Length; i++)
            {
                errs[i] = new double[lengths[i + 1]];
            }
            //errs[errs.Length - 1] = new double[lengths.Last()];
        }

        public void Train(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int index = rnd.Next(training_inputs.Length);
                double[] toTrain = training_inputs[index];
                Array.Copy(toTrain, layers[0], toTrain.Length);

                for (int j = 0; j < layers.Length - 2; j++)
                {
                    mult(layers[j], wmatrs[j], layers[j + 1], false);
                }
                mult(layers[layers.Length - 2], wmatrs[layers.Length - 2], layers[layers.Length - 1], true);


                for (int j = 0; j < errs[errs.Length - 1].Length; j++)
                {
                    errs[errs.Length - 1][j] = training_outputs[index][j] - layers.Last()[j];
                }

                FindErr();
                //PrintErrs();
                //PrintLayers();
                //PrintW();
                FixErr();
                //Console.WriteLine("=============================================");
            }

        }

        private void mult(double[] N1, double[,] W12, double[] N2, bool IsLast)
        {
            int val = N2.Length;
            if (!IsLast) { val--; }
            for (int i = 0; i < val; i++)
            {
                N2[i] = 0;
                for (int j = 0; j < N1.Length; j++)
                {
                    N2[i] += N1[j] * W12[j, i];
                }
                N2[i] = sigm(N2[i]);
            }
        }

        private void FindErr()
        {
            for (int i = errs.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < errs[i].Length; j++)
                {
                    errs[i][j] = 0;
                    for (int k = 0; k < errs[i + 1].Length; k++)
                    {
                        //if (i < errs.Length - 2 && k == errs[i + 1].Length - 1) { break; }
                        errs[i][j] += errs[i + 1][k] * wmatrs[i + 1][j, k];
                    }
                }
            }
        }

        private void FixErr()
        {
            for (int i = 0; i < wmatrs.Length; i++)
            {
                for (int j = 0; j < wmatrs[i].GetLength(0); j++)
                {
                    for (int k = 0; k < wmatrs[i].GetLength(1); k++)
                    {
                        wmatrs[i][j, k] += etha * errs[i][k] * sigmgr(desigm(layers[i + 1][k])) * layers[i][j];
                    }
                }
            }
        }

        private double sigm(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        private double sigmgr(double x)
        {
            x = sigm(x);
            return x * (1 - x);
        }

        private double desigm(double x)
        {
            return -Math.Log((1 / x) - 1);
        }

        public double[] Predict(double[] input)
        {
            Array.Copy(input, layers[0], input.Length);

            for (int j = 0; j < layers.Length - 2; j++)
            {
                mult(layers[j], wmatrs[j], layers[j + 1], false);
            }
            mult(layers[layers.Length - 2], wmatrs[layers.Length - 2], layers[layers.Length - 1], true);

            return layers.Last();
            //PrintLayers();
            //PrintW();
        }


        /*
         * ----------------------------------------
        */

        public void PrintLayers()
        {
            Console.WriteLine("----Layers----");
            foreach (var t in layers)
            {
                foreach (var tt in t)
                {
                    Console.Write(tt + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------");
        }

        public void PrintErrs()
        {
            Console.WriteLine("----Errs----");
            foreach (var t in errs)
            {
                foreach (var tt in t)
                {
                    Console.Write(tt + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------");
        }

        public void PrintW()
        {
            int counter = 0;
            foreach (var t in wmatrs)
            {
                Console.WriteLine("----W" + counter + "----");
                for (int j = 0; j < t.GetLength(0); j++)
                {
                    for (int k = 0; k < t.GetLength(1); k++)
                    {
                        Console.Write(t[j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-----------------");
                counter++;
            }
        }
    }
}
