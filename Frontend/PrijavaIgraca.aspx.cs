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
    public partial class PrijavaIgraca : System.Web.UI.Page
    {
        private IRepository repository = RepositoryFacotry.GetRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["kviz"] != null)
            {

                HttpCookie kod = Request.Cookies["kviz"];
                if (!repository.CheckIfKvizIsStarted(kod["kod"]))
                    Response.Redirect("~/KodKviza.aspx");
            }
            else
            {
                Response.Redirect("~/KodKviza.aspx");
            }
            
            
        }
        public int idIgrac {
            get {
                if (Application["idIgrac"] == null)
                {
                    Application["pitanje"] = 0;
                }
                return (int)Application["idIgrac"];
            }
            set {
                Application["idIgrac"] = value;
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["kviz"] != null)
            {
                
                HttpCookie kod = Request.Cookies["kviz"];
                Kviz kviz = repository.SelectKviz(kod["kod"].ToString());
                Igrac igrac = new Igrac() { Naziv = txtUserName.Text };
              
                if (repository.getIgraci(kviz.KodKviza).ToList().Find(i=>i.Naziv==txtUserName.Text)==null)
                {
                    int IDIgrac = repository.AddIgarc(igrac);
                    repository.AddIgarcInKviz(kviz.KodKviza, IDIgrac,0);
                    idIgrac = IDIgrac;
                    Response.Cookies.Add(kod);
                    Response.Redirect("WaitOthersToJoin.aspx");  // i onda se tamo ceka da kviz pocme, a to cemo vidit preko 
                    //Applicationa ili mozda
                }
                else
                {
                    divAlert.Visible = true;
                    txtAlert.Text = "User već postoji";
                }
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