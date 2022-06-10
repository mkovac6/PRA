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
    public partial class ShowScore : System.Web.UI.Page
    {
        public string rezultat {
            get {
                if (Session["rezultat"] == null)
                {
                    Session["rezultat"] = "";
                }
                return (string)Session["rezultat"];
            }
            set {
                Session["rezultat"] = value;
            }
        }
        public bool Kraj { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tocno"]!=null)
            {
                rezultat = Request.QueryString["tocno"];
            }
            else if(Request.QueryString["kraj"] != null)
            {
                if (Boolean.Parse(Request.QueryString["kraj"]))
                {
                    Response.Redirect("KrajKvizaIgrac.aspx");
                }
            }
            Label1.Text = rezultat;

            if (lastPitanje == "gotovo!")
            {
                Response.Redirect("KvizInterrupted.aspx");
            }
            
            if (lastPitanje == "gotovokviz!")
            {
                Response.Redirect("KrajKvizaIgrac.aspx");
            }

            if (lastPitanje != lastPitanje2)
            {
                Response.Redirect("IgrajKviz.aspx");

            }

            if (lastPitanje == lastPitanje2)
            {
                Response.AppendHeader("Refresh", "5;url=ShowScore.aspx");
            }
        }
        private static IRepository repository = RepositoryFacotry.GetRepository();
        public string lastPitanje {
            get {
                if (Application["pitanje"+ myKviiz] == null)
                {
                    Application["pitanje"+ myKviiz] = "";
                }
                return (string)Application["pitanje"+ myKviiz];
            }
            set {
                Application["pitanje"+ myKviiz] = value;
            }
        }
        public Kviz Kviz {
            get {
                if (Application[myKviiz] == null)
                    Application[myKviiz] = new Kviz();
                return (Kviz)Application[myKviiz];
            }
            set { Application[myKviiz] = value; }
        }

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
      
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowScore.aspx");
        }

        protected void btnOdustani_Click(object sender, EventArgs e)
        {
            Response.Redirect("KodKviza.aspx");
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
    }
}