namespace SharpenYourPencil
{
    internal class Elephant
    {
        int EarSize;
        string Name;

        static void Main(string[] args)
        {
            Elephant lucinda = new Elephant()
            {
                Name = "Lucinda",
                EarSize = 33,
            };
            Elephant lloyd = new Elephant()
            {
                Name = "Lloyd",
                EarSize = 40,
            };

            Console.WriteLine("Press 1 for Lucinda, 2 for Lloyd, 3 to swap");
            while (true)
            {
                char number = Console.ReadKey(true).KeyChar;
                Console.WriteLine("You pressed " + number);

                if (number == '1')
                {
                    Console.WriteLine("Calling lucinda.WhoAmI()");
                    lucinda.WhoAmI();
                }
                else if (number == '2')
                {
                    Console.WriteLine("Calling lloyd.WhoAmI()");
                    lloyd.WhoAmI();
                }
                else if (number == '3')
                {
                    Elephant tempElephant;
                    tempElephant = lucinda;
                    lucinda = lloyd;
                    lloyd = tempElephant;

                    Console.WriteLine("References have been swapped");
                }
                else if(number == '4')
                {
                    lloyd = lucinda;
                    lloyd.EarSize = 4321;
                    lloyd.WhoAmI();
                }
                else if(number == '5')
                {
                    lucinda.SpeakTo(lloyd, "Hi, Lloyd");
                }
                else return;
            }
        }

        void WhoAmI()
        {
            Console.WriteLine("My name is " + Name);
            Console.WriteLine("MyMy Ears are " + EarSize + " inches tall");
        }

        void HearMessage(string message, Elephant whoSaidIt)
        {
            Console.WriteLine(Name + " Heard a message");
            Console.WriteLine(whoSaidIt.Name + " said this: " + message);
        }

        void SpeakTo(Elephant whoToTalkTo, string message)
        {
            whoToTalkTo.HearMessage(message, this);
        }
    }
}
