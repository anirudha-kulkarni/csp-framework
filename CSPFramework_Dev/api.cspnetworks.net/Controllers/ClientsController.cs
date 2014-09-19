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
                //newClient.MobileNumber = client.mobile;
                newClient.Company_Name = client.company_name;
                newClient.Website = client.website;                
                if (client.service_type != null)
                {
                    newClient.ServiceType = client.service_type;
                    newClient.ServiceTypeString = client.ServiceType_Enum_Type_Values.enum_type_value;
                }


                if (client.Agreement != null)
                {
                    newClient.AgreementStartDate = client.Agreement.start_date;
                    newClient.AgreementPath = client.Agreement.filepath;                }

                if (client.team != null)
                {
                    newClient.Team = client.team;
                    newClient.TeamString = client.Team_Enum_Type_Values.enum_type_value;                       
                }
               if (client.program_manager != null) {
                    newClient.programManager = client.program_manager;
                    newClient.programManagerString = client.Program_Manager_User.firstname;
                }
                if (client.account_manager != null)
                {
                    newClient.accountManager = client.account_manager;
                    newClient.accountManagerString = client.Account_Manager_User.firstname;  
                }
                if (client.PAM_manager != null) {
                    newClient.pamManager = client.PAM_manager;
                    newClient.pamManagerString = client.PAM_Manager_User.firstname;
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
        [ResponseType(typeof(NewClientViewModel))]
        [HttpGet]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            NewClientViewModel newClient = new NewClientViewModel();
            newClient.newClientModel = new NewClientModel();
            newClient.newClientModel.Client_Id = client.client_id;
            newClient.newClientModel.Client_Code = client.client_code;
            newClient.newClientModel.Company_Name = client.company_name;
            //newClient.Address = client.address;
            //newClient.City = client.city;
            //newClient.State = client.state;
            //newClient.Zip = client.zip;
            //newClient.PhoneNumber = client.phone;
            //newClient.MobileNumber = client.mobile;
            newClient.newClientModel.Website = client.website;
            if (client.service_type != null)
            {
                newClient.newClientModel.ServiceType = client.service_type;
                newClient.newClientModel.ServiceTypeString = client.ServiceType_Enum_Type_Values.enum_type_value;
            }


            if (client.Agreement != null)
            {
                newClient.newClientModel.AgreementStartDate = client.Agreement.start_date;
                newClient.newClientModel.AgreementEndDate = client.Agreement.end_date;
                newClient.newClientModel.AgreementPath = client.Agreement.filepath;
            }

            if (client.team != null)
            {
                newClient.newClientModel.Team = client.team;
                newClient.newClientModel.TeamString = client.Team_Enum_Type_Values.enum_type_value;
            }
            if (client.executive_incharge != null)
            {
                newClient.newClientModel.executiveIncharge = client.executive_incharge;
                newClient.newClientModel.executiveInchargeString = client.Executive_Incharge_User.firstname;
            }
            if (client.program_manager != null)
            {
                newClient.newClientModel.programManager = client.program_manager;
                newClient.newClientModel.programManagerString = client.Program_Manager_User.firstname;
            }
            if (client.account_manager != null)
            {
                newClient.newClientModel.accountManager = client.account_manager;
                newClient.newClientModel.accountManagerString = client.Account_Manager_User.firstname;
            }
            if (client.PAM_manager != null)
            {
                newClient.newClientModel.pamManager = client.PAM_manager;
                newClient.newClientModel.pamManagerString = client.PAM_Manager_User.firstname;
            }
            if (client.status != null)
            {
                newClient.newClientModel.Status = client.status;
                newClient.newClientModel.StatusString = client.Status_Enum_Type_Values.enum_type_value;
            }

            newClient.clientSites = new List<ClientSite>();
            IQueryable<Client_Site> clientSites = (from clinetSitesDb in _context.Client_Site
                                                   where clinetSitesDb.client_id == id
                                                   select clinetSitesDb);

            foreach (Client_Site item in clientSites)
            {
                ClientSite tempClientSite = new ClientSite();
                tempClientSite.Client_Site_Id = item.client_site_id;
                tempClientSite.SiteName = item.site_name;
                tempClientSite.Address = item.address;
                tempClientSite.City = item.city;
                tempClientSite.State = item.state;
                tempClientSite.PhoneNumber = item.phone;
                tempClientSite.Zip = item.zip;
                tempClientSite.FaxNumber = item.fax;
                newClient.clientSites.Add(tempClientSite);
            }
            return Ok(newClient);
        }

        [ResponseType(typeof(Client))]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> PostNewClient(NewClientViewModel newClientViewModel)
        {
            Client client = new Client();
            client.client_code = newClientViewModel.newClientModel.Client_Code;
            client.company_name = newClientViewModel.newClientModel.Company_Name;
            client.executive_incharge = newClientViewModel.newClientModel.executiveIncharge;
            client.program_manager = newClientViewModel.newClientModel.programManager;
            client.account_manager = newClientViewModel.newClientModel.accountManager;
            client.PAM_manager = newClientViewModel.newClientModel.pamManager;            
            client.website = newClientViewModel.newClientModel.Website;
            client.service_type = newClientViewModel.newClientModel.ServiceType;

            Agreement agreement = null;
            if (newClientViewModel.newClientModel.AgreementStartDate != null || newClientViewModel.newClientModel.AgreementEndDate != null || 
                newClientViewModel.newClientModel.AgreementPath != null)
            {
                agreement = new Agreement();
                agreement.start_date = newClientViewModel.newClientModel.AgreementStartDate;
                agreement.end_date = newClientViewModel.newClientModel.AgreementEndDate;
                agreement.filepath = newClientViewModel.newClientModel.AgreementPath;          
            }

            client.team = newClientViewModel.newClientModel.Team;
            client.status = newClientViewModel.newClientModel.Status;           

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                if (agreement != null)
                {
                    _context.Agreements.Add(agreement);                    
                    client.agreement_id = agreement.agreement_id;
                }
                _context.Clients.Add(client);                


                if (newClientViewModel.clientSites != null)
                {
                    List<ClientSite> clientSites = newClientViewModel.clientSites;
                    foreach (ClientSite clientSite in clientSites)
                    {
                        Client_Site dbClientSite = new Client_Site();
                        dbClientSite.client_id = client.client_id;
                        dbClientSite.site_name = clientSite.SiteName;
                        dbClientSite.address = clientSite.Address;
                        dbClientSite.city = clientSite.City;
                        dbClientSite.fax = clientSite.FaxNumber;
                        dbClientSite.phone = clientSite.PhoneNumber;
                        dbClientSite.state = clientSite.State;
                        dbClientSite.zip = clientSite.Zip;


                        _context.Client_Site.Add(dbClientSite);                       
                    }
                }
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
            Agreement agreement = null;
            if (client.Agreement != null)
            {
                agreement = await _context.Agreements.FindAsync(client.Agreement.agreement_id);
            }

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                if (client.Client_Site != null && client.Client_Site.Count > 0)
                {                    
                    List<Client_Site> clientsSites = new List<Client_Site>(client.Client_Site);
                    foreach (Client_Site item in clientsSites)
                    {
                        if (item != null)
                        {
                            _context.Client_Site.Remove(item);                            
                        }
                    }
                }
                if (agreement != null)
                {
                    _context.Agreements.Remove(agreement);                    
                }
                _context.Clients.Remove(client);

                await _context.SaveChangesAsync();
                scope.Complete();
            }
            return Ok(client);
        }

        [HttpPost]
        [ResponseType(typeof(Client))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UpdateClient(NewClientViewModel newClientViewModel)
        {
            try
            {
                Client client = (from oldClientInfo in _context.Clients
                                 where oldClientInfo.client_id == newClientViewModel.newClientModel.Client_Id
                                 select oldClientInfo).FirstOrDefault();

                List<Client_Site> dbClientSites = client.Client_Site.ToList<Client_Site>();

                if (client != null)
                {
                    client.client_code = newClientViewModel.newClientModel.Client_Code;
                    client.company_name = newClientViewModel.newClientModel.Company_Name;
                    client.website = newClientViewModel.newClientModel.Website;
                    client.service_type = newClientViewModel.newClientModel.ServiceType;

                    Agreement agreement = null;
                    if (newClientViewModel.newClientModel.AgreementStartDate != null || newClientViewModel.newClientModel.AgreementEndDate != null ||
                        newClientViewModel.newClientModel.AgreementPath != null)
                    {
                        if (client.Agreement == null)
                        {
                            agreement = new Agreement();
                            agreement.start_date = newClientViewModel.newClientModel.AgreementStartDate;
                            agreement.end_date = newClientViewModel.newClientModel.AgreementEndDate;
                            agreement.filepath = newClientViewModel.newClientModel.AgreementPath;
                        }
                        else
                        {
                            client.Agreement.start_date = (newClientViewModel.newClientModel.AgreementStartDate != null) ? newClientViewModel.newClientModel.AgreementStartDate : client.Agreement.start_date;
                            client.Agreement.end_date = (newClientViewModel.newClientModel.AgreementEndDate != null) ? newClientViewModel.newClientModel.AgreementEndDate : client.Agreement.end_date;
                            client.Agreement.filepath = (newClientViewModel.newClientModel.AgreementPath != null) ? newClientViewModel.newClientModel.AgreementPath : client.Agreement.filepath;
                        }
                    }

                    //client.team = newClientViewModel.newClientModel.Team;
                    client.executive_incharge = newClientViewModel.newClientModel.executiveIncharge;
                    client.program_manager = newClientViewModel.newClientModel.programManager;
                    client.account_manager = newClientViewModel.newClientModel.accountManager;
                    client.PAM_manager = newClientViewModel.newClientModel.pamManager;
                    client.status = newClientViewModel.newClientModel.Status;

                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
                    {
                        if (agreement != null)
                        {
                            _context.Agreements.Add(agreement);                           
                            client.agreement_id = agreement.agreement_id;
                        }                       

                        foreach (var dbSite in dbClientSites)// Present in DB and Absent in Client Array
                        {
                            if (newClientViewModel.clientSites.Exists(x => x.Client_Site_Id.Equals(dbSite.client_site_id)))
                            {
                                // Present in Client Array
                                // So, update DB with new one
                                ClientSite site = newClientViewModel.clientSites.Find(x => x.Client_Site_Id.Equals(dbSite.client_site_id));
                                dbSite.site_name = site.SiteName;
                                dbSite.address = site.Address;
                                dbSite.city = site.City;
                                dbSite.state = site.State;
                                dbSite.zip = site.Zip;
                                dbSite.phone = site.PhoneNumber;
                                dbSite.fax = site.FaxNumber;

                            }
                            else
                            {
                                // Not present in Client Array And present in DB
                                // So delete from DB
                                _context.Client_Site.Remove(dbSite);

                            }                           
                        }

                        foreach (var item in newClientViewModel.clientSites)// Present in Client Array and Absent in DB
                        {
                            if (dbClientSites.Exists(m => m.client_site_id.Equals(item.Client_Site_Id)))
                            {
                                // Present in Client Array and Present in DB
                                continue;
                            }
                            else
                            {
                                // Add new Client Site in the DB.
                                Client_Site clientSite = new Client_Site();
                                clientSite.client_id = client.client_id;
                                clientSite.site_name = item.SiteName;
                                clientSite.address = item.Address;
                                clientSite.city = item.City;
                                clientSite.state = item.State;
                                clientSite.zip = item.Zip;
                                clientSite.phone = item.PhoneNumber;
                                clientSite.fax = item.FaxNumber;

                                _context.Client_Site.Add(clientSite);                                
                            }
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
