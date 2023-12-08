using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Xml.Serialization;

namespace ProjekatERS.Generators
{
    [Serializable]
    public class LogSunce
    {
        public DateTime Vreme { get; set; }
        public int Snaga { get; set; }
    }

    [Serializable]
    public class SolarniPanel:IGenerator
    {
        int snaga;
        string ime;
        readonly object zakljucaj = new object();
        List<LogSunce> logovi = new List<LogSunce>();
        string path;
        static Random random = new Random();
        readonly Timer timer;

        public int Snaga { get => snaga; set => snaga = value; }
        public string Ime { get => ime; set => ime = value; }
        public List<LogSunce> Logovi { get => logovi; set => logovi = value; }

        public SolarniPanel(string ime)
        {
            Ime = ime;
            path = $"log_{Ime}.xml";
            Snaga = random.Next(0, 101);
            timer = new Timer(5000);
            timer.Elapsed += (sender, e) => PromenaSnage();
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void PromenaSnage()
        {
            lock (zakljucaj)
            {
                Snaga += random.Next(-5, 6);
                Snaga = Math.Max(0, Math.Min(100, Snaga));
                Loguj();
            }
        }

        public void Loguj()
        {
            lock (zakljucaj)
            {
                Logovi.Add(new LogSunce { Vreme = DateTime.Now, Snaga = Snaga });
                XmlSerializer serializer = new XmlSerializer(typeof(List<LogSunce>));
                using (TextWriter writer = new StreamWriter(path, false))
                {
                    serializer.Serialize(writer, Logovi);
                }
            }
        }
    }
}
