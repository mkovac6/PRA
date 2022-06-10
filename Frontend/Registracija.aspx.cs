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
    public partial class Registracija : System.Web.UI.Page
    {
        private static IRepository repository = RepositoryFacotry.GetRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public Autor Autor {
            get {
                if (Session["Autor"] == null)
                    Session["Autor"] = new Autor();
                return (Autor)Session["Autor"];
            }
            set { Session["Autor"] = value; }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;
            Autor prijavljeniAutor = new DAL.Model.Autor() { Email = txtEmail.Text, Ime = txtIme.Text, Prezime = txtPrezime.Text, Lozinka = txtLozinka.Text };
            try
            {

                    int id = repository.InsertAutor(prijavljeniAutor);
                    prijavljeniAutor.IDAutor = id;
                    Autor = prijavljeniAutor;

            }
            catch (Exception)
            {
                txtAlert.Text = "User već postoji";
                divAlert.Visible = true;
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