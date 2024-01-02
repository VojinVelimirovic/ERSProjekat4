using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatERS.PowerPlant
{
    interface IElektrana
    {
        //predvidjene metode elektrane
        void PromenaProizvodnje(int procenat);

        void Loguj();
    }
}
