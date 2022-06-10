using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Odgovor
    {
        public int IDOdgovor { get; set; }
        public int PitanjeID { get; set; }
        public string Tekst { get; set; }
        public bool Tocno { get; set; }
        public bool Aktivan { get; set; }
    }
}
