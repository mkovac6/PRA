using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository
    {
        void SetKvizZapocet(int iDKviz);
        Autor SelectAutor(String email);
        Autor SelectAutor(int ID);
        void DeleteAutor(int ID);
        void UpdateAutorImeIPrezime(int ID, string Ime, string Prezime);
        void UpdateLozinka(int ID, string Lozinka);
        void SetKvizVecJednomOdigran(int iDKviz);
        int InsertAutor(Autor autor);
        bool SelectAutorEmail_Lozinka(String email, String lozinka);
        IEnumerable<Kviz> SelectKvizovi(int IDAutor);
        Kviz SelectKviz(int ID); //
        int InsertKivz(Kviz kviz);
        void DeleteKivz(int ID);
        int InsertPitanje(Pitanje pitanje);
        Pitanje SelectPitanje(int ID);
        int PregledTocnihOdgovora(int IDPitanje);
        void DeletePitanje(Pitanje pitanje);
        void SetKvizNijeZapocet(int iDKviz);
        IEnumerable<Pitanje> SelectPitanja(int IDKviz);
        Kviz SelectKviz(string kod);
        void InsertOdgovor(Odgovor odgovor);
        Odgovor SelectOdgovor(int ID);
        IEnumerable<Odgovor> SelectOdgovori(int PitanjeID);
        int AddIgarc(Igrac igrac);
        void AddIgarcInKviz(string kodKviza, int iDIgrac, int bodovi);
        IEnumerable<Igrac> getIgraci(string kodKviza);
        void UpdateOdgovor(int ID, int PitanjeID, string Text, bool Tocno);
        void DeleteOdgovor(int ID);
        void SetAktivanOdgovor(int ID);

        bool CheckIfKvizIsStarted(string kodKviza);
        void InsertBodovi(int idIgrac, object bodovi);
        int getBotovi(int iDIgrac, string kodKviza);
        void updatePitanje(Pitanje Pitanje);
        IEnumerable<int> SelectKodKviza();
    }
}
