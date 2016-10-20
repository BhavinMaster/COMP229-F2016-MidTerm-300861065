using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

//required for owin startup
using Microsoft.AspNet.Identity;    //authorisation
using Microsoft.Owin.Security.Cookies; //use owin

[assembly: OwinStartup(typeof(COMP229_F2016_MidTerm_300861065.Models.Startup))]

namespace COMP229_F2016_MidTerm_300861065.Models
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login.aspx")
            });
        }
    }
}
