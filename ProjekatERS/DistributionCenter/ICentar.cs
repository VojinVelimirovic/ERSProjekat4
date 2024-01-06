using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatERS.DistributionCenter
{
    interface ICentar
    {
        //ima sve predvidjene metode distributivnog centra
        void Pokreni();
        void AzurirajEnergiju();

        void RegulisiElektranu();

        void Loguj();
    }
}
