using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatERS.Generators
{
    interface IGenerator
    {
        //obe vrste generatora primenjuju iste metode, gde im se kroz vreme(na svakih 5s) menja snaga
        //i one promenu logoju
        void PromenaSnage();
        void Loguj();
    }
}
