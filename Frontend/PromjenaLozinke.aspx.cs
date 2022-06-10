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
    public partial class PromjenaLozinke : System.Web.UI.Page
    {
        public Autor PrijavljeniAutor {
            get {
                if (Session["Autor"] == null)
                    Session["Autor"] = new Autor();
                return (Autor)Session["Autor"];
            }
            set { Session["Autor"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime d;
            if (Session["time"]!=null)
            {
                d = DateTime.Parse(Session["time"].ToString());
                if (DateTime.Now.Subtract(d).Minutes>5)
                {
                    lblText.Text = "Isteklo je vrijeme."; 
                    txtLozinkaPotvrda.Visible = false;
                    txtLozinka.Visible = false;
                    btnSave.Visible = false;
                }
            }
        }




        private static IRepository repository = RepositoryFacotry.GetRepository();
        protected void btnSave_Click(object sender, EventArgs e)
        {
            repository.UpdateLozinka(PrijavljeniAutor.IDAutor,txtLozinka.Text);
        }
    }
}