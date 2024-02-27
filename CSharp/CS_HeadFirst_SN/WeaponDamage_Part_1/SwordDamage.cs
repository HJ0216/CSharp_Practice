
using System;

namespace WeaponDamage_Part_1
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
        private void CalculateDamage()
        {
            decimal magicMuliplier = 1M;
            if (Magic) { magicMuliplier = 1.75M; }

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMuliplier) + BASE_DAMAGE;

            if (Flaming) { Damage += FLAME_DAMAGE; }

        }

        #endregion


    }
}
