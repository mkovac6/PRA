using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace Frontend
{
    public partial class TriOdabira : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void JezikChange(object sender, EventArgs e)
        {
            HttpCookie kuki = new HttpCookie("jezik");
            kuki.Value = ddlJezik.SelectedValue;
            Response.Cookies.Add(kuki);

            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            if (Request.Cookies["jezik"]!=null)
            {
                var culture = Request.Cookies["jezik"].Value;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }
        }
    }
}