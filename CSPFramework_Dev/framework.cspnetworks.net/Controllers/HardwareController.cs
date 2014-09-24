using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSPLibrary;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace framework.cspnetworks.net.Controllers
{
    public class HardwareController : Controller
    {
        //
        // GET: /Hardware/
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
                response = client.GetAsync("api/Hardware/GetHardwares").Result;
            }

            IEnumerable<NewHardwareModel> hardwares = new List<NewHardwareModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                hardwares = response.Content.ReadAsAsync<IEnumerable<NewHardwareModel>>().Result;
            }

            HardwareViewModel hardwareViewModel = new HardwareViewModel();
            hardwareViewModel.RegisteredHardwareList = hardwares;

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

            return View(hardwareViewModel);
            //return View();
        }


        public string GetHardwaresList()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.GetAsync("api/Hardware/GetHardwares").Result;
            }

            IEnumerable<NewHardwareModel> hardwares = new List<NewHardwareModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                hardwares = response.Content.ReadAsAsync<IEnumerable<NewHardwareModel>>().Result;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(hardwares);
            
        }

        [Authorize]
        public ActionResult AddNewHardware()
        {
            NewHardwareModel newHardware = new NewHardwareModel();
            return View(newHardware);
        }

        [Authorize]
        public ActionResult PostNewHardware(NewHardwareModel hardwareModel)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/Hardware/PostHardware", hardwareModel).Result;
            }

            if (response.StatusCode.Equals(HttpStatusCode.Created))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.AddHardware_Success;
                return RedirectToAction("Index", "Hardware");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;

            return RedirectToAction("Index", "Hardware");
        }

        [HttpGet]
        [Authorize]
        public ActionResult DisplayHardwareDetails(int hardwareid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/" + hardwareid);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/Hardware/GetHardware/" + hardwareid).Result;
            }

            NewHardwareModel newHardware = new NewHardwareModel();
            if (response.IsSuccessStatusCode)
            {
                newHardware = response.Content.ReadAsAsync<NewHardwareModel>().Result;
            }

            return View(newHardware);
        }

        [Authorize]
        public ActionResult GetHardwareDropdownView(string value)
        {
            NewHardwareModel newHardware = new NewHardwareModel();
            newHardware.ItemName = value;
            return PartialView("_HardwareDropDownList", newHardware);
            
        }
    
        [Authorize]
        public ActionResult EditHardware(int hardwareId)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/" + hardwareId);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/Hardware/GetHardware/" + hardwareId).Result;
            }

            NewHardwareModel hardware = new NewHardwareModel();
            if (response.IsSuccessStatusCode)
            {
                hardware = response.Content.ReadAsAsync<NewHardwareModel>().Result;
            }

            return View(hardware);
        }

        [Authorize]
        public ActionResult UpdateHardware(NewHardwareModel newHardwareModel, string returnUrl)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/Hardware/UpdateHardware", newHardwareModel).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.EditHardware_Success;
                return RedirectToAction("Index", "Hardware");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "Hardware");
        }

        [Authorize]
        public ActionResult DeleteHardware(int hardwareid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP Delete                     
                response = client.DeleteAsync("api/Hardware/DeleteHardware/" + hardwareid).Result;
            }
            if (response.IsSuccessStatusCode)
            {
                TempData[Properties.Resources.Success] = Properties.Resources.DeleteHardware_Success;
                return RedirectToAction("Index", "Hardware");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "Hardware");
        }
    }
}