using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AI_Draw.Perceptron
{
    class TrainableMLP : MLP
    {
        private double etha = 0.1;
        private double[][] _errors;

        public Func<double, double> ActivationFunctionDerivative;
        public Func<double, double> ActivationFunctionInverse;

        public TrainableMLP(int[] lengths) : base(lengths)
        {
            _errors = new double[_layers.Length - 1][];
            for (int i = 0; i < _errors.Length; i++)
            {
                _errors[i] = new double[lengths[i + 1]];
            }

            ActivationFunctionDerivative = (x) => SigmoidDerivative(x);
            ActivationFunctionInverse = (x) => SigmoidInverse(x);
        }

        private void СalculateErrors()
        {
            for (int i = _errors.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < _errors[i].Length; j++)
                {
                    _errors[i][j] = 0;
                    for (int k = 0; k < _errors[i + 1].Length; k++)
                    {
                        _errors[i][j] += _errors[i + 1][k] * _wMatrices[i + 1][j, k];
                    }
                }
            }
        }

        private void FixErrors()
        {
            for (int i = 0; i < _wMatrices.Length; i++)
            {
                for (int j = 0; j < _wMatrices[i].GetLength(0); j++)
                {
                    for (int k = 0; k < _wMatrices[i].GetLength(1); k++)
                    {
                        _wMatrices[i][j, k] += etha * _errors[i][k] * ActivationFunctionDerivative(ActivationFunctionInverse(_layers[i + 1][k])) * _layers[i][j];
                    }
                }
            }
        }

        public void Train(double[][] inputs, double[][] outputs, int count, ProgressBar progressBar)
        {
            CheckArguments(inputs, outputs);
            if (count < 0)
                throw new ArgumentException("Задано отрицателное количество этапов обучения.");

            for (int i = 0; i < count; i++)
            {
                progressBar.Value = (int)Math.Ceiling(100.0 * i / count);

                int index = rnd.Next(inputs.Length);
                TrainStep(inputs[index], outputs[index]);
            }

        }

        private void TrainStep(double[] input, double[] output)
        {
            Predict(input);

            for (int j = 0; j < _errors[_errors.Length - 1].Length; j++)
            {
                _errors[_errors.Length - 1][j] = output[j] - _layers.Last()[j];
            }

            СalculateErrors();
            FixErrors();
        }


        private double SigmoidDerivative(double x)
        {
            x = Sigmoid(x);
            return x * (1 - x);
        }

        private double SigmoidInverse(double x)
        {
            return -Math.Log((1 / x) - 1);
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double GetMeanSquaredError(double[][] inputs, double[][] outputs)
        {
            CheckArguments(inputs, outputs);

            List<double> errs = new List<double>();

            for (int i = 0; i < inputs.Length; i++)
            {
                double added = 0;
                double[] result = Predict(inputs[i]);
                for (int j = 0; j < result.Length; j++)
                {
                    added += Math.Pow(result[j] - outputs[i][j], 2);
                }
                errs.Add(Math.Sqrt(added / result.Length));
            }

            return errs.Sum() / errs.Count;
        }

        private void CheckArguments(double[][] inputs, double[][] outputs)
        {
            if (inputs.Length != outputs.Length)
                throw new ArgumentException("Количество записей в input не совпадает с количеством записей в output.");

            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i].Length != _wMatrices[0].GetLength(0) - 1)
                    throw new ArgumentException($"Некорректный input в строке {i}. Длина не совпадает с длиной входа.");

                if (outputs[i].Length != _wMatrices.Last().GetLength(1))
                    throw new ArgumentException($"Некорректный output в строке {i}. Длина не совпадает с длиной выхода.");
            }
        }
    }
}
