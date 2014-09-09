using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.cspnetworks.net.Controllers
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
            IQueryable<User_Groups> userGroups = _context.User_Groups;
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
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Status_Types"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                   where values.enum_type_id == enumType.enum_type_id
                                                   select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }            
            return null;
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
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Functions"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                   where values.enum_type_id == enumType.enum_type_id
                                                   select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;            
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

        public Dictionary<String, String> GetTeamList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "CSP_Teams"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetClientServices()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "CSP_Services"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }
    }
}
