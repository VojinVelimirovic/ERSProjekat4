using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatERS.Consumer
{
    class Sporet:IUredjaj
    {
        int potrosnjaPoCasu;
        bool ukljuceno;

        public int PotrosnjaPoCasu { get => potrosnjaPoCasu; set => potrosnjaPoCasu = value; }
        public bool Ukljuceno { get => ukljuceno; set => ukljuceno = value; }

        public Sporet()
        {
            this.potrosnjaPoCasu = 10;
            this.ukljuceno = false;
        }
   
        public bool Ukljuci()
        {
            if (ukljuceno == false)
            {
                ukljuceno = true;
                return true;
            }
            else
            {
                Console.WriteLine("Sporet je vec ukljucen!");
                return false;
            }
        }

        public bool Iskljuci()
        {
            if (ukljuceno == true)
            {
                ukljuceno = false;
                return true;
            }
            else
            {
                Console.WriteLine("Sporet je vec iskljucen!");
                return false;
            }
        }

    }
}
