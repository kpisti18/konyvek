using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kovacs_Istvan_12_console
{
    internal class Konyv
    {
        public int KonyvID { get; set; }
        public string Szerzo { get; set; }
        public string Cim { get; set; }
        public string ISBN { get; set; }
        public int Ar { get; set; }

        public Konyv(int konyvID, string szerzo, string cim, string iSBN, int ar)
        {
            KonyvID = konyvID;
            Szerzo = szerzo;
            Cim = cim;
            ISBN = iSBN;
            Ar = ar;
        }

        public override string ToString()
        {
            return $"{Szerzo}: {Cim}";
        }
    }
}
