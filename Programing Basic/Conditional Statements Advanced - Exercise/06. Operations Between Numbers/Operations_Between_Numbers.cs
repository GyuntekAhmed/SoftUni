using System;


class Operations_Between_Numbers
{
    static void Main()
    {
        int numOne = int.Parse(Console.ReadLine());
        int numTwo = int.Parse(Console.ReadLine());
        char operation = char.Parse(Console.ReadLine());
        double results = 0;
        string finalResult = null;

        switch (operation)
        {
            case '+':
                results = numOne + numTwo;
                if (results % 2 == 0)
                {
                    finalResult = $"{numOne} {operation} {numTwo} = {results} - even";
                }
                else
                {
                    finalResult = $"{numOne} {operation} {numTwo} = {results} - odd";
                }
                break;
            case '-':
                results = numOne - numTwo;
                if (results % 2 == 0)
                {
                    finalResult = $"{numOne} {operation} {numTwo} = {results} - even";
                }
                else
                {
                    finalResult = $"{numOne} {operation} {numTwo} = {results} - odd";
                }
                break;
            case '*':
                results = numOne * numTwo;
                if (results % 2 == 0)
                {
                    finalResult = $"{numOne} {operation} {numTwo} = {results} - even";
                }
                else
                {
                    finalResult = $"{numOne} {operation} {numTwo} = {results} - odd";
                }
                break;
            case '/':
                if (numTwo == 0)
                {
                    finalResult = $"Cannot divide {numOne} by zero";
                }
                else
                {
                    results = numOne / (double)numTwo;
                    finalResult = $"{numOne} {operation} {numTwo} = {results:f2}";
                }
                break;
            case '%':
                if (numTwo == 0)
                {
                    finalResult = $"Cannot divide {numOne} by zero";
                }
                else
                {
                    results = numOne % numTwo;
                    finalResult = $"{numOne} {operation} {numTwo} = {results}";
                }
                break;

        }
        Console.WriteLine(finalResult);
    }
}
