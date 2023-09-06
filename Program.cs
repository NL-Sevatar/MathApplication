using System;
using System.Collections;
using System.Xml.XPath;

namespace Consoleappone
{
    class Program
    {  
        public static void Main()
        {

            double result = 0;

            Console.Write("Welcome to the Math Center, What is your name? ");
            string name = Console.ReadLine()!;
                
            Console.WriteLine("Please select the tool you require " + name);
            Console.WriteLine("1. Calc for Calculator");
            Console.WriteLine("2. Temp for Tempurture converter.");
                
            string getTool = Console.ReadLine()!;

                switch (getTool)
                    {
                    case "1":
                        result = Getcalc();
                        break;
                    }
            Console.WriteLine($"Result: {result}");
        
        }

        static double Getcalc()
        {
          
                Console.Write("Please enter your first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Please enter your second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please enter your operator: ");
                char op =  Convert.ToChar(Console.ReadLine()!);

                switch (op)
                {
                    case '+':
                        return num1 + num2;
                    case '-': 
                        return num1 - num2;
                    case '/': 
                        if (num2 != 0) {
                        return num1 / num2;
                        }
                        else{
                          throw new DivideByZeroException("Divison by zero");
                        }
                    case '*': 
                        return num1 * num2;
                    case '%': 
                        return num1 % num2;
                    default:
                        Console.WriteLine("Invalid Operator. Please enter a mathmatical operator.");
                        throw new InvalidOperationException("Invalid Operator");
                }
        }
    }
}     