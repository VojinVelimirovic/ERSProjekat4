using ProjekatERS.Generators;
using ProjekatERS.PowerPlant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace ProjekatERS.DistributionCenter
{
    public class DistributivniCentar:ICentar
    {

        int brojSlanja;
        double energija;
        Consumer.Consumer consumer;
        Generators.SolarniPanel solar1;
        Generators.SolarniPanel solar2;
        Generators.Vetrogenerator vetar1;
        PowerPlant.Hidroelektrana elektrana;
        Timer timer;

        public double Energija { get => energija; set => energija = value; }
        internal Consumer.Consumer Consumer { get => consumer; set => consumer = value; }
        public SolarniPanel Solar1 { get => solar1; set => solar1 = value; }
        public SolarniPanel Solar2 { get => solar2; set => solar2 = value; }
        public Vetrogenerator Vetar1 { get => vetar1; set => vetar1 = value; }
        public Hidroelektrana Elektrana { get => elektrana; set => elektrana = value; }
        public int BrojSlanja { get => brojSlanja; set => brojSlanja = value; }

        public DistributivniCentar()
        {
            energija = 0;
            brojSlanja = 0;
            using (StreamWriter sw = new StreamWriter("log_distributivnicentar.txt", false))
            {
                sw.WriteLine("Redni_broj, Vreme, Snage_generatora, Proizvodnja_elektrane, Kolicina_poslata, Cena");
            }
            consumer = new Consumer.Consumer();
        }
        //samoobjasnjavajuce metode centra
        public void Pokreni() {
            solar1 = new Generators.SolarniPanel("solarni1");
            solar2 = new Generators.SolarniPanel("solarni2");
            vetar1 = new Generators.Vetrogenerator("vetar1");
            elektrana = new PowerPlant.Hidroelektrana();
            timer = new Timer(15000);
            timer.Elapsed += (sender, e) =>
            {
                RegulisiElektranu();
                AzurirajEnergiju();
            };
            timer.AutoReset = true;
            timer.Enabled = true;
            consumer.Trosi();
        }

        public void AzurirajEnergiju() {
            energija = solar1.Snaga * (5.0 / 100.0) + solar2.Snaga * (5.0 / 100.0) + vetar1.Snaga * (5.0 / 100.0) + elektrana.Proizvodnja * (85.0/100.0);
            Console.WriteLine("==========================================================================");
            Console.WriteLine("SNAGA:\n\tSolar1 - {0}%\n\tSolar2 - {1}%\n\tVetar1 - {2}%", solar1.Snaga, solar2.Snaga, vetar1.Snaga);
            Console.WriteLine("\nPROIZVODNJA:\n\tHidroelektrana - {0}%", Elektrana.Proizvodnja);
            Console.WriteLine("\n\t\t\tUKUPNA ENERGIJA - {0}", energija);
            Console.WriteLine("==========================================================================");
            if (energija >= consumer.Potrosnja)
            {
                if (consumer.Potrosnja != 0) {
                    Console.WriteLine("\t\tEnergija poslata potrosacu! Cena iznosi {0}RSD\n", 30 * consumer.Potrosnja); //300 dinara za svaki kwh
                    Loguj();
                }
            }
            else {
                Console.WriteLine("\t\tNije proizvedeno dovoljno energije [ potrosnja - {0}, energija - {1}]\n", consumer.Potrosnja, energija);
            }
        }

        public void RegulisiElektranu()
        {
            int procenat = (int)Math.Round((100.0/85.0)*(consumer.Potrosnja - solar1.Snaga * (5.0 / 100.0) - solar2.Snaga * (5.0 / 100.0) - vetar1.Snaga * (5.0 / 100.0)))+1;
            elektrana.PromenaProizvodnje(procenat);
        }

        public void Loguj() {
            brojSlanja++;
            string linija = "Slanje " + brojSlanja + ", " + DateTime.Now + ", "+solar1.Snaga+ "% "+solar2.Snaga+"% "+vetar1.Snaga+"%, "+elektrana.Proizvodnja +"%, "+ consumer.Potrosnja + " kwh" + ", " + 30*consumer.Potrosnja +"RSD";
            using (StreamWriter sw = new StreamWriter("log_distributivnicentar.txt", true))
            {
                sw.WriteLine(linija);
            }
        }
    }
}
