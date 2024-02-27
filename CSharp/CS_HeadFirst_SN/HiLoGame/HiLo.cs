using System.Reflection;

namespace HiLoGame
{
    internal class HiLo
    {
        static void Main(string[] args)
        {
            // private field의 한계
            HasASecret keeper = new HasASecret();
            //Console.WriteLine(keeper.secret);

            FieldInfo[] fields = keeper.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach(FieldInfo field in fields)
            {
                Console.WriteLine(field.GetValue(keeper));
            }

            // random이 public일 경우, 의사난수 문제
            HiLoGame.random = new Random(1);
            Random seededRandom = new Random(1);
            Console.WriteLine("The first 20 is ");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{seededRandom.Next(1, HiLoGame.MAXIMUM + 1)}, ");
            }

            Console.WriteLine("Welcome to HiLo");
            Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}");
            HiLoGame.Hint();
            while(HiLoGame.GetPot() > 0)
            {
                Console.WriteLine("Press h for higer, l for lower, ? to buy a hint");
                Console.WriteLine($"or any other key to quit with {HiLoGame.GetPot()}");
                char key = Console.ReadKey(true).KeyChar;

                if (key == 'h') { HiLoGame.Guess(true); }
                else if (key == 'l') { HiLoGame.Guess(false); }
                else if(key == '?') { HiLoGame.Hint(); }
                else { return;  }
            }
            Console.WriteLine("The Pot is empty. Bye!");

        }
    }

    internal class HasASecret
    {
        private string secret = "asd";
    }
}
