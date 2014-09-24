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
 
    [Authorize]
    public class VendorsController : Controller
    {
        //
        // GET: /Vendors/
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
                response = client.GetAsync("api/Vendors/GetVendors").Result;
            }

            IEnumerable<NewVendorModel> vendors = new List<NewVendorModel>();

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                vendors = response.Content.ReadAsAsync<IEnumerable<NewVendorModel>>().Result;
            }

            VendorsViewModel vendorViewModel = new VendorsViewModel();
            vendorViewModel.RegisteredVendorsList = vendors;

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

            return View(vendorViewModel);         
        }

         public string GetVendorsList()
         {
             HttpResponseMessage response;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                 client.DefaultRequestHeaders.Accept.Clear();
                 //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 // HTTP POST                     
                 response = client.GetAsync("api/Vendors/GetVendors").Result;
             }

             IEnumerable<NewVendorModel> vendors = new List<NewVendorModel>();

             if (response.StatusCode.Equals(HttpStatusCode.OK))
             {
                 vendors = response.Content.ReadAsAsync<IEnumerable<NewVendorModel>>().Result;
             }

             return Newtonsoft.Json.JsonConvert.SerializeObject(vendors);

         }

         [Authorize]
         public ActionResult AddNewVendor(VendorsViewModel viewmodel, string returnUrl)
         {
             NewVendorModel model = viewmodel.NewVendorRegistrationModel;
             HttpResponseMessage response;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                 client.DefaultRequestHeaders.Accept.Clear();
                 //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 // HTTP POST                     
                 response = client.PostAsJsonAsync("api/Vendors/PostVendor", model).Result;
             }
             if (response.StatusCode.Equals(HttpStatusCode.Created))
             {
                 TempData[Properties.Resources.Success] = Properties.Resources.AddVendor_Success;
                 return RedirectToAction("Index", "Vendors");
             }

             TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
             
             return RedirectToAction("Index", "Vendors");
         }

         [Authorize]
         public ActionResult EditVendor(int vendorid)
         {
             HttpResponseMessage response;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://api.cspnetworks.net/" + vendorid);
                 client.DefaultRequestHeaders.Accept.Clear();
                 //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 // HTTP GET                     
                 response = client.GetAsync("api/Vendors/GetVendor/" + vendorid).Result;
             }

             NewVendorModel newUSer = new NewVendorModel();
             if (response.IsSuccessStatusCode)
             {
                 newUSer = response.Content.ReadAsAsync<NewVendorModel>().Result;
             }

             return View(newUSer);
         }

         [Authorize]
         public ActionResult UpdateVendor(NewVendorModel newVendorModel, string returnUrl)
         {
             HttpResponseMessage response;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                 client.DefaultRequestHeaders.Accept.Clear();
                 //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 // HTTP POST                     
                 response = client.PostAsJsonAsync("api/Vendors/UpdateVendor", newVendorModel).Result;
             }
             if (response.StatusCode.Equals(HttpStatusCode.Created))
             {
                 TempData[Properties.Resources.Success] = Properties.Resources.EditVendor_Success;
                 return RedirectToAction("Index", "Vendors");
             }

             TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
             return RedirectToAction("Index", "Vendors");
         }

         [Authorize]
         public ActionResult DisplayVendorProfile(int vendorid)
         {
             HttpResponseMessage response;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://api.cspnetworks.net/" + vendorid);
                 client.DefaultRequestHeaders.Accept.Clear();
                 //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 // HTTP GET                     
                 response = client.GetAsync("api/Vendors/GetVendor/" + vendorid).Result;
             }

             NewVendorModel newVendor = new NewVendorModel();
             if (response.IsSuccessStatusCode)
             {
                 newVendor = response.Content.ReadAsAsync<NewVendorModel>().Result;
             }

             return View(newVendor);
         }

         [Authorize]
         public ActionResult DeleteVendor(int vendorid)
         {
             HttpResponseMessage response;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("http://api.cspnetworks.net/");
                 client.DefaultRequestHeaders.Accept.Clear();
                 //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 // HTTP Delete                     
                 response = client.DeleteAsync("api/Vendors/DeleteVendor/" + vendorid).Result;
             }
             if (response.IsSuccessStatusCode)
             {
                 TempData[Properties.Resources.Success] = Properties.Resources.DeleteVendor_Success;
                 return RedirectToAction("Index", "Vendors");
             }

             TempData[Properties.Resources.Error] = Properties.Resources.Global_Error;
             return RedirectToAction("Index", "Vendors");
         }
	}
}