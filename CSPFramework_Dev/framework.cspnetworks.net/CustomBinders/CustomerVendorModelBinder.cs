using CSPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace framework.cspnetworks.net.CustomBinders
{
    public class CustomerVendorModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(CustomerVendorViewModelPost))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                CustomerVendorViewModelPost newModel = new CustomerVendorViewModelPost();
                newModel.newCustomerVendorModel = new NewCustomerVendorModel();
                newModel.newCustomerVendorModel.Customer_Vendor_Id = Parse<int>(request.Form.Get("newCustomerVendorModel.Customer_Vendor_Id"));
                newModel.newCustomerVendorModel.Vendor_Id = Parse<int>(request.Form.Get("newCustomerVendorModel.Vendor_Id"));
                newModel.newCustomerVendorModel.VendorName = request.Form.Get("newCustomerVendorModel.VendorName");
                newModel.newCustomerVendorModel.Account = request.Form.Get("newCustomerVendorModel.Account");
                newModel.newCustomerVendorModel.Function = Parse<int>(request.Form.Get("newCustomerVendorModel.Function"));
                newModel.newCustomerVendorModel.FunctionString = request.Form.Get("newCustomerVendorModel.FunctionString");

                newModel.iFunction = GetFunctionNotes(request, newModel.newCustomerVendorModel.FunctionString);

                newModel.newCustomerVendorModel.L1UserName = request.Form.Get("newCustomerVendorModel.L1UserName");
                newModel.newCustomerVendorModel.L1Password = request.Form.Get("newCustomerVendorModel.L1Password");

                newModel.newCustomerVendorModel.L2UserName = request.Form.Get("newCustomerVendorModel.L2UserName");
                newModel.newCustomerVendorModel.L2Password = request.Form.Get("newCustomerVendorModel.L2Password");

                newModel.newCustomerVendorModel.AgreementPath = request.Form.Get("newCustomerVendorModel.AgreementPath");
                if (String.IsNullOrEmpty(request.Form.Get("newCustomerVendorModel.AgreementStartDate")))
                {
                    newModel.newCustomerVendorModel.AgreementStartDate = null;    
                }
                else
                {
                    newModel.newCustomerVendorModel.AgreementStartDate = DateTime.Parse(request.Form.Get("newCustomerVendorModel.AgreementStartDate"));
                }

                if (String.IsNullOrEmpty(request.Form.Get("newCustomerVendorModel.AgreementEndDate")))
                {
                    newModel.newCustomerVendorModel.AgreementEndDate = null;
                }
                else
                {
                    newModel.newCustomerVendorModel.AgreementEndDate = DateTime.Parse(request.Form.Get("newCustomerVendorModel.AgreementEndDate"));
                }
                
                newModel.newCustomerVendorModel.Status = Parse<int>(request.Form.Get("newCustomerVendorModel.Status"));
                newModel.newCustomerVendorModel.StatusString = request.Form.Get("newCustomerVendorModel.StatusString");

                newModel.newCustomerVendorModel.Client_Id = Parse<int>(request.Form.Get("newCustomerVendorModel.Client_Id"));
                newModel.newCustomerVendorModel.ClientCode = request.Form.Get("newCustomerVendorModel.ClientCode");
                newModel.newCustomerVendorModel.Site = request.Form.Get("newCustomerVendorModel.Site");

                return newModel;              
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }

        private Object GetFunctionNotes(HttpRequestBase request, string functionName)
        {
            Object iFunction = null;
            switch (functionName)
            {
                case "Application":
                    Fun_Application application = new Fun_Application();
                    application.App_IP_Address = request.Form.Get("App_IP_Address");
                    application.App_Login_Url = request.Form.Get("App_Login_Url");
                    application.App_Management_Url = request.Form.Get("App_Management_Url");
                    application.App_Solution = request.Form.Get("App_Solution");
                    iFunction = application;
                    break;

                case "Fax":
                    Fun_Fax funFax = new Fun_Fax();
                    funFax.Fax_Solution = request.Form.Get("Fax_Solution");
                    funFax.Fax_Number = request.Form.Get("Fax_Number");
                    funFax.Fax_Management_Url = request.Form.Get("Fax_Management_Url");
                    iFunction = funFax;
                    break;

                case "Phone System":
                    Fun_Phone_System funPhoneSys = new Fun_Phone_System();
                    funPhoneSys.Phone_Sys_Solution = request.Form.Get("Phone_Sys_Solution");
                    funPhoneSys.Phone_Sys_IP_Address = request.Form.Get("Phone_Sys_IP_Address");
                    funPhoneSys.Phone_Sys_Management_Url = request.Form.Get("Phone_Sys_Management_Url");
                    iFunction = funPhoneSys;
                    break;

                case "Connectivity - Phone":
                    Fun_Connectivity_Phone funConnPhone = new Fun_Connectivity_Phone();
                    funConnPhone.Conn_Phone_Solution = request.Form.Get("Conn_Phone_Solution");
                    funConnPhone.Conn_Phone_Phone_Number = request.Form.Get("Conn_Phone_Phone_Number");
                    funConnPhone.Conn_Phone_Management_Url = request.Form.Get("Conn_Phone_Management_Url");
                    iFunction = funConnPhone;
                    break;

                case "Cloud":
                    Fun_Cloud funCloud = new Fun_Cloud();
                    funCloud.Cloud_Solution = request.Form.Get("Cloud_Solution");
                    funCloud.Cloud_IP_Address = request.Form.Get("Cloud_IP_Address");
                    funCloud.Cloud_Management_Url = request.Form.Get("Cloud_Management_Url");
                    iFunction = funCloud;
                    break;

                case "Connectivity - Internet":
                    Fun_Connectivity_Internet funConnInt = new Fun_Connectivity_Internet();
                    funConnInt.Conn_Int_Solution = request.Form.Get("Conn_Int_Solution");
                    funConnInt.Conn_Int_Connectivity = request.Form.Get("Conn_Int_Connectivity");
                    funConnInt.Conn_Int_Wan_IP_Address = request.Form.Get("Conn_Int_Wan_IP_Address");
                    funConnInt.Conn_Int_SubnetMask = request.Form.Get("Conn_Int_SubnetMask");
                    funConnInt.Conn_Int_DNS1 = request.Form.Get("Conn_Int_DNS1");
                    funConnInt.Conn_Int_DNS2 = request.Form.Get("Conn_Int_DNS2");
                    funConnInt.Conn_Int_Wan_IPs = request.Form.Get("Conn_Int_Wan_IPs");
                    funConnInt.Conn_Int_Management_Url = request.Form.Get("Conn_Int_Management_Url");
                    iFunction = funConnInt;
                    break;

                case "Printer":
                    Fun_Printer funPrinter = new Fun_Printer();
                    funPrinter.Printer_Solution = request.Form.Get("Printer_Solution");
                    funPrinter.Printer_IP_Address = request.Form.Get("Printer_IP_Address");
                    funPrinter.Printer_Management_Url = request.Form.Get("Printer_Management_Url");
                    iFunction = funPrinter;
                    break;

                default:
                    break;               
            }
            return iFunction;
        }

        public T Parse<T>(string val) where T : struct
        {
            if (String.IsNullOrEmpty(val))
            {
                return default(T);
            }
            return (T)System.Convert.ChangeType(val, Type.GetTypeCode(typeof(T)));
        }      
    }
}