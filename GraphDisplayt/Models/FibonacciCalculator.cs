using MathNet.Numerics.LinearAlgebra;

namespace GraphDisplayt
{
    internal static class FibonacciCalculator
    {


        public static ulong GetFibonacciLinearValue(int Itteration)
        {
            ulong result = 0;
            ulong left = 0;
            ulong right = 1;

            for (int i = 0; i < Itteration; i++)
            {
                result = left + right;
                left = right;
                right = result;
            }

            return result;
        }

        public static ulong GetFibonacciRecursiveValue(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return GetFibonacciRecursiveValue(n-1) + GetFibonacciRecursiveValue(n-2);
        }

        public static ulong GetFibonacciMatrixValue(int Itteration)
        {
            var matrix = Matrix<double>.Build;

            var @base = matrix.DenseOfArray(new double[,]
            {
                { 1, 1 },
                { 1, 0 }
            });

            var current = matrix.DenseOfArray(new double[,]
            {
                { 1, 1 },
                { 1, 0 }
            });

            for (int i = 1; i < Itteration; i++)
            {
                current = current.Multiply(@base);
            }

            return (ulong)current.Storage.At(0, 0);
        }
    }
}
