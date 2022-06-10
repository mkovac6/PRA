using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Frontend
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_EndRequest(object sender, EventArgs e)
        {      
        }
        void Application_Error(object sender, EventArgs e)
        {
            string greska = Server.GetLastError().GetBaseException().Message;
            Response.Redirect("Error.aspx?greska=" + greska);
        }

    }
}