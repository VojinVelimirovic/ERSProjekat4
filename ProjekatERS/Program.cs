﻿using System;
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
            Consumer.Consumer potrosac = new Consumer.Consumer();
            Generators.SolarniPanel solar1 = new Generators.SolarniPanel("solarni1");
            Generators.SolarniPanel solar2 = new Generators.SolarniPanel("solarni2");
            Generators.Vetrogenerator vetar1 = new Generators.Vetrogenerator("vetar1");
            Generators.Vetrogenerator vetar2 = new Generators.Vetrogenerator("vetar2");
            Generators.HidroGenerator hidroGenerator = new Generators.HidroGenerator("hidro");
            potrosac.Trosi();
        }
    }
}
