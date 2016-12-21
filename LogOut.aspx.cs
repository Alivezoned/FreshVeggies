using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreshVeggies.Class;

namespace FreshVeggies
{
    public partial class LogOut : System.Web.UI.Page
    {
        SourceStrings s = new SourceStrings();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session[s.SessionUser] = null;
                Session[s.SessionPass] = null;
                Response.Redirect("Index.aspx");
            }
            catch (Exception) { }
        }
    }
}