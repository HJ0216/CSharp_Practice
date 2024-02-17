using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickRandomCards
{
    internal class CardPicker
    {

        static Random random = new Random();
        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            /* foreach: 읽기 전용
            foreach (string item in pickedCards)
            {
                item = RandomValue() + " of " + RandomSuit();
            }
            */

            for (int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuit(); 
            }

            return pickedCards;
        }

        private static string RandomSuit()
        {
            int value = random.Next(1, 5);
            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";
            return "Diamonds";
        }

        private static string RandomValue()
        {
            int value = random.Next(1, 14);
            if (value == 1) return "Ace";
            if (value == 11) return "Jack";
            if (value == 12) return "Queen";
            if (value == 13) return "King";
            return value.ToString();
        }
    }
}
