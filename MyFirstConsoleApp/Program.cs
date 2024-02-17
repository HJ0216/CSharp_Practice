

namespace MyFirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int p = 2;
            for(int q=2; q<32; q = q * 2)
            {
                while (p < q)
                {
                    p = p * 2;
                }

                q = p - q;
            }

            OperatorExample();
            TryAnIf();
            TrySomeLoops();
            TryAnIfElse();

            Class3 class3 = new Class3();
            class3.mainMethod();

        }

        private static void TryAnIfElse()
        {
            int x = 5;
            if(x == 10)
            {
                Console.WriteLine("x must be 10");
            }
            else
            {
                Console.WriteLine("x isn't 10");
            }
        }

        private static void TrySomeLoops()
        {
            int count = 0;
            while (count < 10)
            {
                count = count + 1;
            }
            for (int i = 0; i < 5; i++)
            {
                count = count - 1;
            }
            Console.WriteLine("The answer is " + count);
        }

        private static void TryAnIf()
        {
            int someValue = 4;
            string name = "Bobbo Jr.";
            if ((someValue == 3) && (name == "Joe"))
            {
                Console.WriteLine("x is 3 and the name is Joe");
            }
            Console.WriteLine("this line runs no matter what");
        }

        private static void OperatorExample()
        {
            int width = 3;
            width++;

            int height = 2 + 4;
            int area = width * height;

            Console.WriteLine("area: " + area);

            while (area<50)
            {
                height++;
                area = width * height;
            }
            do
            {
                width--;
                area = width * height;
            } while (area>25);

            string result = "The area";
            result = result + " is " + area;

            Console.WriteLine(result);

            bool truthValue = true;
            Console.WriteLine(truthValue);
        }
    }
}
