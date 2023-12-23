using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatERS
{
    interface IUredjaj
    {
        //ove metode menjaju stanje uredjaja, svi uredjaji moraju da ih imaju
        bool Ukljuci();
        bool Iskljuci();
    }
}
