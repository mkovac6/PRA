using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLRepository sq = new SQLRepository();
            Kviz k = sq.SelectKviz(1); 
        }
    }
}
