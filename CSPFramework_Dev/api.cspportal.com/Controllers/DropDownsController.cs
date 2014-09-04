using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.cspportal.com.Controllers
{
    public class DropDownsController : ApiController
    {
         private CSPFRAMEWORKEntities _context;

         public DropDownsController()
        {
            _context = new CSPFRAMEWORKEntities();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET api/DropDowns/GetUserGroups
        [HttpGet]
        public Dictionary<String, String> GetUserGroups()
        {
            IQueryable<UserGroup> userGroups = _context.UserGroups;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            foreach (var userGroup in userGroups)
            {
                dictionary.Add(userGroup.user_group, userGroup.user_group);
            }
            return dictionary;
        }

        [HttpGet]
        public Dictionary<String, String> GetUserStatus()
        {
            IQueryable<Status_Types> statusTypes = _context.Status_Types;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            foreach (var item in statusTypes)
            {
                dictionary.Add(item.status, item.status);
            }
            return dictionary;
        }

        [HttpGet]
        public Dictionary<String, String> GetCustomers()
        {
            IQueryable<Client> clients = _context.Clients;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            foreach (var item in clients)
            {
                dictionary.Add(item.company_name + " (" + item.client_code + ")", item.client_id.ToString());
            }
            return dictionary;
        }

        public Dictionary<String, String> GetFunctions()
        {
            IQueryable<Function> functions = _context.Functions;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            foreach (var item in functions)
            {
                dictionary.Add(item.function_name, item.function_name);
            }
            return dictionary;
        }

        public Dictionary<String, String> GetVendorsList()
        {
            IQueryable<Vendor> vendors = _context.Vendors;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            foreach (var item in vendors)
            {
                dictionary.Add(item.name, item.vendor_id.ToString());
            }
            return dictionary;
        }
    }
}
