using System.Diagnostics;

namespace SwordDamage_Console_Part_1
{
    internal class SwordDamage
    {
        #region Properties
        static Random random = new Random();

        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

        private int _roll;
        public int Roll
        {
            get { return _roll; }
            set
            {
                _roll = value;
                CalculateDamage();
            }
        }

        private bool _flaming;
        public bool Flaming
        {
            get { return _flaming; }
            set
            {
                _flaming = value;
                CalculateDamage();
            }
        }

        private bool _magic;
        public bool Magic
        {
            get { return _magic; }
            set
            {
                _magic = value;
                CalculateDamage();
            }
        }

        public int Damage { get; private set; }

        #endregion



        #region Constructor
        public SwordDamage(int startingRoll)
        {
            Roll = startingRoll;
            CalculateDamage();
        }

        #endregion



        #region Methods
/*        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage(RollDice());
            while (true)
            {
                Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything to else to quit: ");
                char input = Console.ReadKey(false).KeyChar;

                Console.WriteLine();

                if (input != '0' && input != '1' && input != '2' && input != '3')
                {
                    return;
                }

                swordDamage.Roll = RollDice();

                swordDamage.Magic = (input == '1' || input == '3');
                swordDamage.Flaming = (input == '2' || input == '3');

                Console.WriteLine("Rolled " + swordDamage.Roll + " for " + swordDamage.Damage);

            }
        }*/

        private static int RollDice()
        {
            return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        }

        private void CalculateDamage()
        {
            decimal magicMuliplier = 1M;
            if (Magic) { magicMuliplier = 1.75M; }

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMuliplier) + BASE_DAMAGE;

            if (Flaming) { Damage += FLAME_DAMAGE; }

        }

        #endregion

        /*
        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;

        public int Roll;
        private decimal MagicMuliplier = 1M;
        private int FlamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMuliplier) + BASE_DAMAGE + FlamingDamage;
            Debug.WriteLine($"CalculateDamage finished {Damage} (roll: {Roll})");
        }

        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMuliplier = 1.75M;
            }
            else
            {
                MagicMuliplier = 1M;
            }
            CalculateDamage();
            Debug.WriteLine($"SetMagic finished {Damage} (roll: {Roll})");
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
            Debug.WriteLine($"SetFlaming finished {Damage} (roll: {Roll})");
        }

        
        static void Main(string[] args)
        {
            SwordDamage swordDamage = new SwordDamage();
            Random random = new Random();

            while (true)
            {
                Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything to else to quit: ");
                char input = Console.ReadKey(false).KeyChar;
                Console.WriteLine();

                if(input != '0' && input != '1' && input != '2' && input != '3')
                {
                    return;
                }

                swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);

                swordDamage.SetMagic(input == '1' || input == '3');
                swordDamage.SetFlaming(input == '2' || input == '3');

                
                for (int i=0; i<3; i++)
                {
                    swordDamage.Roll += random.Next(1, 7);
                }

                if (input == '0')
                {
                    swordDamage.SetMagic(false);
                }
                else if(input == '1')
                {
                    swordDamage.SetMagic(true);

                }
                else if(input == '2')
                {
                    swordDamage.SetMagic(false);
                    swordDamage.SetFlaming(true);
                }
                else if(input == '3')
                {
                    swordDamage.SetMagic(true);
                    swordDamage.SetFlaming(true);

                }
                else
                {
                    return;
                }
                

                Console.WriteLine("Rolled " + swordDamage.Roll + " for " + swordDamage.Damage);
                
            }
        }
        */
    }
}
