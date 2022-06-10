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
    public partial class IgranjeKvizaAutor : System.Web.UI.Page
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
        public Kviz KvizTrenutni { get; set; }
        public bool Start { get; set; }
        private static IRepository repository = RepositoryFacotry.GetRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

            pitanje = null;
            if (Kviz!=null)
            {
                KvizTrenutni=Kviz;
                lblKod.Text = Kviz.KodKviza;
                //repository.SetKvizZapocet(KvizTrenutni.IDKviz);
            }
            if (!Start)
            {
                RefreshPage();
                Response.AppendHeader("Refresh", "5;url=IgranjeKvizaAutor.aspx");
            }

        }

        private void RefreshPage()
        {
            foreach (Igrac item in repository.getIgraci(Kviz.KodKviza))
            {
                Label label = new Label();
                label.Text = item.Naziv+" -> "+repository.getBotovi(item.IDIgrac,Kviz.KodKviza).ToString();
                label.ID = item.IDIgrac.ToString();
                label.Width=250;
                label.CssClass = "form-control m-3";
                pHolder.Controls.Add(label);
            }
            
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

        public int kvizBroj {
            get {
                if (Session["kvizBroj"] == null)
                    Session["kvizBroj"] = 0;
                return (int)Session["kvizBroj"];
            }
            set { Session["kvizBroj"] = value; }
        }
        //applicaiton pitanje se promjenio za kviz s kodom tim i tim... uzmi novu vrijednost...
        protected void btnStart_Click(object sender, EventArgs e)
        {
            Start = true;
            pitanje = "0";
            Response.Redirect("StartKviz.aspx");
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pitanje = "done";
            Response.Redirect("PocetnaStranaAutora.aspx");
        }
    }
}