using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Kviz
    {
        public int IDKviz { get; set; }
        public int AutorID { get; set; }
        public string Naziv { get; set; }
        public string KodKviza { get; set; }
        public DateTime DatumIzrade { get; set; }
        public Boolean VecJednomOdigran { get; set; }
        public Boolean Aktivan { get; set; }

        public IList<Pitanje> pitanjes = new List<Pitanje>();
        public ISet<Igrac> igraci = new SortedSet<Igrac>();

    }
}
