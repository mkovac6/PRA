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
    public partial class StartKviz : System.Web.UI.Page
    {
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
        public string kodKviza {
            get {
                if (Session["kod"] == null)
                    Session["kod"] = "";
                return (string)Session["kod"];
            }
            set { Session["kod"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["pitanje"+ kodKviza] ==null)
            {
                Response.Redirect("");
            }
            else
            {
                PrikaziPitanje();
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

        private static IRepository repository = RepositoryFacotry.GetRepository();
        public int Trajanje { get; set; }
        private string[] arrayImages = { "Images/BlueButton.png", "Images/GreenButton.png", "Images/YellowButton.gif", "Images/RedButton.png" };
        
        private void PrikaziPitanje()
        {
            int i = 0;
            setDefaultButtons();
            Pitanje trenutnoPitanje = repository.SelectPitanje(Kviz.pitanjes[(int.Parse(pitanje))].IDPitanje);
            LabelText.Text = trenutnoPitanje.Text;
            foreach (Odgovor item in repository.SelectOdgovori(trenutnoPitanje.IDPitanje))
            {
                switch (i++)
                {
                    case 0:
                        Button0.Visible = true;
                        Button0.Text = "✭" + item.Tekst;
                        break;
                    case 1:
                        Button1.Visible = true;
                        Button1.Text = "■" + item.Tekst;
                        break;
                    case 2:
                        Button2.Visible = true;
                        Button2.Text = "●" + item.Tekst;
                        break;
                    case 3:
                        Button3.Visible = true;
                        Button3.Text = "▲" + item.Tekst;
                        break;
                }
            }
            Trajanje = trenutnoPitanje.Trajanje;
            time.Text = Trajanje.ToString();
        }

        private void setDefaultButtons()
        {
            Button1.Enabled = false;
            Button0.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;

            Button1.Visible = false;
            Button0.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;


            
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