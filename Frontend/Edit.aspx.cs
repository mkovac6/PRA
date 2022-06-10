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
    public partial class Edit : System.Web.UI.Page
    {
        private static IRepository repository = RepositoryFacotry.GetRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("EditKviz.aspx");
            }
            if (!IsPostBack)
            {
                ShowQestion(id);
            }
        }

        private void ShowQestion(string id)
        {
            var odgovor = repository.SelectOdgovor(int.Parse(id));
            txtTekst.Text = odgovor.Tekst;
            RadioButtonList1.SelectedValue = odgovor.Tocno ? "true" : "false";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var id = int.Parse(Request.QueryString["id"]);
            // provjera ipak treba biti

            var pItanjeID = repository.SelectOdgovor(id).PitanjeID;
            var updateOdgovor = new Odgovor
            {
                IDOdgovor = id,
                PitanjeID = pItanjeID,
                Tekst = txtTekst.Text,
                Tocno = Boolean.Parse(RadioButtonList1.SelectedValue)
            };

            if (updateOdgovor.Tocno == true && repository.PregledTocnihOdgovora(pItanjeID) == 0)
            {
                repository.UpdateOdgovor(updateOdgovor.IDOdgovor, updateOdgovor.PitanjeID, updateOdgovor.Tekst, updateOdgovor.Tocno);
                RedirectMethid();
            }
            else if (updateOdgovor.Tocno == false && repository.PregledTocnihOdgovora(pItanjeID) >= 1)
            {
                repository.UpdateOdgovor(updateOdgovor.IDOdgovor, updateOdgovor.PitanjeID, updateOdgovor.Tekst, updateOdgovor.Tocno);
                RedirectMethid();
            }
            else if (updateOdgovor.Tocno == true && repository.PregledTocnihOdgovora(pItanjeID) >= 1)
            {
                divAlert.Visible = true;
                txtAlert.Text = "Već postoji tocan odgovor za ovo pitajne.";
            }
            else
            {
                repository.UpdateOdgovor(updateOdgovor.IDOdgovor, updateOdgovor.PitanjeID, updateOdgovor.Tekst, updateOdgovor.Tocno);
                RedirectMethid();
            }
           

        }

        private void RedirectMethid()
        {
            if (Request.QueryString["aspx"] != null && Request.QueryString["aspx"].ToString() == "CreateQuiz")
            {
                Response.Redirect("CreateKviz.aspx?whoCalls=ja");
            }
            else
            {
                Response.Redirect("EditKviz.aspx");
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