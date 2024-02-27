using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PaintballGun
{
    internal class PaintballGun
    {
        //public const int MAGAZINE_SIZE = 16;

        //private int balls = 0;
        //private int ballsLoaded = 0;


        //public int GetBallsLoaded() { return ballsLoaded; }
        //public bool IsEmpty() { return ballsLoaded == 0; }

        #region Properties
        private int _magazineSize = 16;
        public int MagazineSize
        {
            get { return _magazineSize; }
            private set { _magazineSize = value; }
        }


        private int _balls = 0;
        public int Balls
        {
            get { return _balls; }
            set 
            {
                if(value > 0)
                {
                    _balls = value;
                }
                Reload();
            }
        }

        private int _ballsLoaded = 0;
        public int BallsLoaded
        {
            get { return _ballsLoaded; }
            private set { _ballsLoaded = value; }
        }

        #endregion



        #region Constructor
        public PaintballGun(int balls, int magazineSize, bool loaded)
        {
            this.Balls = balls;
            this.MagazineSize = magazineSize;
            if (!loaded) { Reload(); }
        }

        #endregion


        #region Method
        public bool IsEmpty() { return BallsLoaded == 0; }


        /*
        public int GetBalls() { return balls; }
        public void SetBalls(int numberOfBalls)
        {
            if(numberOfBalls > 0) { balls = ballsLoaded; }
            Reload();
        }
        */
        public void Reload()
        {
            if(Balls > MagazineSize)
            {
                BallsLoaded = MagazineSize;
            }
            else
            {
                BallsLoaded = Balls;
            }
        }
        public bool Shoot()
        {
            if(BallsLoaded == 0) { return false; }
            BallsLoaded--;
            Balls--;
            return true;
        }

        #endregion
    }
}
