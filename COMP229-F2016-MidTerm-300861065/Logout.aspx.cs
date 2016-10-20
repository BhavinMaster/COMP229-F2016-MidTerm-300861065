using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
namespace COMP229_F2016_MidTerm_300861065
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //STore session info and authentication methods in authenticationManager object

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            //perform sign out
            authenticationManager.SignOut();

            //redirect to login page
            Response.Redirect("~/Login.aspx");
        }
    }
}