using System;

public class Calculator
{
    // Приватный метод для сложения двух чисел
    private int Add(int a, int b)
    {
        return a + b;
    }

    // Публичный метод для вычисления факториала числа
    public long Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        // Ввод чисел для сложения
        Console.WriteLine("Введите первое число:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите второе число:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        // Результат сложения чисел (метод Add приватный, поэтому вызов его производится внутри Main)
        var addMethod = typeof(Calculator).GetMethod("Add", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        int sum = (int)addMethod.Invoke(calculator, new object[] { num1, num2 });
        Console.WriteLine("Результат сложения: " + sum);

        // Ввод числа для вычисления факториала
        Console.WriteLine("Введите число для вычисления факториала:");
        int number = Convert.ToInt32(Console.ReadLine());

        // Результат вычисления факториала
        long factorialResult = calculator.Factorial(number);
        Console.WriteLine("Факториал " + number + ": " + factorialResult);
    }
}


