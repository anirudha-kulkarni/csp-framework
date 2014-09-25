using CSPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace framework.cspnetworks.net.Controllers
{
    public class PeopleController : Controller
    {
        //
        // GET: /People/
        [Authorize]
        public ActionResult People()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.GetAsync("api/User/GetUsers").Result;
            }

            IEnumerable<RegisteredUserModel> users = new List<RegisteredUserModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                users = response.Content.ReadAsAsync<IEnumerable<RegisteredUserModel>>().Result;
            }
            ModelState.AddModelError(string.Empty, Properties.Resources.Login_Error);
            AdminHomeViewModel adminHomeModel = new AdminHomeViewModel();
            adminHomeModel.RegisteredUserList = users;

            String status = TempData[Properties.Resources.Success] as string;
            if (status != null)
            {
                ViewBag.Status = Properties.Resources.Success;
                ViewBag.StatusMessage = status;
            }
            else
            {
                status = TempData[Properties.Resources.Error] as string;
                if (status != null)
                {
                    ViewBag.Status = Properties.Resources.Error;
                    ViewBag.StatusMessage = status;
                }
            }

            return View(adminHomeModel);
        }

        public string GetUsersList()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.GetAsync("api/User/GetUsers").Result;
            }

            IEnumerable<RegisteredUserModel> users = new List<RegisteredUserModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                users = response.Content.ReadAsAsync<IEnumerable<RegisteredUserModel>>().Result;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(users);
            
        }

        [Authorize]
        public ActionResult RegisteredCustomers()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddNewUser(AdminHomeViewModel viewmodel, string returnUrl)
        {
            NewUserModel model = viewmodel.NewUserRegistrationModel;
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/User/PostUser", model).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.Created))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.AddUser_Success;
                return RedirectToAction("People", "People");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("People", "People");
        }

        [Authorize]
        public ActionResult EditUser(int userid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/" + userid);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/User/GetUser/" + userid).Result;
            }

            NewUserModel newUSer = new NewUserModel();
            if (response.IsSuccessStatusCode)
            {
                newUSer = response.Content.ReadAsAsync<NewUserModel>().Result;
            }

            return View(newUSer);
        }

        [Authorize]
        public ActionResult UpdateUser(NewUserModel newUserModel, string returnUrl)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/User/UpdateUser", newUserModel).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.EditUser_Success;
                return RedirectToAction("People", "People");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("People", "People");
        }

        [Authorize]
        public ActionResult ChangePassword(int userid)
        {
            ChangePasswordModel model = new ChangePasswordModel();
            model.User_Id = userid;
            return View(model);
        }

        [Authorize]
        public ActionResult DisplayUserProfile(int userid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/" + userid);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/User/GetUser/" + userid).Result;
            }

            NewUserModel newUSer = new NewUserModel();
            if (response.IsSuccessStatusCode)
            {
                newUSer = response.Content.ReadAsAsync<NewUserModel>().Result;
            }

            return View(newUSer);            
        }

        [Authorize]
        public ActionResult ChangePasswordOfUser(ChangePasswordModel changePasswordModel, string returnUrl)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/User/ChangePassword", changePasswordModel).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {

                TempData[Properties.Resources.Success] = Properties.Resources.ChangePassword_Success;
                return RedirectToAction("People", "People");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("People", "People");
        }

        [Authorize]
        public ActionResult DeleteUser(int userid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP Delete                     
                response = client.DeleteAsync("api/User/DeleteUser/" + userid).Result;
            }
            if (response.IsSuccessStatusCode)
            {
                TempData[Properties.Resources.Success] = Properties.Resources.DeleteUser_Success;
                return RedirectToAction("People", "People");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("People", "People");
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