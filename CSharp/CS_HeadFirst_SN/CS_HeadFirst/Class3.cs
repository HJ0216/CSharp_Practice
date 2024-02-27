using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    internal class Class3
    {
        public void mainMethod()
        {
            Pizzazz foxtrot = new Pizzazz()
            {
                Zippo = 2,
            };
            foxtrot.Bamboo(foxtrot.Zippo);
            Pizzazz november = new Pizzazz()
            {
                Zippo = 3,
            };

            Abracadabra tango = new Abracadabra()
            {
                Vavavoom = 4,
            };

            while (tango.Lala(november.Zippo))
            {
                november.Zippo *= -1;
                november.Bamboo(tango.Vavavoom);
                foxtrot.Bamboo(november.Zippo);
                tango.Vavavoom -= foxtrot.Zippo;
            }

            Console.WriteLine("november.Zippo: " + november.Zippo);
            Console.WriteLine("foxtrot.Zippo: " + foxtrot.Zippo);
            Console.WriteLine("tango.Vavavoom: " + tango.Vavavoom);
        }
    }
    class Abracadabra
    {
        public int Vavavoom;
        public bool Lala(int floq)
        {
            if(floq < Vavavoom)
            {
                Vavavoom += floq;
                return true;
            }
            return false;
        }
    }
    class Pizzazz
    {
        public int Zippo;
        public void Bamboo(int eek)
        {
            Zippo += eek;
        }
    }
}
