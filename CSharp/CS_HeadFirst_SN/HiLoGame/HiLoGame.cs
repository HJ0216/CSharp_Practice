using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGame
{
    static class HiLoGame
    {
        public const int MAXIMUM = 10;

        public static Random random = new Random();
        private static int currentNumber = random.Next(1, MAXIMUM + 1);

        private static int pot = 10;
        public static int GetPot()
        {
            return pot;
        }

        public static void Guess(bool isHigher)
        {
            int nextNumber = random.Next(1, MAXIMUM + 1);

            if((isHigher && nextNumber > currentNumber) || (!isHigher && nextNumber <= currentNumber)) 
            {
                Console.WriteLine("Right");
                pot++;
            }
            else
            {
                Console.WriteLine("Wrong");
                pot--;
            }
            currentNumber = nextNumber;
            Console.WriteLine("The current number is " + currentNumber);

        }

        public static void Hint()
        {
            int half = MAXIMUM / 2;
            if(currentNumber >= half)
            {
                Console.WriteLine($"Current Number: {currentNumber}, Next Number is at least {half}");
            }
            else
            {
                Console.WriteLine($"Current Number: {currentNumber}, Next Number is at most {half}");
            }
            pot--;
        }

    }
}
