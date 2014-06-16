﻿namespace BulletinReader
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;

    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/")
                }
            );

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}
