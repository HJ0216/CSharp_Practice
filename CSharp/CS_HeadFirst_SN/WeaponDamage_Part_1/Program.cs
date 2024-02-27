namespace WeaponDamage_Part_1
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage(RollDice(3));
            ArrowDamage arrowDamage = new ArrowDamage(RollDice(1));

            while (true)
            {
                Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything to else to quit: ");
                char inputOption = Console.ReadKey(false).KeyChar;

                Console.WriteLine();

                if (inputOption != '0' && inputOption != '1' && inputOption != '2' && inputOption != '3')
                {
                    return;
                }

                Console.Write("S for Sword, A for Arrow, anything else to quit: ");
                char weaponInput = Char.ToUpper(Console.ReadKey().KeyChar);

                Console.WriteLine();

                switch (weaponInput)
                {
                    case 'S':
                        swordDamage.Roll = RollDice(3);
                        swordDamage.Magic = (inputOption == '1' || inputOption == '3');
                        swordDamage.Flaming = (inputOption == '2' || inputOption == '3');
                        Console.WriteLine("Rolled " + swordDamage.Roll + " for " + swordDamage.Damage);

                        break;
                    case 'A':
                        arrowDamage.Roll = RollDice(1);
                        arrowDamage.Magic = (inputOption == '1' || inputOption == '3');
                        arrowDamage.Flaming = (inputOption == '2' || inputOption == '3');
                        Console.WriteLine("Rolled " + arrowDamage.Roll + " for " + arrowDamage.Damage);

                        break;
                    default:
                        return;
                }
            }
        }

        private static int RollDice(int numberOfRolls)
        {
            int total = 0;
            for(int i=0; i<numberOfRolls; i++)
            {
                total += random.Next(1, 7);
            }
            return total;
        }


    }
}
