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
    public partial class KrajKviza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowPlayers();
            repository.SetKvizNijeZapocet(Kviz.IDKviz);
            repository.SetKvizVecJednomOdigran(Kviz.IDKviz);
        }
        private static IRepository repository = RepositoryFacotry.GetRepository();
        private void ShowPlayers()
        {
            foreach (Igrac item in repository.getIgraci(Kviz.KodKviza))
            {
                Label label = new Label();
                label.Text = item.Naziv + " -> " + repository.getBotovi(item.IDIgrac, Kviz.KodKviza).ToString();
                label.ID = item.IDIgrac.ToString();
                label.Width = 200;
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

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReturnToAutor.aspx");
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