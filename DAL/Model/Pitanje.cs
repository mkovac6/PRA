using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
  public  class Pitanje
    {
        public int IDPitanje { get; set; }
        public int KvizID { get; set; }
        public string Text { get; set; }
        public int Trajanje { get; set; }
        public bool Aktivan { get; set; }
        public List<Odgovor> Odgovori { get; set; }
    }
}
