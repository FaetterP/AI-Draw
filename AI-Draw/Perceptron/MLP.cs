using System;
using System.Linq;

namespace AI_Draw.Perceptron
{
    class MLP
    {
        protected Random rnd = new Random();
        protected double[][,] _wMatrices;
        protected double[][] _layers;

        public Func<double, double> ActivationFunction;

        public MLP(int[] lengths)
        {
            _layers = new double[lengths.Length][];
            for (int i = 0; i < lengths.Length; i++)
            {
                if (i < lengths.Length - 1)
                {
                    _layers[i] = new double[lengths[i] + 1];
                    _layers[i][lengths[i]] = 1;
                }
                else
                {
                    _layers[i] = new double[lengths[i]];
                }
            }

            _wMatrices = new double[lengths.Length - 1][,];
            for (int i = 0; i < lengths.Length - 1; i++)
            {
                _wMatrices[i] = new double[lengths[i] + 1, lengths[i + 1]];
            }
            RandomW();

            ActivationFunction = (x) => Sigmoid(x);
        }

        protected double[] Multiply(double[] inputLayer, double[,] W)
        {
            double[] ret = new double[W.GetLength(1)];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = 0;
                for (int j = 0; j < inputLayer.Length; j++)
                {
                    ret[i] += inputLayer[j] * W[j, i];
                }
                ret[i] = ActivationFunction(ret[i]);
            }

            return ret;
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public void RandomW()
        {
            for (int i = 0; i < _wMatrices.Length; i++)
            {
                for (int j = 0; j < _wMatrices[i].GetLength(0); j++)
                {
                    for (int k = 0; k < _wMatrices[i].GetLength(1); k++)
                    {
                        _wMatrices[i][j, k] = rnd.NextDouble() * 2 - 1;
                    }
                }
            }
        }

        public double[] Predict(double[] input)
        {
            if (input.Length != _layers[0].Length - 1)
                throw new InvalidOperationException("Размер массива не совпадает с размером входа в персептрон.");

            _layers[0] = AddBias(input);

            for (int j = 0; j < _layers.Length - 2; j++)
            {
                _layers[j + 1] = Multiply(_layers[j], _wMatrices[j]);
                _layers[j + 1] = AddBias(_layers[j + 1]);
            }
            _layers[_layers.Length - 1] = Multiply(_layers[_layers.Length - 2], _wMatrices[_layers.Length - 2]);

            return _layers.Last();
        }

        protected double[] AddBias(double[] layer)
        {
            return layer.Concat(new double[] { 1 }).ToArray();
        }
    }
}
