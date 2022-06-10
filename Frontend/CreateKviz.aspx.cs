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
    public partial class CreateKviz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //kad se vracamo iz edit moda onda ako kviz nije prazan upisi njegov nazic

            if (IsPostBack && Session["Autor"] != null)
            {
                PrijavljeniAutor = (Autor)Session["Autor"];
            }

            if (Request.QueryString["whoCalls"] == "ja")
            {
                plc.Controls.Clear();
                if (kvizID != null)
                {
                    txtNazivKviza.Text = repository.SelectKviz(kvizID).Naziv;
                }
                regenerirajKontrole();
                divOdgovoriIPitanja.Visible = true;
            }
            else
            {


                if (IsPostBack)
                {
                    plc.Controls.Clear();
                    regenerirajKontrole();
                }
                else
                {
                    divOdgovor.Visible = false;
                }
            }
        }
        private void regenerirajKontrole()
        {

            int n = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                n = i;
                regeneriraj(i, list[i]);
                //aaa.Text = BrojPitanje.ToString();
            }
        }

        private void regeneriraj(int broj, int iDPitanje)
        {
            KvizControl cc = LoadControl("KvizControl.ascx") as KvizControl;
            cc.ID = broj.ToString();
            cc.InItSetUp(repository.SelectPitanje(iDPitanje), repository.SelectOdgovori(iDPitanje).ToList());
            cc.EditOdgovor += KvizControl_EditOdgovor;
            cc.EditPitanje -= KvizControl_EditPitanje;
            cc.DeleteOdgovor += KvizControl_DeleteOdgovor;
            cc.DeletePitanje += KvizControl_DeletePitanje;
            cc.ClickControl += Cc_ClickControl;
            plc.Controls.Add(cc);
        }

        public int broj { get; set; }
        IRepository repository = RepositoryFacotry.GetRepository();
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            Pitanje p = new Pitanje();
            if (int.TryParse(txtT.Text, out int n) && !string.IsNullOrEmpty(txtP.Text))
            {
               
                divAlert.Visible = false;
                p.Text = txtP.Text;
                p.Trajanje = int.Parse(txtT.Text);
                p.KvizID = kvizID;
                IDPitanje = repository.InsertPitanje(p);
                if (repository.SelectOdgovori(IDPitanje).Count() == 0)
                {
                    btnAdd.Enabled = false;
                }
                divOdgovor.Visible = true;
                kreirja(list.Count() - 1, IDPitanje);

            }
            else
            {
                txtAlert.Text = "Niste upisali text.";
                divAlert.Visible = true;
            }

        }

        private void kreirja(int broj, int iDPitanje)
        {
            KvizControl cc = LoadControl("KvizControl.ascx") as KvizControl;
            cc.ID = broj.ToString();
            cc.InItSetUp(repository.SelectPitanje(iDPitanje), repository.SelectOdgovori(iDPitanje).ToList());
            cc.EditOdgovor += KvizControl_EditOdgovor;
            //cc.EditPitanje += KvizControl_EditPitanje;
            cc.DeleteOdgovor += KvizControl_DeleteOdgovor;
            cc.DeletePitanje += KvizControl_DeletePitanje;
            cc.ClickControl += Cc_ClickControl;
            plc.Controls.Add(cc);
            list.Add(iDPitanje);
        }



        private void Cc_ClickControl(object sender, Pitanje e)
        {
            txtP.Text = e.Text;
            txtT.Text = e.Trajanje.ToString();
            odabranoPitanje = e.IDPitanje;
        }

        private void KvizControl_DeletePitanje(Pitanje pitanje)
        {
            repository.DeletePitanje(pitanje);
            list.Remove(list.FirstOrDefault(i => i == pitanje.IDPitanje));
            plc.Controls.Clear();
            regenerirajKontrole();

        }

        private void KvizControl_EditPitanje(Pitanje pitanje)
        {
            repository.updatePitanje(pitanje);
        }

        private void KvizControl_EditOdgovor(object sender, Odgovor e)
        {
            Response.Redirect($"Edit.aspx?id={e.IDOdgovor}&aspx=CreateQuiz");
            odabranoPitanje = 0;
        }


        private void KvizControl_DeleteOdgovor(object sender, Odgovor e)
        {
            repository.DeleteOdgovor(e.IDOdgovor);
            plc.Controls.Clear();
            regenerirajKontrole();
            // Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        public int odabranoPitanje {
            get {
                if (Session["odabraniOdgovor"] == null)
                    Session["odabraniOdgovor"] = 0;
                return (int)Session["odabraniOdgovor"];
            }
            set { Session["odabraniOdgovor"] = value; }
        }
        public int kvizID {
            get {
                if (Session["kvizID"] == null)
                    Session["kvizID"] = 1;
                return (int)Session["kvizID"];
            }
            set { Session["kvizID"] = value; }
        }

        public Autor PrijavljeniAutor {
            get {
                if (Session["PrijavljeniAutor"] == null)
                    Session["PrijavljeniAutor"] = new Autor();
                return (Autor)Session["PrijavljeniAutor"];
            }
            set { Session["PrijavljeniAutor"] = value; }
        }


        public List<int> list {
            get {
                if (Session["lista"] == null)
                    Session["lista"] = new List<int>();
                return (List<int>)Session["lista"];
            }
            set { Session["lista"] = value; }
        }

        public int IDPitanje { get; set; }

        protected void btnAddOdgovor_Click(object sender, EventArgs e)
        {

            int pitanjeID;
            if (odabranoPitanje != 0)
            {
                pitanjeID = odabranoPitanje;
            }
            else
            {
                pitanjeID = list[list.Count() - 1];
            }

            //provjera jel uopce ista napisano i jel ima smo jedan tocan odovor!!!
            //ako vec postoji tocan odg na to pitanje ne moze se to staviti checkd

            int brojOdgovora = repository.SelectOdgovori(pitanjeID).Count();
            if (!string.IsNullOrEmpty(txtOdgovor.Text) && (repository.PregledTocnihOdgovora(pitanjeID) == 0 || cbTocan.Checked == false))
            {
                btnAdd.Enabled = true;
                divAlert.Visible = false;

                if ((brojOdgovora + 1) <= 4)
                {
                    repository.InsertOdgovor(new Odgovor() { Tocno = cbTocan.Checked, Tekst = txtOdgovor.Text, PitanjeID = pitanjeID });
                    if ((brojOdgovora + 1) == 1)
                    {
                        btnAdd.Enabled = false;
                        txtAlert.Text = "Broj odgovora je manji od 2.";
                        divAlert.Visible = true;
                    }
                    btnAdd.Enabled = true; // ako postoji pitanje bez odgovora mora se kliknut add odgovor da se enable button za dodavnje pitanja
                }
                else
                {
                    if (repository.PregledTocnihOdgovora(pitanjeID) == 0)
                    {
                        btnAdd.Enabled = false;
                        txtAlert.Text = "Mora biti 1 točan odgovor.";
                        divAlert.Visible = true;
                    }
                    else if (brojOdgovora < 2)
                    {
                        txtAlert.Text = "Broj odgovora je manji od 2.";
                    }
                    else if (++brojOdgovora > 4)
                    {
                        txtAlert.Text = "Broj odgovora je veći od 4.";
                    }
                    divAlert.Visible = true;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtOdgovor.Text))
                {
                    txtAlert.Text = "Niste upisali text u odgovor!";
                }
                else
                {
                    txtAlert.Text = "Već postoji jedan točan odgovor.";
                }
                divAlert.Visible = true;
            }

            plc.Controls.Clear();
            regenerirajKontrole();
        }

        protected void btnKreirajKviz_Click(object sender, EventArgs e)
        {
            divAlert.Visible = false;

            if (!string.IsNullOrEmpty(txtNazivKviza.Text))
            {
                Kviz kviz = new Kviz()
                {
                    AutorID = PrijavljeniAutor.IDAutor,
                    Naziv = txtNazivKviza.Text,
                    VecJednomOdigran = false,
                    Aktivan = true,
                    DatumIzrade = DateTime.Now,
                };

                kvizID = repository.InsertKivz(kviz);
                divOdgovoriIPitanja.Visible = true;
            }
            else
            {
                txtAlert.Text = "Niste upisali text u naziv!";
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

        protected void btnNatrag_Click(object sender, EventArgs e)
        {
            if (repository.SelectPitanja(kvizID).Count() == 0)
            {
                repository.DeleteKivz(kvizID);
            }
            else
            {
                foreach (Pitanje item in repository.SelectPitanja(kvizID))
                {
                    if (repository.SelectOdgovori(item.IDPitanje).Count() == 0)
                    {
                        repository.DeletePitanje(repository.SelectPitanje(item.IDPitanje));
                    }
                }
            }
            Session["kvizID"] = null;
            Session["lista"] = null;
            Response.Redirect("PocetnaStranaAutora.aspx");
        }

        protected void btnSaveKviz_Click(object sender, EventArgs e)
        {
            if (repository.SelectPitanja(kvizID).Count() == 0)
            {
                repository.DeleteKivz(kvizID);
            }
            else
            {
                foreach (Pitanje item in repository.SelectPitanja(kvizID))
                {
                    if (repository.SelectOdgovori(item.IDPitanje).Count() == 0)
                    {
                        repository.DeletePitanje(repository.SelectPitanje(item.IDPitanje));
                    }
                }
            }
            Session["kvizID"] = null;
            Session["lista"] = null; 
            odabranoPitanje = 0;
        }
    }
}