using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    public class SwimmingPool
    {
        #region Properties
        public static Random R = new Random();

        private int _n1 = 0;
        public int N1
        {
            get { return _n1; }
            private set { _n1 = value; }
        }

        private string _op = string.Empty;
        public string Op
        {
            get { return _op; }
            private set { _op = value; }
        }

        private int _n2 = 0;
        public int N2
        {
            get { return _n2; }
            private set { _n2 = value; }
        }

        #endregion



        #region Constructor
        public SwimmingPool(bool add)
        {
            if (add)
            {
                Op = "+";
            }
            else
            {
                Op = "*";
            }
        }

        #endregion



        #region Methods
        public bool Check(int a)
        {
            if(Op == "+") { return (a == N1 + N2); }
            else { return (a == N1 * N2); }
        }
        public void SwimmingPoolProgram()
        {
            SwimmingPool swimmingPool = new SwimmingPool(SwimmingPool.R.Next(2) == 1);
            while (true)
            {
                Console.Write($"{swimmingPool.N1} {swimmingPool.Op} {swimmingPool.N2} = ");
                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine("Thanks for playing!");
                    return;
                }
                if (swimmingPool.Check(i))
                {
                    Console.WriteLine("Right!");
                    swimmingPool = new SwimmingPool(SwimmingPool.R.Next(2) == 1);
                }
                else
                {
                    Console.WriteLine("Wrong! Try Again!");
                }
            }
        }

        #endregion
    }
}
