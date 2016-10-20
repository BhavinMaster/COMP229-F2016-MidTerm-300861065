using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for identity and owin security

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace COMP229_F2016_MidTerm_300861065
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
    }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // create new userStore and userManager objects

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // Search for and create a new user object

            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            // if match is found for the user

            if (user != null)
            {
                //authenticate and login the user
                var autheticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //ign in the user
                autheticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                Response.Redirect("~/Default.aspx");

            }
            else
            {
                StatusLabel.Text = "Invalid uname and password";
                AlertFlash.Visible = true;
            }

        }
    }
}