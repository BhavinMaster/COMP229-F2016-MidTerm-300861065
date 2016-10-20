using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP229_F2016_MidTerm_300861065
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
        }

        /**
        * This method adds a css class of "active" to list items
        * relating to the current page
        * 
        * @private
        * @method SetActivePage
        * @return {void}
        */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Todo List":
                    todo.Attributes.Add("class", "active");
                    break;
                case "Login":
                    Login.Attributes.Add("class", "active");
                    break;
            }
            checkloginlogout();
        }
        public void checkloginlogout()
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Login.Visible = false;
                Logout.Visible = true;
            }
            else
            {
                Logout.Visible = false;
                Login.Visible = true;
            }
        }
    }
}