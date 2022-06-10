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
    public partial class WaitOthersToJoin : System.Web.UI.Page
    {
        public string pitanje {
            get {
                if (Application["pitanje"+ myKviiz] == null)
                {
                    Application["pitanje"+ myKviiz] = "";
                }
                return (string)Application["pitanje"+ myKviiz];
            }
            set {
                Application["pitanje"+ myKviiz] = value;
            }
        }

        public string myKviiz {
            get {
                if (Session["kodKviza"] == null)
                    Session["kodKviza"] = "";
                return (string)Session["kodKviza"];
            }
            set { Session["kodKviza"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["kviz"] != null)
            {
                HttpCookie kod = Request.Cookies["kviz"];
                myKviiz = kod["kod"];
            }
            if (string.IsNullOrEmpty(pitanje))
            {
                Response.AppendHeader("Refresh", "5;url=WaitOthersToJoin.aspx");
            }
            else if (pitanje=="done")
            {
                Response.Redirect("KvizInterrupted.aspx");
            }
            else
            {
                Response.Redirect("IgrajKviz.aspx");
            }
        }

        protected void btnRefreshPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("WaitOthersToJoin.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // dal moram izbaciti usera iz liste igraca ili ne
            Response.Redirect("KodKviza.aspx");
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