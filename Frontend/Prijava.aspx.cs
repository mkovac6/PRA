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
    public partial class Prijava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        IRepository repository = RepositoryFacotry.GetRepository();
        public Autor Autor {
            get {
                if (Session["Autor"] == null)
                    Session["Autor"] = 0;
                return (Autor)Session["Autor"];
            }
            set { Session["Autor"] = value; }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool a = repository.SelectAutorEmail_Lozinka(txtEmail.Text, txtLozinka.Text);
            if (a == true)
            {
                Autor = repository.SelectAutor(txtEmail.Text);
                divAlert.Visible = false;
                Response.Redirect("PocetnaStranaAutora.aspx");
            }
            else
            {
                txtAlert.Text = "Ne postoji takav korisnik";
                divAlert.Visible = true;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registracija.aspx");
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