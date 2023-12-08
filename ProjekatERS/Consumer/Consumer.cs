using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjekatERS.Consumer
{
    class Consumer
    {
        readonly string path = "log_consumer.txt";
        Usisivac usisivac;
        Sporet sporet;
        Bojler bojler;
        int potrosnja;
        int brojacPrijema;

        public Consumer()
        {
            this.usisivac = new Usisivac();
            this.sporet = new Sporet();
            this.bojler = new Bojler();
            this.potrosnja = 0;
            this.brojacPrijema = 0;
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("Redni_broj, Vreme, Kolicina_prijema");
            }
        }

        public int Potrosnja { get => potrosnja; set => potrosnja = value; }
        public int BrojacPrijema { get => brojacPrijema; set => brojacPrijema = value; }
        internal Usisivac Usisivac { get => usisivac; set => usisivac = value; }
        internal Sporet Sporet { get => sporet; set => sporet = value; }
        internal Bojler Bojler { get => bojler; set => bojler = value; }

        public void Logovanje(){
            brojacPrijema++;
            Console.WriteLine("Primljena energija. Trenutna potrosnja po casu iznosi {0} kWh\n", potrosnja);
            string linija = "Prijem " +brojacPrijema+ ", " +DateTime.Now + ", " + potrosnja+" kwh";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(linija);
            }
        }
        public void Trosi()
        {
            while (true)
            {
                bool odgovorValidan = false;
                string odgovor;
                Console.WriteLine("1.Ukljuci/Iskljuci Sporet\n2.Ukljuci/Iskljuci Usisivac\n3.Ukljuci/Iskljuci Bojler\nX.Napusti program\n\nUnesite izbor: ");
                odgovor = Console.ReadLine();
                if (odgovor.Equals("1"))
                {
                    odgovorValidan = true;
                    if(sporet.Ukljuceno == true)
                    {
                        sporet.Iskljuci();
                        potrosnja -= sporet.PotrosnjaPoCasu;
                    }
                    else
                    {
                        sporet.Ukljuci();
                        potrosnja += sporet.PotrosnjaPoCasu;
                    }
                }
                else if (odgovor.Equals("2"))
                {
                    odgovorValidan = true;
                    if (usisivac.Ukljuceno == true)
                    {
                        usisivac.Iskljuci();
                        potrosnja -= usisivac.PotrosnjaPoCasu;
                    }
                    else
                    {
                        usisivac.Ukljuci();
                        potrosnja += usisivac.PotrosnjaPoCasu;
                    }
                }
                else if (odgovor.Equals("3"))
                {
                    odgovorValidan = true;
                    if (bojler.Ukljuceno == true)
                    {
                        bojler.Iskljuci();
                        potrosnja -= bojler.PotrosnjaPoCasu;
                    }
                    else
                    {
                        bojler.Ukljuci();
                        potrosnja += bojler.PotrosnjaPoCasu;
                    }
                }
                else if (odgovor.ToLower().Equals("x"))
                {
                    break;
                }
                if(odgovorValidan == true) {
                    Logovanje();
                }
            }
        }
    }
}
