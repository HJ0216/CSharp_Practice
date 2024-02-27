using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponDamage_Part_1
{
    internal class ArrowDamage
    {
        #region Properties
        private const decimal BASE_MULTIPLIER = 0.35M;
        private const decimal MAGIC_MULTIPLIER = 2.5M;
        private const decimal FLAME_DAMAGE = 1.25M;

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
        public ArrowDamage(int startingRoll)
        {
            Roll = startingRoll;
            CalculateDamage();
        }

        #endregion



        #region Methods
        private void CalculateDamage()
        {
            decimal baseDamage = Roll * BASE_MULTIPLIER;
            if (Magic) { baseDamage *= MAGIC_MULTIPLIER; }
            if (Flaming) { Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE); }
            else { Damage = (int)Math.Ceiling(baseDamage); }
        }

        #endregion


    }
}
