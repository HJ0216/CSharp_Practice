using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    internal class Class2
    {
        public void playAGame()
        {
            Random random = new Random();
            double odds = 0.75;
            Guy player = new Guy()
            {
                Name = "The Player",
                Cash = 100,
            };

            Console.WriteLine("Welcome to the casino. The odds are " + odds);

            while (player.Cash>0)
            {
                player.WriteMyInfo();
                Console.Write("How much do you want to bet: ");

                string howMuch = Console.ReadLine();

                if(int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    
                    if(random.NextDouble() > odds)
                    {
                        Console.WriteLine("Awesome");
                        player.ReceiveCash(pot);
                    }
                    else
                    {
                        Console.WriteLine("Loss");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

        }
    }

}
