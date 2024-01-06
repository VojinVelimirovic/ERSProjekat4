using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ProjekatERS.PowerPlant
{
    //log sadrzi potrebne informacije
    [Serializable]
    public class LogElektrana
    {
        public DateTime Vreme { get; set; }
        public int Proizvodnja { get; set; }
    }
    [Serializable]
    public class Hidroelektrana:IElektrana
    {
        int proizvodnja;
        List<LogElektrana> logovi = new List<LogElektrana>();
        string path;

        public int Proizvodnja { get => proizvodnja; set => proizvodnja = value; }
        public List<LogElektrana> Logovi { get => logovi; set => logovi = value; }

        //proizvodnja je inicijalno 0
        public Hidroelektrana() {
            path = $"log_hidroelektrana.xml";
            proizvodnja = 0;
        }

        //jednostavna funkcija koja menja procenat manuelno, a ne nasumicno
        public void PromenaProizvodnje(int procenat) {
            if (procenat >= 0 && procenat <= 100)
            {
                Proizvodnja = procenat;
                Loguj();
<<<<<<< HEAD
=======
                Console.WriteLine("Procenat proizvodnje promenjen na {0}.", Proizvodnja);
>>>>>>> f4a69fd03d0d7a7f265b9182a692b621dbe595ad
            }
            else {
                Console.WriteLine("Procenat proizvodnje mora biti izmedju 0 i 100 posto!");
            }
        }

        //logovanje procenta proizvodnje u trenutku promene
        public void Loguj() {
            Logovi.Add(new LogElektrana { Vreme = DateTime.Now, Proizvodnja = Proizvodnja });
            XmlSerializer serializer = new XmlSerializer(typeof(List<LogElektrana>));
            using (TextWriter writer = new StreamWriter(path, false))
            {
                serializer.Serialize(writer, Logovi);
            }
        }
    }
}
