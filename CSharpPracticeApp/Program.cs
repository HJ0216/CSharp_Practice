using CSharpPracticeApp.Classes;
using CSharpPracticeApp.Interfaces;
using Microsoft.VisualBasic;

namespace CSharpPracticeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = new double[] { 1, 2, 3, 45, 67890 };
            Console.WriteLine(SimpleMath.Add(numbers));
            Console.WriteLine(SimpleMath.Add(10,20));


            BankAccount bankAccount = new BankAccount(1000);
            Console.WriteLine(bankAccount.AddToBalance(3000));

            ChildBankAccount childBankAccount = new ChildBankAccount();
            Console.WriteLine(childBankAccount.AddToBalance(3000));


            SimpleMath simpleMath = new SimpleMath();
            Console.WriteLine(Information(childBankAccount));

        }

        private static string Information(IInformation information)
        {
            return information.GetInformation();
        }

        class SimpleMath : IInformation
        {
            public static double Add(double d1, double d2)
            {
                return d1 + d2;
            }

            public static double Add(double[] numbers)
            {
                double result = 0;
                foreach(double d in numbers)
                {
                    result += d;
                }

                return result;
            }

            public string GetInformation()
            {
                return "Class that solves simple math.";
            }
        }
    }
}
