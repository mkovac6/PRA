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
using Utilities;

namespace Frontend
{
    public partial class PromjernaKorisničkogRačuna : System.Web.UI.Page
    {
        private static IRepository repository = new SQLRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public Autor PrijavljeniAutor {
            get {
                if (Session["Autor"] == null)
                    Session["Autor"] = new Autor();
                return (Autor)Session["Autor"];
            }
            set { Session["Autor"] = value; }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            Session["time"] = DateTime.Now;
            MailUtil.sendMail("https://localhost:44382/PromjenaLozinke.aspx",PrijavljeniAutor.Email);
        }

        protected void btnPromjeni_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtIme.Text) || !String.IsNullOrEmpty(txtPrezime.Text))
            {
                repository.UpdateAutorImeIPrezime(PrijavljeniAutor.IDAutor, txtIme.Text, txtPrezime.Text);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "AlertBox", "alert('Prazna polja')", true);
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