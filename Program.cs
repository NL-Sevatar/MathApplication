namespace MathApplication
{
    class Program
    {  
        public static void Main()
        {
            bool contuineCalculation = true;
            bool firstTime = true;
            double result = 0;
           
                Console.Write("Welcome to the Math Center, What is your name? ");
                string name = Console.ReadLine()!;
                
                Console.WriteLine("Please select the tool you require " + name);
                Console.WriteLine("1. Calculator");
                Console.WriteLine("2. Tempurture Converter.");
                Console.WriteLine("3. Currency Converter");
                Console.WriteLine("4. Exit");
                
                string getTool = Console.ReadLine()!;

                    switch (getTool)
                        {   
                        case "1":
                            do {
                                if (firstTime)
                                {
                                    result = Getcalcfirsttime();
                                    firstTime = false;
                                }
                                else if (!firstTime)
                                {
                                    result = Getcalc(result);
                                }
                                else {
                                    Console.WriteLine("Error Detected. Please try again.");
                                    }
                            }
                            while(contuineCalculation);
                            break;
                     /* case "2":
                            result = Gettemp();
                            break;
                        } */
                        case "3":

                            break;
                        case "4":
                            Console.WriteLine($"Goodbye {name}.");
                            break;    
                        default:
                            Console.WriteLine("Invalid option, please try using the numbers.");
                            break; 
                        }

                Console.WriteLine($"Result: {result}");
                Main();
        }

        public static double Getcalc(double num1)
        {
            Console.WriteLine($"Using previous result {num1}.");

            Console.WriteLine("Please enter your operator or q to quit: ");
            char op =  Convert.ToChar(Console.ReadLine()!);

            Console.Write("Please enter your second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
         
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '/':
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        throw new DivideByZeroException("Division by zero");
                    }
                case '*':
                    return num1 * num2;
                case '%':
                    return num1 % num2;
               /* case 'q':
                    Console.WriteLine("Exiting Calculator"); Need to build a exit out to main menu that changes contuineCalculation to false.
                    return contuineCalculation = false; */
                default:
                    Console.WriteLine("Invalid Operator. Please enter a mathematical operator.");
                    throw new InvalidOperationException("Invalid Operator");
            }
        }       

       static double Getcalcfirsttime()
        {
            
            Console.Write("Please enter your first number: ");
             double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter your operator: ");
             char op =  Convert.ToChar(Console.ReadLine()!);

            Console.Write("Please enter your second number: ");
             double num2 = Convert.ToDouble(Console.ReadLine());

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
