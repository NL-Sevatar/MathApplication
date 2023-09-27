using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.XPath;
using currencyapi;
using Microsoft.VisualBasic;


namespace MathApplication
{
    class Program
    {  
        public static void Main()
        {
            bool contuineCalculation = true;
            bool firstTime = true;
            double result =0;
            string tempResult;
           
                Console.WriteLine("Welcome to the Math Center");
                
                Console.WriteLine("Please select the tool you require ");
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
                         case "2":
                            tempResult = GetTemp();
                            Console.WriteLine($"The temp conversion is {tempResult}");
                            Console.WriteLine("**************************");
                            Main();
                            break;
                        
                         case "3":
                            GetCurrency();
                            Main();
                            break; 
                        case "4":
                            Console.WriteLine("Thank you for visting.");
                            break;    
                        default:
                            Console.WriteLine("Invalid option, please try using the numbers.");
                            Main();
                            break; 
                        }
        }

        public static double Getcalc(double num1)
        {
            Console.WriteLine($"Result: {num1}");

            Console.WriteLine("Please enter your operator or q to quit: ");
            char op =  Convert.ToChar(Console.ReadLine()!);
            if (op == 'q'){ // Does not exit the loop still asking the the second #
                Main();
            }
                
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
        static string GetTemp()
     {
            Console.WriteLine("Which conversion will you be making?");
            Console.WriteLine("1. Celsius to Fahrenheit");
            Console.WriteLine("2. Fahrenheit to Celsius");
            Console.WriteLine("3. Celsius to Kelvin");
            Console.WriteLine("4. Fahrenheit to Kelvin");
            Console.WriteLine("5. Kelvin to Celsius");
            Console.WriteLine("6. Kelvin to Fahrenheit");

            double converter = Convert.ToDouble(Console.ReadLine());

            Console.Write("Now please enter your base temperature: ");
            double baseTemp = Convert.ToDouble(Console.ReadLine());
            double outTemp = 0;
            string tempType = " ";


            switch (converter)
            {
                case 1:
                    outTemp =(baseTemp * 9/5) + 32; 
                    tempType = "Fahrenheit";
                    break;

                case 2:
                    outTemp = (baseTemp - 32) * 5 / 9;
                    tempType = "Celsius";
                    break;

                case 3:
                    outTemp = baseTemp + 273.15;
                    tempType = "Kelvin";
                    break;

                case 4:
                    outTemp = (baseTemp - 32) * 5/9 + 273.15;
                     tempType = "Kelvin";
                    break;

                case 5:
                    outTemp = baseTemp - 273.15;
                    tempType = "Celsius";
                    break;

                case 6:
                    outTemp = (baseTemp - 273.15) * 9 / 5 + 32;
                    tempType = "Fahrenheit";
                    break;                                        
            }

        return $"{outTemp} {tempType}";

    } 

    public class Meta
    {

    }
     public class UpdateDateTime
    {
        public DateTimeOffset last_updated_at {get;set;}
    }
    public class SelectedCurrency
    {
        public string? Currency {get;set;}
        public string? Code {get;set;}
        public double Value {get;set;}
    }

    static void GetCurrency()
    {
        var fx = new Currencyapi("cur_live_95Lo7FrezklMKNzkPlOY4Gwc8ISMO6FFnPnXpksr");

        Console.WriteLine("Please enter your base currency 3 letter code.");
        string baseInput = Console.ReadLine()!;  
        string baseCurrency = baseInput.ToUpper();

        Console.WriteLine("Please enter the amount in the selected currency.");
        double currencyAmount = Convert.ToDouble(Console.ReadLine()!);

        Console.WriteLine("What are we currency 3 letter code are we converting too?");
        string conversionInput = Console.ReadLine()!;
        string targetCurrency = conversionInput.ToUpper(); 

        string jsonResponse = fx.Latest(baseCurrency, targetCurrency)!;

        SelectedCurrency? selectedCurrency = JsonSerializer.Deserialize<SelectedCurrency>(jsonResponse);

        Console.WriteLine(jsonResponse);

        if (selectedCurrency != null)
        {
            Console.WriteLine($"Currency Code: {selectedCurrency.Code}");
            Console.WriteLine($"Currency Value: {selectedCurrency.Value}");

            double conversionResult = currencyAmount * selectedCurrency.Value;
            Console.WriteLine($"Converted Result: {conversionResult} {selectedCurrency.Code}");
        }
        else
        {
            Console.WriteLine("Failed to deserialize JSON data.");
        }
    } 
    }    
  }