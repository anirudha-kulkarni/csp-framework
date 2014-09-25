using CSPLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace framework.cspnetworks.net.Controllers
{
    public class ClientsController : Controller
    {
        //
        // GET: /Clients/
        [Authorize]
        public ActionResult Index()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.GetAsync("api/Clients/GetClients").Result;
            }

            IEnumerable<NewClientModel> clients = new List<NewClientModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                clients = response.Content.ReadAsAsync<IEnumerable<NewClientModel>>().Result;
            }

            ClientsViewModel clientsViewModel = new ClientsViewModel();
            clientsViewModel.RegisteredClientsList = clients;

            String status = TempData["Success"] as string;
            if (status != null)
            {
                ViewBag.Status = "Success";
                ViewBag.StatusMessage = status;
            }
            else
            {
                status = TempData["Error"] as string;
                if (status != null)
                {
                    ViewBag.Status = "Error";
                    ViewBag.StatusMessage = status;
                }
            }

            return View(clientsViewModel);   
        }


        public string GetClientsList()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.GetAsync("api/Clients/GetClients").Result;
            }

            IEnumerable<NewClientModel> clients = new List<NewClientModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                clients = response.Content.ReadAsAsync<IEnumerable<NewClientModel>>().Result;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(clients);

        }
        [Authorize]
        public ActionResult DisplayClientProfile(int clientid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/Clients/GetClient/" + clientid).Result;
            }

            NewClientViewModel newClient = new NewClientViewModel();
            if (response.IsSuccessStatusCode)
            {
                newClient = response.Content.ReadAsAsync<NewClientViewModel>().Result;
            }

            return View(newClient);
        }

        public ActionResult AddNewClient()
        {
            return View();
        }

        public ActionResult PostNewClient(NewClientModel newClient)
        {
            // Check if there is a agreement file and save it.
            if (Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(Request.Files[0].FileName).Substring(1);
                if (fileExtension.ToLowerInvariant() == "pdf")
                {
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), Guid.NewGuid().ToString() + "." + fileExtension);

                    // Create directory only once after creating the application
                    bool isExists = System.IO.Directory.Exists(Server.MapPath("~/App_Data/uploads"));
                    if (!isExists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/App_Data/uploads"));
                    }

                    Request.Files[0].SaveAs(path);
                    newClient.AgreementPath = path;
                }
            }

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                NewClientViewModel newClientViewModel = new NewClientViewModel();
                newClientViewModel.newClientModel = new NewClientModel();
                newClientViewModel.newClientModel = newClient;
                newClientViewModel.clientSites = JsonConvert.DeserializeObject<List<ClientSite>>(newClient.Sites);

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/Clients/PostNewClient", newClientViewModel).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.Created))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.AddClient_Success;
                return RedirectToAction("Index", "Clients");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;

            return RedirectToAction("Index", "Clients");
        }

        [Authorize]
        public ActionResult DeleteClient(int clientid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP Delete                     
                response = client.DeleteAsync("api/Clients/DeleteClient?clientid=" + clientid).Result;
            }
            if (response.IsSuccessStatusCode)
            {
                TempData[Properties.Resources.Success] = Properties.Resources.DeleteClient_Success;
                return RedirectToAction("Index", "Clients");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "Clients");
        }

        public ActionResult EditClientProfile(int clientid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/Clients/GetClient/" + clientid).Result;
            }

            NewClientViewModel newClient = new NewClientViewModel();
            if (response.IsSuccessStatusCode)
            {
                newClient = response.Content.ReadAsAsync<NewClientViewModel>().Result;
            }

            return View(newClient);
        }

        public ActionResult UpdateClientProfile(NewClientViewModel newClientViewModel)
        {
            // Check if there is a agreement file and save it.
            if (Request.Files[0] != null && Request.Files[0].ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(Request.Files[0].FileName).Substring(1);
                if (fileExtension.ToLowerInvariant() == "pdf")
                {
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), Guid.NewGuid().ToString() + "." + fileExtension);

                    // Create directory only once after creating the application
                    bool isExists = System.IO.Directory.Exists(Server.MapPath("~/App_Data/uploads"));
                    if (!isExists)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/App_Data/uploads"));
                    }

                    Request.Files[0].SaveAs(path);
                    newClientViewModel.newClientModel.AgreementPath = path;
                }
            }

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST    
                newClientViewModel.clientSites = JsonConvert.DeserializeObject<List<ClientSite>>(newClientViewModel.newClientModel.Sites);
                response = client.PostAsJsonAsync("api/Clients/UpdateClient", newClientViewModel).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.EditClientr_Success;
                return RedirectToAction("Index", "Clients");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "Clients");
        }
	}
}