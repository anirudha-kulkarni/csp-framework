using CSPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web;
using System.Web.Security;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http.Description;
namespace api.cspportal.com.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private CSPFRAMEWORKEntities _context;

        public UserController()
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

        // POST :: api/User/AuthUser
        [HttpPost]
        [AllowAnonymous]      
        public HttpResponseMessage AuthUser([FromBody]LoginModel loginModel)
        {
            UserLoginModel model = loginModel.userLoginModel;
            User user = _context.Users.FirstOrDefault(usr => (usr.email == model.EmailAddress && usr.password == model.Password));

            if (user != null && user.status.Equals("Current"))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "{}");
            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized, "InvalidLogin");
        }

        // GET api/User/GetUser/5
        [ResponseType(typeof(NewUserModel))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            NewUserModel userModel = new NewUserModel();
            userModel.User_Id = user.user_id;
            userModel.Name = user.name;
            userModel.Email = user.email;
            userModel.Password = user.password;
            userModel.Phone = user.phone;
            userModel.Fax = user.fax;
            userModel.Address = user.address;
            userModel.AccountRole = user.user_group;
            userModel.Customer_Id = user.client_id;
            userModel.Customer_Name = user.Client.company_name;
            userModel.Status = user.status;
            return Ok(userModel);
        }

        // GET api/User/GetUsers
        [HttpGet]
        public List<RegisteredUserModel> GetUsers()
        {
            IQueryable<User> users = _context.Users;
            List<RegisteredUserModel> regUsers = new List<RegisteredUserModel>();
            foreach (User user in users)
            {
                RegisteredUserModel regUser = new RegisteredUserModel();
                regUser.User_Id = user.user_id;
                regUser.Email = user.email;
                regUser.Name = user.name;
                regUser.AccountRole = user.user_group;
                regUser.Phone = user.phone;
                regUsers.Add(regUser);
            }
            return regUsers;
        }

        // POST : api/User/PostUser
        [ResponseType(typeof(User))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> PostUser(NewUserModel newUser)
        {
            //NewUserModel newUser = viewmodel.NewUserRegistrationModel;
            //NewUserModel newUser = addNewUser.newUserModel;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                User user = new User();
                user.name = newUser.Name;
                user.email = newUser.Email;
                user.password = newUser.Password;
                user.phone = newUser.Phone;
                user.fax = newUser.Fax;
                user.address = newUser.Address;
                user.user_group = newUser.AccountRole.ToString();
                user.client_id = newUser.Customer_Id;
                user.status = newUser.Status;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = user.user_id }, user);

            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        [ResponseType(typeof(NewUserModel))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UpdateUser(NewUserModel updatedUser)
        {
            try
            {
                User oldUser = (from oldUserInfo in _context.Users
                              where oldUserInfo.user_id == updatedUser.User_Id
                              select oldUserInfo).FirstOrDefault();
                if(oldUser != null)
                {
                    oldUser.name = updatedUser.Name;
                    oldUser.user_group = updatedUser.AccountRole.ToString();
                    oldUser.client_id = updatedUser.Customer_Id;
                    oldUser.status = updatedUser.Status;
                    oldUser.phone = updatedUser.Phone;
                    oldUser.fax = updatedUser.Fax;
                    oldUser.address = updatedUser.Address;
                }
                
                await _context.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = oldUser.user_id }, oldUser);
            }
            catch (Exception)
            {
                
                throw new InvalidOperationException();
            }
        }

        // api/User/ChangePassword
        [HttpPost]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordModel updatedUser)
        {
            try
            {
                User oldUser = (from oldUserInfo in _context.Users
                                where oldUserInfo.user_id == updatedUser.User_Id
                                select oldUserInfo).FirstOrDefault();
                if (oldUser != null)
                {
                    oldUser.password = updatedUser.Password;                    
                }

                await _context.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = oldUser.user_id }, oldUser);
            }
            catch (Exception)
            {

                throw new InvalidOperationException();
            }
        }

        // DELETE api/User/DeleteUser/5
        [HttpDelete]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
