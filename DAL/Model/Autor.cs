using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Model;
using Glimpse.Ado.Tab;
using LinqToDB;

namespace DAL.Model
{
    public class Autor
    {
        public int IDAutor { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public bool Aktivan { get; set; }

    }
}


