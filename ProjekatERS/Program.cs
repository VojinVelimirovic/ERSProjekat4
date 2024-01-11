using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatERS
{
    class Program
    {
        static void Main()
        {
            //pokretanje programa
            DistributionCenter.DistributivniCentar centar = new DistributionCenter.DistributivniCentar();
            centar.Pokreni();
        }
    }
}
