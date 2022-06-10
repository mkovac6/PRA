using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Reflection;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DAL
{
    public class SQLRepository : IRepository
    {
        private readonly string connectionString = "Data Source=83.181.208.234,1433;Network Library=DBMSSOCN;Initial Catalog=Kviz;User ID=Ivana;Password=SQL;";
        public IEnumerable<Kviz> SelectKvizovi(int IDAutor)
        {
            DataTable data = SqlHelper.ExecuteDataset(connectionString, "SelectKvizovi", IDAutor).Tables[0];
            foreach (DataRow row in data.Rows)
            {
                yield return GetKviz(row);
            }
        }

        public bool SelectAutorEmail_Lozinka(string email, string lozinka)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@Email", email);
            parameters[1] = new SqlParameter("@Lozinka", Utilities.SHAUtils.ToSHA256(lozinka));
            parameters[2] = new SqlParameter("@Postoji", System.Data.SqlDbType.Bit);
            parameters[2].Direction = System.Data.ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "SelectAutorEmailLozinka", parameters);
            return (Boolean)parameters[2].Value;
        }

        public void DeleteAutor(int IDAutor)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "DeleteAutor", IDAutor);
        }

        public void DeleteKivz(int ID)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "DeleteKviz", ID);
        }
        public int InsertAutor(Autor autor)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@Email", autor.Email);
            parameters[1] = new SqlParameter("@Ime", autor.Ime);
            parameters[2] = new SqlParameter("@Prezime", autor.Prezime);
            parameters[3] = new SqlParameter("@Lozinka", Utilities.SHAUtils.ToSHA256(autor.Lozinka));
            parameters[4] = new SqlParameter("@idAutor", System.Data.SqlDbType.Int);
            parameters[4].Direction = System.Data.ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertAutor", parameters);
            return (int)parameters[4].Value;
        }

        public int InsertKivz(Kviz kviz)
        {
            string Kod = GenerateRandomNumber.RandomString(5);
            while (SelectKodKviza().ToList().Contains(int.Parse(Kod)))
            {
                Kod = GenerateRandomNumber.RandomString(5);
            }
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@AutorID", kviz.AutorID);
            parameters[1] = new SqlParameter("@DatumIzrade", kviz.DatumIzrade);
            parameters[2] = new SqlParameter("@VecJednomOdigran", kviz.VecJednomOdigran);
            parameters[3] = new SqlParameter("@Aktivan", kviz.Aktivan);
            parameters[4] = new SqlParameter("@Naziv", kviz.Naziv);
            parameters[5] = new SqlParameter("@Kod", Kod);
            parameters[6] = new SqlParameter("@KvizID", System.Data.SqlDbType.Int);
            parameters[6].Direction = System.Data.ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertKviz", parameters);
            return (int)parameters[6].Value;
        }

        public int InsertPitanje(Pitanje pitanje)
        {
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, "InsertPitanje", pitanje.Text, pitanje.KvizID, pitanje.Trajanje, pitanje.Aktivan).Tables[0];

            foreach (DataRow row in dataTable.Rows)
            {
                return (int)row["IDPitanje"];
            }
            throw new Exception();
        }

        public Autor SelectAutor(int ID)
        {
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, "SelectAutor", ID).Tables[0];

            foreach (DataRow autor in dataTable.Rows)
            {

                return GetAutor(autor);
            }
            throw new Exception("There is no such ID!");
        }

        Autor GetAutor(DataRow row)
        {
            return new Autor()
            {
                IDAutor = (int)row["IDAutor"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Lozinka = row["Lozinka"].ToString()
            };
        }

        public Kviz SelectKviz(int ID)
        {
            return GetKviz(SqlHelper.ExecuteDataset(connectionString, "SelectKviz", ID).Tables[0].Rows[0]);
        }

        private Kviz GetKviz(DataRow row)
        {
            return new Kviz()
            {
                IDKviz = (int)row["IDKviz"],
                Naziv = row["Naziv"].ToString(),
                Aktivan = (Boolean)row["Aktivan"],
                AutorID = (int)row["AutorID"],
                DatumIzrade = (DateTime)row["DatumIzrade"],
                VecJednomOdigran = (Boolean)row["VecJednomOdigran"],
                KodKviza=row["Kod"].ToString()
            };
        }

        public IEnumerable<Pitanje> SelectPitanja(int IDKviz)
        {
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, "SelectPitanja", IDKviz).Tables[0];

            foreach (DataRow row in dataTable.Rows)
            {
                yield return new Pitanje()
                {
                    IDPitanje = (int)row["IDPitanje"],
                    KvizID = (int)row["KvizID"],
                    Text = row["Tekst"].ToString(),
                    Trajanje = (int)row["Trajanje"]
                };
            }
            //  throw new Exception("There is no such ID!");
        }

        public Pitanje SelectPitanje(int ID)
        {
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, "SelectPitanje", ID).Tables[0];

            foreach (DataRow row in dataTable.Rows)
            {
                return new Pitanje()
                {
                    IDPitanje = (int)row["IDPitanje"],
                    KvizID = (int)row["KvizID"],
                    Text = row["Tekst"].ToString(),
                    Trajanje = (int)row["Trajanje"]
                };
            }
            throw new Exception("There is no such ID!");
        }

        public void UpdateAutorImeIPrezime(int IDAutor, string Ime, string Prezime)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "UpdateAutorImeIPrezime", IDAutor, Ime, Prezime);
        }

        public void UpdateLozinka(int IDAutor, string Lozinka)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "UpdateAutorLozinka", IDAutor, Utilities.SHAUtils.ToSHA256(Lozinka));
        }

        public void InsertOdgovor(Odgovor odgovor)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "InsertOdgovor", odgovor.Tekst, odgovor.PitanjeID, odgovor.Tocno);
        }

        public Odgovor SelectOdgovor(int ID)
        {
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, "SelectOdgovor", ID).Tables[0];

            foreach (DataRow row in dataTable.Rows)
            {
                return new Odgovor()
                {
                    IDOdgovor = (int)row["IDOdgovor"],
                    PitanjeID = (int)row["PitanjeID"],
                    Tekst = row["Tekst"].ToString(),
                    Tocno = (bool)row["Tocno"],
                    Aktivan = (bool)row["Aktivan"]

                };

            }
            throw new Exception("There is no such ID!");
            ;
        }

        public void UpdateOdgovor(int ID, int PitanjeID, string Text, bool Tocno)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "UpdateOdgovor", ID, PitanjeID, Text, Tocno);
        }

        public void DeleteOdgovor(int ID)
        {

            SqlHelper.ExecuteNonQuery(connectionString, "DeleteOdgovor", ID);
        }

        public void SetAktivanOdgovor(int ID)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "SetAktivanOdgovor", ID);
        }

        public IEnumerable<Odgovor> SelectOdgovori(int PitanjeID)
        {
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, "SelectOdgovori", PitanjeID).Tables[0];

            foreach (DataRow row in dataTable.Rows)
            {
                yield return new Odgovor()
                {
                    IDOdgovor = (int)row["IDOdgovor"],
                    PitanjeID = (int)row["PitanjeID"],
                    Tekst = row["Tekst"].ToString(),
                    Tocno = (Boolean)row["Tocno"],
                    Aktivan = (Boolean)row["Aktivan"],
                };
            }
        }

        public void DeletePitanje(Pitanje pitanje)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "DeletePitanje", pitanje.IDPitanje);
        }

        public int PregledTocnihOdgovora(int IDPitanje)
        {
            foreach (DataRow item in SqlHelper.ExecuteDataset(connectionString, "PregledTocnihOdgovora", IDPitanje).Tables[0].Rows)
            {
                return int.Parse(item[0].ToString());
            }
            throw new Exception();
        }

        public Autor SelectAutor(string email)
        {
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, "SelectEmail", email).Tables[0];

            foreach (DataRow autor in dataTable.Rows)
            {

                return GetAutor(autor);
            }
            throw new Exception("There is no such ID!");
        }

        public bool CheckIfKvizIsStarted(string kodKviza)
        {
            if (kodKviza.Length>=6)
            {
                return false;
            }
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Kod", kodKviza);
            parameters[1] = new SqlParameter("@Zapocet", System.Data.SqlDbType.Bit);
            parameters[1].Direction = System.Data.ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "CheckKviz", parameters);
            return (Boolean)parameters[1].Value;
        }

        public void SetKvizZapocet(int iDKviz)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "SetKvizZapocet", iDKviz);
        }

        public Kviz SelectKviz(string kod)
        {
            DataRow row = SqlHelper.ExecuteDataset(connectionString, "SelectKvizWithKod", kod).Tables[0].Rows[0];
            return GetKviz(row);
        }

        public int AddIgarc(Igrac igrac)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@Naziv", igrac.Naziv);
            parameters[1] = new SqlParameter("@IDIgrac", System.Data.SqlDbType.Int);
            parameters[1].Direction = System.Data.ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertIgrac2", parameters);
            return (int)parameters[1].Value;
        }

        public void AddIgarcInKviz(string kodKviza, int iDIgrac, int bodovi)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "InsertIgracInKviz", kodKviza, iDIgrac, bodovi);
        }

        public IEnumerable<Igrac> getIgraci(string kodKviza)
        {
            DataTable dataTable = SqlHelper.ExecuteDataset(connectionString, "SelectIgraci", kodKviza).Tables[0];

            foreach (DataRow igrac in dataTable.Rows)
            {

                yield return new Igrac()
                {
                    IDIgrac = (int)igrac["IDIgrac"],
                    Naziv = igrac["Nadimak"].ToString()
                };
            }
        }

        public void InsertBodovi(int idIgrac, object bodovi)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "updateBodovi", idIgrac, bodovi);
        }

        public int getBotovi(int iDIgrac, string kodKviza)
        {
            return (int)SqlHelper.ExecuteScalar(connectionString, "getBodovi", iDIgrac,kodKviza);
        }

        public void updatePitanje(Pitanje Pitanje)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "UpdatePitanje", Pitanje.IDPitanje,Pitanje.Text,Pitanje.Trajanje);
        }

        public void SetKvizVecJednomOdigran(int iDKviz)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "SetKvizVecJednomOdigran", iDKviz);
        }

        public void SetKvizNijeZapocet(int iDKviz)
        {
            SqlHelper.ExecuteNonQuery(connectionString, "SetKvizNijeZapocet", iDKviz);
        }

        public IEnumerable<int> SelectKodKviza()
        {
            DataSet dataSet = SqlHelper.ExecuteDataset(connectionString, "SelectKodKviza");
            foreach (DataRow item in dataSet.Tables[0].Rows)
            {
                yield return int.Parse(item["Kod"].ToString());
            }
        }
    }
}       

