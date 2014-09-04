using CSPLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace admin.cspportal.com.Controllers
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
                client.BaseAddress = new Uri("http://api.cspportal.com/");
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

        [Authorize]
        public ActionResult AddNewCustomerVendor()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetFunctionView(String selectedFunction)
        {
            if (selectedFunction == "ISP")
            {
                CustomerVendorViewModelPost isp = new CustomerVendorViewModelPost();
                return PartialView("ISP", isp);
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
                if(fileExtension.ToLowerInvariant() == "pdf")
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
                client.BaseAddress = new Uri("http://api.cspportal.com/");
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
                client.BaseAddress = new Uri("http://api.cspportal.com/");
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
                client.BaseAddress = new Uri("http://api.cspportal.com/");
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

        public ActionResult EditCustomerVendorProfile(int custvendorid)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspportal.com/");
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

        public ActionResult UpdateCustomerVendorProfile(CustomerVendorViewModelPost customerVendorViewModelPost)
        {
            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.cspportal.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST                     
                response = client.PostAsJsonAsync("api/CustomerVendor/UpdateCustomerVendor", customerVendorViewModelPost).Result;
            }
            if (response.StatusCode.Equals(HttpStatusCode.Created))
            {
                TempData[Properties.Resources.Success] = Properties.Resources.EditCustomerVendor_Success;
                return RedirectToAction("Index", "CustomerVendor"); 
            }

            TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
            return RedirectToAction("Index", "CustomerVendor"); 
        }
	}
}