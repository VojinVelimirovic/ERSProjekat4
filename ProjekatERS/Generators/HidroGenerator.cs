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
    public class LogHidro
    {
        public DateTime VremeHidro { get; set; }
        public int SnagaHidro { get; set; }
    }

    //dodavanje HidroGeneratora
    class HidroGenerator
    {
        int snaga;
        string ime;
        readonly object zakljucaj = new object();
        List<LogHidro> logoviHidro = new List<LogHidro>();
        //sledece tri promenljive su readonly jer ne bi smeli mi da ih menjamo
        readonly string path;
        readonly static Random random = new Random();
        readonly Timer timer;

        public int Snaga { get => snaga; set => snaga = value; }
        public string Ime { get => ime; set => ime = value; }
        public List<LogHidro> LogoviHidro { get => logoviHidro; set => logoviHidro = value; }

        
        public HidroGenerator(string ime)
        {
            Ime = ime;
            path = $"log_{Ime}.xml";
            Snaga = random.Next(0, 101);
            timer = new Timer(5000);
            timer.Elapsed += (sender, e) => PromenaSnage();
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //metoda koja menja snagu na svakih 5s postavljenih iznad
        public void PromenaSnage()
        {
            lock (zakljucaj)
            {
                Snaga += random.Next(-5, 6);
                Snaga = Math.Max(0, Math.Min(100, Snaga));
                Loguj();
            }
        }

        //metoda koja upisuje snagu u datom trenutku
        public void Loguj()
        {
            lock (zakljucaj)
            {
                LogoviHidro.Add(new LogHidro { VremeHidro = DateTime.Now, SnagaHidro = Snaga });
                XmlSerializer serializer = new XmlSerializer(typeof(List<LogVetar>));
                using (TextWriter writer = new StreamWriter(path, false))
                {
                    serializer.Serialize(writer, LogoviHidro);
                }
            }
        }
    }
}
