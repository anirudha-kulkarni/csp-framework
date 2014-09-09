using CSPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
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
                if (client.service_type != null)
                {
                    newClient.ServiceType = client.service_type;
                    newClient.ServiceTypeString = client.ServiceType_Enum_Type_Values.enum_type_value;
                }
                

                if(client.Agreement != null)
                {
                    newClient.AgreementStartDate = client.Agreement.start_date;
                    newClient.AgreementEndDate = client.Agreement.end_date;                    
                }

                if (client.team != null)
                {
                    newClient.Team = client.team;
                    newClient.TeamString = client.Team_Enum_Type_Values.enum_type_value;    
                }

                if (client.status != null)
                {
                    newClient.Status = client.status;
                    newClient.StatusString = client.Status_Enum_Type_Values.enum_type_value;    
                }                

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
            if (client.service_type != null)
            {
                newClient.ServiceType = client.service_type;
                newClient.ServiceTypeString = client.ServiceType_Enum_Type_Values.enum_type_value;    
            }
            

            if (client.Agreement != null)
            {
                newClient.AgreementStartDate = client.Agreement.start_date;
                newClient.AgreementEndDate = client.Agreement.end_date;
            }

            if (client.team != null)
            {
                newClient.Team = client.team;
                newClient.TeamString = client.Team_Enum_Type_Values.enum_type_value;    
            }

            if (client.status != null)
            {
                newClient.Status = client.status;
                newClient.StatusString = client.Status_Enum_Type_Values.enum_type_value;    
            }            

            newClient.Sites = client.sites;
            return Ok(newClient);
        }

        [ResponseType(typeof(Client))]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> PostNewClient(NewClientModel newClient)
        {
            Client client = new Client();
            client.client_code = newClient.Client_Code;
            client.company_name = newClient.Company_Name;
            client.address = newClient.Address;
            client.address = newClient.Address;
            client.city = newClient.City;
            client.state = newClient.State;
            client.zip = newClient.Zip;
            client.phone = newClient.PhoneNumber;
            client.mobile = newClient.MobileNumber;
            client.website = newClient.Website;
            client.service_type = newClient.ServiceType;
            
            Agreement agreement = null;
            if(newClient.AgreementStartDate != null || newClient.AgreementEndDate != null)
            {
                agreement = new Agreement();
                agreement.start_date = newClient.AgreementStartDate;
                agreement.end_date = newClient.AgreementEndDate;                
            }

            client.team = newClient.Team;
            client.status = newClient.Status;
            client.sites = newClient.Sites;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                if (agreement != null)
                {
                    _context.Agreements.Add(agreement);
                    await _context.SaveChangesAsync();
                    client.agreement_id = agreement.agreement_id;
                }
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                scope.Complete();
            }

            return CreatedAtRoute("DefaultApi", new { id = client.client_id }, client);
        }


        [HttpDelete]
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> DeleteClient(int clientid)
        {
            Client client = await _context.Clients.FindAsync(clientid);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }

        [HttpPost]
        [ResponseType(typeof(Client))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UpdateClient(NewClientModel newClient)
        {
            try
            {
                Client client = (from oldClientInfo in _context.Clients
                                 where oldClientInfo.client_id == newClient.Client_Id
                                    select oldClientInfo).FirstOrDefault();
                if (client != null)
                {

                    client.client_code = newClient.Client_Code;
                    client.company_name = newClient.Company_Name;
                    client.address = newClient.Address;
                    client.address = newClient.Address;
                    client.city = newClient.City;
                    client.state = newClient.State;
                    client.zip = newClient.Zip;
                    client.phone = newClient.PhoneNumber;
                    client.mobile = newClient.MobileNumber;
                    client.website = newClient.Website;
                    client.service_type = newClient.ServiceType;
                    
                    Agreement agreement = null;
                    if (newClient.AgreementStartDate != null || newClient.AgreementEndDate != null)
                    {
                        if (client.Agreement == null)
                        {
                            agreement = new Agreement();
                            agreement.start_date = newClient.AgreementStartDate;
                            agreement.end_date = newClient.AgreementEndDate;
                        }
                        else
                        {
                            client.Agreement.start_date = (newClient.AgreementStartDate != null) ? newClient.AgreementStartDate  : client.Agreement.start_date;
                            client.Agreement.end_date = (newClient.AgreementEndDate != null) ? newClient.AgreementEndDate : client.Agreement.end_date;
                        }
                        
                    }

                    client.team = newClient.Team;
                    client.status = newClient.Status;
                    client.sites = newClient.Sites;

                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
                    {
                        if (agreement != null)
                        {
                            _context.Agreements.Add(agreement);
                            await _context.SaveChangesAsync();
                            client.agreement_id = agreement.agreement_id;
                        }                        
                        await _context.SaveChangesAsync();
                        scope.Complete();
                    }

                    return CreatedAtRoute("DefaultApi", new { id = client.client_id }, client);
                }
                return NotFound();
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
