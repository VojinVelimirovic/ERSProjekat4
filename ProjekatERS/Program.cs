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
            Consumer.Consumer potrosac = new Consumer.Consumer();
            Generators.SolarniPanel solar1 = new Generators.SolarniPanel("solarni1");
            Generators.SolarniPanel solar2 = new Generators.SolarniPanel("solarni2");
            Generators.Vetrogenerator vetar1 = new Generators.Vetrogenerator("vetar1");
            potrosac.Trosi();
        }
    }
}
