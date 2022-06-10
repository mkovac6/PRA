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
    public partial class SomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Kviz!=null)
            {
                IEnumerable<Pitanje> pitanja = repository.SelectPitanja(Kviz.IDKviz);
                if ((pitanja.Count()-1)==int.Parse(pitanje))
                {
                    pitanje = "gotovokviz!";
                    Response.Redirect("KrajKviza.aspx");
                }

            }

            ShowPlayers();
        }
        private static IRepository repository = RepositoryFacotry.GetRepository();
        private void ShowPlayers()
        {
            foreach (Igrac item in repository.getIgraci(Kviz.KodKviza))
            {
                Label label = new Label();
                label.Text = item.Naziv + " -> " + repository.getBotovi(item.IDIgrac, Kviz.KodKviza).ToString();
                label.ID = item.IDIgrac.ToString();
                label.Width = 250;
                label.CssClass = "form-control m-3";
                pHolder.Controls.Add(label);
            }
        }

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
        public string pitanje {
            get {
                if (Application["pitanje"+ kodKviza] == null)
                {
                    Application["pitanje"+ kodKviza] = "";
                }
                return (string)Application["pitanje"+ kodKviza];
            }
            set {
                Application["pitanje"+ kodKviza] = value;
            }
        }
        
        protected void btnNext_Click(object sender, EventArgs e)
        {
            pitanje = (int.Parse(pitanje)+1).ToString();
            int brojPitanja = repository.SelectPitanja((Kviz.IDKviz)).ToList().Count;
            Response.Redirect("StartKviz.aspx");
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            repository.SetKvizNijeZapocet(Kviz.IDKviz);
            pitanje = "gotovo!";
            Response.Redirect("PocetnaStranaAutora.aspx");
        }
    }
}