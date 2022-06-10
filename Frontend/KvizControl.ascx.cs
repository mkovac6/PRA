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


    public partial class KvizControl : System.Web.UI.UserControl
    {
        public delegate void DeleteEventHandler(Pitanje pitanje);
        public event DeleteEventHandler DeletePitanje;
        public event DeleteEventHandler EditPitanje;


        public event EventHandler<Odgovor> EditOdgovor;
        public event EventHandler<Odgovor> DeleteOdgovor;
        public event EventHandler<Pitanje> ClickControl;
        protected void Page_Load(object sender, EventArgs e)
        {
           this.divContainer.Attributes.Add("ondblclick", Page.ClientScript.GetPostBackEventReference(this.divContainer, string.Empty));
           if (IsPostBack && Request["__EVENTTARGET"] == divContainer.UniqueID)
           {
               divContinaer_Click(divContainer, EventArgs.Empty);
           }
        }

        private Pitanje pitanje;
        private Odgovor odgovor;
        List<Odgovor> odgovori;
        SQLRepository sql = new SQLRepository();

        public void InItSetUp(Pitanje pitanje,List<Odgovor> odgovori)
        {
            this.pitanje = pitanje;
            this.odgovori = odgovori;
            
            DataBindRepeater(odgovori);
        }

        private void DataBindRepeater(List<Odgovor> odgovori)
        {
            lblText.Text = pitanje.Text;
            lblTrajanje.Text = pitanje.Trajanje.ToString();
            rpOdgovori.DataSource = odgovori;
            rpOdgovori.DataBind();
        }

        protected void btnUredi_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            odgovor = sql.SelectOdgovor(int.Parse(b.CommandArgument));
            EditOdgovor?.Invoke(this, odgovor);

        }

        protected void btnObrisi_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            odgovor = sql.SelectOdgovor(int.Parse(b.CommandArgument));
            DeleteOdgovor?.Invoke(this,odgovor);
        }

        protected void btnUpdatePitanje_Click(object sender, EventArgs e)
        {
            conRead.Visible = false;
            btnHolder.Visible = false;
            txtTekst.Text = lblText.Text;
            txtTrajanje.Text = lblTrajanje.Text;
            conEdit.Visible = true;

        }

        protected void btndeletePitanje_Click(object sender, EventArgs e)
        {
            DeletePitanje.Invoke(pitanje);
        }

        protected void divContinaer_Click(object sender, EventArgs e)
        {
            ClickControl?.Invoke(this, pitanje);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            pitanje.Text = txtTekst.Text;
            pitanje.Trajanje = int.TryParse(txtTrajanje.Text, out int n) == false ? 15 : int.Parse(txtTrajanje.Text);
            EditPitanje?.Invoke(pitanje);

            conEdit.Visible = false;
            lblText.Text = pitanje.Text;
            lblTrajanje.Text = pitanje.Trajanje.ToString();
            conRead.Visible = true;
            btnHolder.Visible = true;
        }
    }
}