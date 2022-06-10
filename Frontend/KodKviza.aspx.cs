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
    public partial class KodKviza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private static IRepository repository = RepositoryFacotry.GetRepository(); 
        protected void Button1_Click(object sender, EventArgs e)
        {
        }

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

        public string myKviiz {
            get {
                if (Session["kodKviza"] == null)
                    Session["kodKviza"] = "";
                return (string)Session["kodKviza"];
            }
            set { Session["kodKviza"] = value; }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            divAlert.Visible = false;

            // moramo negdje zapisati koji su to aktivni kvizovi, odnsono kvizovi koji su zapoceli
            
            if (repository.CheckIfKvizIsStarted(txtKod.Text))
            {
                HttpCookie kuki = new HttpCookie("kviz");
                kuki["kod"] = txtKod.Text;
                kuki.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Add(kuki);
                myKviiz = kuki["kod"];
                pitanje = "";
                lblKod.Text = kuki["kod"].ToString()+"aaa";
                Response.Redirect("PrijavaIgraca.aspx");
                
            }
            else
            {
                lblKod.Text = repository.CheckIfKvizIsStarted(txtKod.Text).ToString();
                //kviz nije pokrenut
                divAlert.Visible = true;
                txtAlert.Text = "Kviz nije pokrenut!";
            }


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