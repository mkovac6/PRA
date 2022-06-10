using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Threading;

namespace Frontend
{
    public partial class IgrajKviz : System.Web.UI.Page
    {
        public string pitanje {
            get {
                if (Application["pitanje" + myKviiz] == null)
                {
                    Application["pitanje" + myKviiz] = "";
                }
                return (string)Application["pitanje" + myKviiz];
            }
            set {
                Application["pitanje" + myKviiz] = value;
            }
        }
        public int idIgrac {
            get {
                if (Application["idIgrac"] == null)
                {
                    Application["idIgrac"] = 0;
                }
                return (int)Application["idIgrac"];
            }
            set {
                Application["idIgrac"] = value;
            }
        }

        public DateTime pocetniDatum {
            get {
                if (Session["pocetniDatum"] == null)
                {
                    Session["pocetniDatum"] = new DateTime();
                }
                return (DateTime)Session["pocetniDatum"];
            }
            set {
                Session["pocetniDatum"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["kviz"] != null)
            {
                HttpCookie kod = Request.Cookies["kviz"];
                myKviiz = kod["kod"];
                if (!repository.CheckIfKvizIsStarted(kod["kod"]))
                    Response.Redirect("KrajKvizaIgrac.aspx");
            }


            if (pitanje != null)
            {
                PrikaziOdgovore();

            }
            if (!IsPostBack)
            {
                pocetniDatum = DateTime.Now;
            }

            int brojPitanja = repository.SelectPitanja(Kviz.IDKviz).ToList().Count;
            if (int.Parse(pitanje) == brojPitanja - 1)
            {
                Response.AppendHeader("Refresh", $"KrajKvizaIgrac.aspx");
            }
            else
            {
                Response.AppendHeader("Refresh", $"{repository.SelectPitanje(Kviz.pitanjes[int.Parse(pitanje)].IDPitanje).Trajanje};url=ShowScore.aspx?tocno=false");
            }


        }
        private static IRepository repository = RepositoryFacotry.GetRepository();

        public string lastPitanje2 {
            get {
                if (Session["lastPitanje2"] == null)
                {
                    Session["lastPitanje2"] = "";
                }
                return (string)Session["lastPitanje2"];
            }
            set {
                Session["lastPitanje2"] = value;
            }
        }

        public string myKviiz {
            get {
                if (Session["kodKviza"] == null)
                    Session["kodKviza"] = "";
                return (string)Session["kodKviza"];
            }
            set { Session["kodKviza"] = value; }
        }
        public Kviz Kviz {
            get {
                if (Application[myKviiz] == null)
                    Application[myKviiz] = new Kviz();
                return (Kviz)Application[myKviiz];
            }
            set { Application[myKviiz] = value; }
        }


        private string[] arrayImages = { "Images/RedButton.png", "Images/BlueButton.png", "Images/YellowButton.gif", "Images/GreenButton.png" };
        private void PrikaziOdgovore()
        {
            int i = 0;

            foreach (Odgovor item in repository.SelectOdgovori(Kviz.pitanjes[int.Parse(pitanje)].IDPitanje))
            {
                ImageButton btn = new ImageButton();
                btn.ID = item.IDOdgovor.ToString();
                btn.Attributes.Add("runat", "server");
                btn.ImageUrl = arrayImages[i++];
                btn.Click += Btn_Click;
                btn.Width = 250;
                btn.CommandArgument = item.IDOdgovor.ToString();
                divContainer.Controls.Add(btn);
            }

        }

        public override void Dispose()
        {
            if (btnCLikced == false)
            {
                repository.InsertBodovi(idIgrac, 0);
            }
            lastPitanje2 = pitanje;
            base.Dispose();
        }

        public bool btnCLikced { get; set; }
        private void Btn_Click(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int idOdgovor = int.Parse(btn.CommandArgument);
            Odgovor odg = repository.SelectOdgovor(idOdgovor);
            if (odg.Tocno == true)
            {
                var sekunde = (DateTime.Now - pocetniDatum).Seconds;
                btnCLikced = true;
                Pitanje p = repository.SelectPitanje(Kviz.pitanjes[int.Parse(pitanje)].IDPitanje);

                decimal brojBodova = (1 - ((Decimal.Divide(sekunde, p.Trajanje)) / 2)) * 1200;
                int bodovi = (int)Decimal.Round(brojBodova, 0);
                repository.InsertBodovi(idIgrac, bodovi);
            }
            else
            {
                repository.InsertBodovi(idIgrac, 0);
            }


            Response.Redirect($"ShowScore.aspx?tocno={odg.Tocno}&kraj={CheckIfLastQuestion()}");
        }

        private bool CheckIfLastQuestion()
        {
            if (repository.SelectPitanja(Kviz.IDKviz).Count() - 1 == int.Parse(pitanje))
            {
                return true;
            }
            return false;
        }
    }
}