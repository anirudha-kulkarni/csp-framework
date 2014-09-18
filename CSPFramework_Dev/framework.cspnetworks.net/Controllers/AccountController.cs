using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web.Security;
using System.Net.Http;
using CSPLibrary;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using framework.cspnetworks.net.Helpers;

namespace framework.cspnetworks.net.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
              //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                 return RedirectToAction("People", "People");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    LoginModel loginModel = new LoginModel();
                    loginModel.userLoginModel = model;

                    // HTTP POST                     
                    response = client.PostAsJsonAsync("api/User/AuthUser", loginModel).Result;
                }

                Boolean isValid = (response.StatusCode.Equals(HttpStatusCode.OK) && 
                    !response.StatusCode.Equals(HttpStatusCode.Unauthorized));
                if (isValid)
                {
                    //FormsAuthentication.SetAuthCookie(model.EmailAddress, false);
                    int coockieExpires;
                    int sessionTimeout;
                    var ip = Request.UserHostAddress;
                    
                    if (ip == ConfigHelper.InternalIPAddress)
                    {
                        coockieExpires = ConfigHelper.InternalExpiration;
                        sessionTimeout = ConfigHelper.InternalSessionExpiration;
                    }
                    else
                    {
                        coockieExpires = ConfigHelper.ExternalExpiration;
                        sessionTimeout = ConfigHelper.ExternalSessionExpiration;
                    }

                    Session.Add("User", model.EmailAddress);
                    Session.Timeout = sessionTimeout;

                    var ticket = new FormsAuthenticationTicket(0,
                                       model.EmailAddress,
                                       DateTime.Now,
                                       DateTime.Now.AddMinutes(coockieExpires),
                                       true,
                                       "",
                                       FormsAuthentication.FormsCookiePath);

                    string encryptedCookieContent = FormsAuthentication.Encrypt(ticket);

                    var formsAuthenticationTicketCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookieContent)
                    {
                        Domain = FormsAuthentication.CookieDomain,
                        Path = FormsAuthentication.FormsCookiePath,
                        HttpOnly = true,
                        Secure = FormsAuthentication.RequireSSL
                    };

                    formsAuthenticationTicketCookie.Expires = DateTime.Now.AddMinutes(coockieExpires);
                    System.Web.HttpContext.Current.Response.Cookies.Add(formsAuthenticationTicketCookie);

                    return RedirectToAction("People", "People");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login. Please check your credentials, or contact your administrator.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

      
        
        public void Logout(UserLoginModel model, string returnUrl)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            FormsAuthentication.RedirectToLoginPage();
        }
    }
}