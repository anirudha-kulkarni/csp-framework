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
    [Authorize]
    public class CustomerVendorController : Controller
    {
        //
        // GET: /CustomerVendor/
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
                response = client.GetAsync("api/CustomerVendor/GetCustomerVendors").Result;
            }

            IEnumerable<NewCustomerVendorModel> custVendors = new List<NewCustomerVendorModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                custVendors = response.Content.ReadAsAsync<IEnumerable<NewCustomerVendorModel>>().Result;
            }

            CustomerVendorViewModel custVendorViewModel = new CustomerVendorViewModel();
            custVendorViewModel.RegisteredCustomerVendorList = custVendors;

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

            return View(custVendorViewModel);
        }

        public string GetCustomerVendorsList()
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.GetAsync("api/CustomerVendor/GetCustomerVendors").Result;
            }

            IEnumerable<NewCustomerVendorModel> custVendors = new List<NewCustomerVendorModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                custVendors = response.Content.ReadAsAsync<IEnumerable<NewCustomerVendorModel>>().Result;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(custVendors);

        }

        [Authorize]
        public ActionResult AddNewCustomerVendor()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetFunctionView(String selectedFunction)
        {
            switch (selectedFunction)
            {
                case "Application":
                    Fun_Application application = new Fun_Application();
                    return PartialView("_Fun_Application", application);

                case "Fax":
                    Fun_Fax funFax = new Fun_Fax();
                    return PartialView("_Fun_Fax", funFax);

                case "Phone System":
                    Fun_Phone_System funPhoneSys = new Fun_Phone_System();
                    return PartialView("_Fun_Phone_System", funPhoneSys);

                case "Connectivity - Phone":
                    Fun_Connectivity_Phone funConnPhone = new Fun_Connectivity_Phone();
                    return PartialView("_Fun_Connectivity_Phone", funConnPhone);

                case "Cloud":
                    Fun_Cloud funCloud = new Fun_Cloud();
                    return PartialView("_Fun_Cloud", funCloud);

                case "Connectivity - Internet":
                    Fun_Connectivity_Internet funConnInt = new Fun_Connectivity_Internet();
                    return PartialView("_Fun_Connectivity_Internet", funConnInt);

                case "Printer":
                    Fun_Printer funPrinter = new Fun_Printer();
                    return PartialView("_Fun_Printer", funPrinter);

                default:
                    break;
            }
            return Content("");
        }

        [Authorize]
        public ActionResult PostNewCustomerVendor(CustomerVendorViewModelPost customerVendorViewModelPost)
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
                    customerVendorViewModelPost.newCustomerVendorModel.AgreementPath = path;
                }
            }


            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/CustomerVendor/PostNewCustomerVendor", customerVendorViewModelPost).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.Created))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.AddCutomerVendor_Success;
                return RedirectToAction("Index", "CustomerVendor");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "CustomerVendor");
        }

        [Authorize]
        public ActionResult DisplayCustomerVendorProfile(int custvendorid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/CustomerVendor/GetCustomerVendor?custvendorid=" + custvendorid).Result;
            }

            CustomerVendorViewModelPost newCustomerVendor = new CustomerVendorViewModelPost();
            if (response.IsSuccessStatusCode)
            {
                newCustomerVendor = response.Content.ReadAsAsync<CustomerVendorViewModelPost>().Result;
            }
            return View(newCustomerVendor);
        }

        [Authorize]
        public ActionResult DeleteCustomerVendor(int custvendorid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP Delete                     
                response = client.DeleteAsync("api/CustomerVendor/DeleteCustomerVendor?custvendorid=" + custvendorid).Result;
            }
            if (response.IsSuccessStatusCode)
            {
                TempData[Properties.Resources.Success] = Properties.Resources.DeleteCutomerVendor_Success;
                return RedirectToAction("Index", "CustomerVendor");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "CustomerVendor");
        }

        [Authorize]
        public ActionResult EditCustomerVendorProfile(int custvendorid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET                     
                response = client.GetAsync("api/CustomerVendor/GetCustomerVendor?custvendorid=" + custvendorid).Result;
            }

            CustomerVendorViewModelPost newCustomerVendor = new CustomerVendorViewModelPost();
            if (response.IsSuccessStatusCode)
            {
                newCustomerVendor = response.Content.ReadAsAsync<CustomerVendorViewModelPost>().Result;
            }

            return View(newCustomerVendor);
        }

        [Authorize]
        public ActionResult UpdateCustomerVendorProfile(CustomerVendorViewModelPost customerVendorViewModelPost)
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
                    customerVendorViewModelPost.newCustomerVendorModel.AgreementPath = path;
                }
            }

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/CustomerVendor/UpdateCustomerVendor", customerVendorViewModelPost).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.EditCustomerVendor_Success;
                return RedirectToAction("Index", "CustomerVendor");
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "CustomerVendor");
        }
        [Authorize]
        public ActionResult GetSitesView(int id)
        {
            Site_LocationModel siteModel = new Site_LocationModel();
            siteModel.client_id = id;
            siteModel.site_id = 0;
            return PartialView("_Site_List_Partial", siteModel);
        }
    }
}