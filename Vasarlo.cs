using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kovacs_Istvan_12_console
{
    internal class Vasarlo
    {
        public int VasarloID { get; set; }
        public string Nev { get; set; }
        public string EmailCim { get; set; }
        public string Felhasznalonev { get; set; }

        public Vasarlo(int vasarloID, string nev, string emailCim, string felhasznalonev)
        {
            VasarloID = vasarloID;
            Nev = nev;
            EmailCim = emailCim;
            Felhasznalonev = felhasznalonev;
        }

        public override string ToString()
        {
            return $"{Nev}";
        }
    }
}
