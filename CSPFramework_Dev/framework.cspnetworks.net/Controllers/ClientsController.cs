using CSPLibrary;
using System;
using System.Collections.Generic;
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

            NewClientModel newClient = new NewClientModel();
            if (response.IsSuccessStatusCode)
            {
                newClient = response.Content.ReadAsAsync<NewClientModel>().Result;
            }

            return View(newClient);
        }

        public ActionResult AddNewClient()
        {
            return View();
        }
	}
}