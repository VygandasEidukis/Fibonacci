using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

while (true)
{
    Console.Clear();
    Console.Write("Level: ");
    var selection = Console.ReadLine();

    if (int.TryParse(selection, out var selectVal))
    {
        Console.WriteLine($"Result loop: {GetFibonacciLoopValue(selectVal)}");
        Console.WriteLine($"Result recursive: {GetFibonacciRecursiveValue(0, 1, 1, selectVal)}");
        Console.WriteLine($"Result matrix: {GetFibonacciMatrixValue(selectVal)}");
    }

    Console.WriteLine("Press any button to continue...");
    Console.ReadKey();
}

