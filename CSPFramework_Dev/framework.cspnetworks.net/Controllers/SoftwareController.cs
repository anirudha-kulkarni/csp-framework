using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSPLibrary;
using System.Net.Http;
using System.Net;


namespace framework.cspnetworks.net.Controllers
{
    public class SoftwareController : Controller
    {

        HttpResponseMessage response;
        private const string baseAddress= "http://api.cspnetworks.net/";

        //
        // GET: /Software/
        // It will be used to display list of all softwares
        [Authorize]
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();

                // HTTP POST                     
                response = client.GetAsync("api/Software/GetSoftwares").Result;
            }

            IEnumerable<NewSoftwareModel> softwares = new List<NewSoftwareModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                softwares = response.Content.ReadAsAsync<IEnumerable<NewSoftwareModel>>().Result;
            }

            SoftwareViewModel softwareViewModel = new SoftwareViewModel();
            softwareViewModel.RegisteredSoftwareList = softwares;

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

            return View(softwareViewModel);
        }

        public string GetSoftwaresList()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.GetAsync("api/Software/GetSoftwares").Result;
            }

            IEnumerable<NewSoftwareModel> softwares = new List<NewSoftwareModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                softwares = response.Content.ReadAsAsync<IEnumerable<NewSoftwareModel>>().Result;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(softwares);

        }

        [Authorize]
        public ActionResult AddNewSoftware()
        {
            NewSoftwareModel newSoftware = new NewSoftwareModel();
            return View(newSoftware);
        }

        [Authorize]
        public ActionResult PostNewSoftware(NewSoftwareModel newSoftware)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/Software/PostSoftware", newSoftware).Result;
            }

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.AddSoftware_Success;
                return RedirectToAction("Index", "Software");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "Software");
        }

        [HttpGet]
        [Authorize]
        public ActionResult DisplaySoftwareDetails(int softwareid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress + softwareid);
                client.DefaultRequestHeaders.Accept.Clear();

                // HTTP GET                     
                response = client.GetAsync("api/Software/GetSoftware/" + softwareid).Result;
            }

            NewSoftwareModel newSoftware = new NewSoftwareModel();
            if (response.IsSuccessStatusCode)
            {
                newSoftware = response.Content.ReadAsAsync<NewSoftwareModel>().Result;
            }

            return View(newSoftware);
        }

        [Authorize]
        public ActionResult EditSoftware(int softwareid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress + softwareid);
                client.DefaultRequestHeaders.Accept.Clear();

                // HTTP GET                     
                response = client.GetAsync("api/Software/GetSoftware/" + softwareid).Result;
            }

            NewSoftwareModel software = new NewSoftwareModel();
            if (response.IsSuccessStatusCode)
            {
                software = response.Content.ReadAsAsync<NewSoftwareModel>().Result;
            }

            return View(software);
        }

        [Authorize]
        public ActionResult UpdateSoftware(NewSoftwareModel newSoftwareModel, string returnUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/Software/UpdateSoftware", newSoftwareModel).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.EditSoftware_Success;
                return RedirectToAction("Index", "Software");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "Software");
        }

        [Authorize]
        public ActionResult DeleteSoftware(int softwareid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();

                // HTTP Delete                     
                response = client.DeleteAsync("api/Software/DeleteSoftware/" + softwareid).Result;
            }
            if (response.IsSuccessStatusCode)
            {
                TempData[Properties.Resources.Success] = Properties.Resources.DeleteSoftware_Success;
                return RedirectToAction("Index", "Software");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "Software");
        }
    }
}