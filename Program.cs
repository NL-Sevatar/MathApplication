using System;
using System.Collections;
using System.Xml.XPath;

namespace Consoleappone
{
    class Program
    {  
        public static void Main()
        {
            bool going = true;
            double result = 0;
            do{        
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
                        case "2":
                            result = Gettemp();
                            break;
                        }
                Console.WriteLine($"Result: {result}");

                Console.WriteLine("Do you wish to contuine? Y/N");
            

            } while(going);

        static double Getcalc()
        {
            bool firstTime = true;

            if(firstTime)

               { Console.Write("Please enter your first number: ");
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
        static double Gettemp()
    {
        double result;

        Console.WriteLine("Which conversion will you be making?");
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.WriteLine("3. Celsius to Kelvin");
        Console.WriteLine("4. Fahrenheit to Kelvin");
        Console.WriteLine("5. Kelvin to Celsius");
        Console.WriteLine("6. Kelvin to Fahrenheit");

        double converter = Convert.ToDouble(Console.ReadLine());

        Console.Write("Now please enter your base tempature: ");
        double baseTemp = Convert.ToDouble(Console.ReadLine());


        switch (converter)
        {
            case 1:
                (baseTemp * 9/5) + 32; 
                break;

            case 2:
                (baseTemp - 32) * 5 / 9;
                break;

            case 3:

                break;

            case 4:

                break;

            case 5:

                break;

            case 6:

                break;                                        
        }

    }


} 
}    