using CSPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace api.cspnetworks.net.Controllers
{
    public class ClientsController : ApiController
    {
        private CSPFRAMEWORKEntities _context;

        public ClientsController()
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

        // GET api/Clients/GetClients
        [HttpGet]
        public List<NewClientModel> GetClients()
        {
            IQueryable<Client> clients = _context.Clients;
            List<NewClientModel> regClients = new List<NewClientModel>();
            foreach (Client client in clients)
            {
                NewClientModel newClient = new NewClientModel();

                newClient.Client_Id = client.client_id;
                newClient.Client_Code = client.client_code;
                newClient.Company_Name = client.company_name;
                newClient.Address = client.address;
                newClient.City = client.city;
                newClient.State = client.state;
                newClient.Zip = client.zip;
                newClient.PhoneNumber = client.phone;
                newClient.MobileNumber = client.mobile;
                newClient.Website = client.website;
                newClient.ServiceType = client.service_type;
                newClient.ServiceTypeString = client.Enum_Type_Values.enum_type_value;

                if(client.Agreement != null)
                {
                    newClient.AgreementStartDate = client.Agreement.start_date;
                    newClient.AgreementEndDate = client.Agreement.end_date;                    
                }

                newClient.Team = client.team;
                newClient.TeamString = client.Enum_Type_Values1.enum_type_value;

                newClient.Status = client.status;
                newClient.StatusString = client.Enum_Type_Values2.enum_type_value;

                newClient.Sites = client.sites;
                
                regClients.Add(newClient);
            }
            return regClients;
        }

        // GET api/Vendors/GetVendor/5
        [ResponseType(typeof(NewClientModel))]
        [HttpGet]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            NewClientModel newClient = new NewClientModel();
            newClient.Client_Id = client.client_id;
            newClient.Client_Code = client.client_code;
            newClient.Company_Name = client.company_name;
            newClient.Address = client.address;
            newClient.City = client.city;
            newClient.State = client.state;
            newClient.Zip = client.zip;
            newClient.PhoneNumber = client.phone;
            newClient.MobileNumber = client.mobile;
            newClient.Website = client.website;
            newClient.ServiceType = client.service_type;
            newClient.ServiceTypeString = client.Enum_Type_Values.enum_type_value;

            if (client.Agreement != null)
            {
                newClient.AgreementStartDate = client.Agreement.start_date;
                newClient.AgreementEndDate = client.Agreement.end_date;
            }

            newClient.Team = client.team;
            newClient.TeamString = client.Enum_Type_Values1.enum_type_value;

            newClient.Status = client.status;
            newClient.StatusString = client.Enum_Type_Values2.enum_type_value;

            newClient.Sites = client.sites;
            return Ok(newClient);
        }
    }
}
