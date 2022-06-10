using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class EditKviz : System.Web.UI.Page
    {
        public Kviz Kviz {
            get {
                if (Application[kodKviza] == null)
                    Application[kodKviza] = new Kviz();
                return (Kviz)Application[kodKviza];
            }
            set { Application[kodKviza] = value; }
        }
        public string kodKviza {
            get {
                if (Session["kod"] == null)
                    Session["kod"] = "";
                return (string)Session["kod"];
            }
            set { Session["kod"] = value; }
        }


        private IRepository repository = RepositoryFacotry.GetRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Kviz == null)
            {
                Response.Redirect("PocetnaStranaAutora.aspx");
            }


            if (Kviz.VecJednomOdigran)
            {
                Kviz.VecJednomOdigran = false;
                int id = repository.InsertKivz(Kviz);
                foreach (Pitanje item in repository.SelectPitanja(Kviz.IDKviz))
                {
                    int stariId = item.IDPitanje;
                    item.KvizID = id;
                    int idPitanje = repository.InsertPitanje(item);
                    foreach (Odgovor o in repository.SelectOdgovori(stariId))
                    {
                        o.PitanjeID = idPitanje;
                        repository.InsertOdgovor(o);
                    }

                }
                Kviz noviKviz = repository.SelectKviz(id);
                kodKviza = noviKviz.KodKviza;
                Kviz = repository.SelectKviz(id);

            }
            else
            {
                Kviz = Kviz;
            }
            ShowPitanje();
        }

        private void ShowPitanje()
        {
            //kviz treba biti spremljen u sessionu
            ph.Controls.Clear();
            List<Pitanje> p = repository.SelectPitanja(Kviz.IDKviz).ToList();



            foreach (Pitanje pitanje in p)
            {
                KvizControl kvizControl = LoadControl("KvizControl.ascx") as KvizControl;
                kvizControl.ID = pitanje.IDPitanje.ToString();
                kvizControl.InItSetUp(pitanje, getOgovori(pitanje));
                kvizControl.DeleteOdgovor += KvizControl_DeleteOdgovor;
                kvizControl.EditOdgovor += KvizControl_EditOdgovor;
                kvizControl.EditPitanje += KvizControl_EditPitanje;
                kvizControl.DeletePitanje += KvizControl_DeletePitanje;
                ph.Controls.Add(kvizControl);

            }



        }

        private void KvizControl_DeletePitanje(Pitanje pitanje)
        {
            repository.DeletePitanje(pitanje);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void KvizControl_EditPitanje(Pitanje pitanje)
        {
            repository.updatePitanje(pitanje);
        }

        private void KvizControl_EditOdgovor(object sender, Odgovor e)
        {
            Response.Redirect($"Edit.aspx?id={e.IDOdgovor}");
        }

        private List<Odgovor> getOgovori(Pitanje pitanje)
        {
            List<Odgovor> odgovori = repository.SelectOdgovori(pitanje.IDPitanje).ToList();
            odgovori.RemoveAll(odg => odg.Aktivan == false);
            return odgovori;
        }

        private void KvizControl_DeleteOdgovor(object sender, Odgovor e)
        {
            repository.DeleteOdgovor(e.IDOdgovor);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PocetnaStranaAutora.aspx");
        }
    }
}