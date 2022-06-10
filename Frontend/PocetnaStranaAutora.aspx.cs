using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class PocetnaStranaAutora : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Autor"]==null)
            {
                Response.Redirect("Prijava.aspx");
            }
            else
            {
                PrijavljeniAutor = (Autor)Session["Autor"];
                Email.Text = PrijavljeniAutor.Email;
                DataBindRepeater();
            }
            
        }
        private static IRepository repository = RepositoryFacotry.GetRepository();
        private void DataBindRepeater()
        {
            rpOdgovori.DataSource = repository.SelectKvizovi(PrijavljeniAutor.IDAutor);
            rpOdgovori.DataBind();
        }

        public Autor PrijavljeniAutor {
            get {
                if (Session["Autor"] == null)
                    Session["Autor"] = new Autor();
                return (Autor)Session["Autor"];
            }
            set { Session["Autor"] = value; }
        }

        public Kviz Kviz {
            get {
                if (Application[kod] == null)
                    Application[kod] = new Kviz();
                return (Kviz)Application[kod];
            }
            set { Application[kod] = value; }
        }
        public string kodKviza {
            get {
                if (Session["kod"] == null)
                    Session["kod"] = "";
                return (string)Session["kod"];
            }
            set { Session["kod"] = value; }
        }

        public int kvizBroj {
            get {
                if (Session["kvizBroj"] == null)
                    Session["kvizBroj"] = 0;
                return (int)Session["kvizBroj"];
            }
            set { Session["kvizBroj"] = value; }
        }
        protected void btnCreateKviz_Click(object sender, EventArgs e)
        {

            if (PrijavljeniAutor != null)
            {
                Response.Redirect("CreateKviz.aspx");
            }
        }

        protected void btnUredi_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int idKviz = int.Parse(button.CommandArgument);
            Kviz k = repository.SelectKviz(idKviz);
            kod = k.KodKviza;
            kodKviza = k.KodKviza;
            Kviz = k;
            Response.Redirect("EditKviz.aspx");
        }
        public string kod { get; set; }
        protected void btnIgraj_Click(object sender, EventArgs e)
        {
            //kod kreiranja kviza se prikazuje kod, refresha se i prikazuju se igraci
            // lista igraca se sprema
            Button btn = sender as Button;
            int idKviz = int.Parse(btn.CommandArgument);
            Kviz k = repository.SelectKviz(idKviz);
            kod = k.KodKviza;
            kodKviza = k.KodKviza;
            Kviz = k;
            List<Pitanje> pitanjes = repository.SelectPitanja(idKviz).ToList();
            foreach (Pitanje item in pitanjes)
            {
                Kviz.pitanjes.Add(item);
            }
            repository.SetKvizZapocet(idKviz);
            Frontend.Application.runningKvizovi.Add(Kviz);
            kvizBroj = Frontend.Application.runningKvizovi.Count-1;
            Response.Redirect("IgranjeKvizaAutor.aspx");
        }
        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            if (Request.Cookies["jezik"] != null)
            {
                var culture = Request.Cookies["jezik"].Value;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int idKviz = int.Parse(button.CommandArgument);
           
            repository.DeleteKivz(idKviz);
            Response.Redirect("PocetnaStranaAutora.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            if (PrijavljeniAutor != null)
            {
                PrijavljeniAutor = null;
                kodKviza = "";
                Response.Redirect("Prijava.aspx");
            }

        }

        protected void btnChangeInfo_Click(object sender, EventArgs e)
        {
            if (PrijavljeniAutor != null)
            {
                Response.Redirect("PromjernaKorisničkogRačuna.aspx");
            }
        }
    }
}