using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MOSSWORKLOG.DATA;
using MOSSWORKLOG.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using MOSSWORKLOG.Areas.User.Models;

namespace MOSSWORKLOG.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {

            if (this.Request.Params["message"] != null)
            {
                ViewBag.Message = this.Request.Params["message"].ToString();

                if (this.Request.Params["type"] != null)
                {
                    ViewBag.MessageType = this.Request.Params["type"].ToString();
                }
                else
                { ViewBag.MessageType = null; }
            }
            else
            {
                ViewBag.Message = null;
                ViewBag.MessageType = null;
            }
            ViewBag.ReturnUrl = GetRedirectUrl(returnUrl);
            return View();
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            

            using (MossWorkLogDbEntities context = new MossWorkLogDbEntities())
            {

                var user = context.tblUsers.SingleOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

                if (user != null)
                {
                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,user.FullName),
                        new Claim(ClaimTypes.Role,user.RoleId.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim(ClaimTypes.NameIdentifier,user.FullName),
                        new Claim("UserId", user.UserId.ToString())},
                        "ApplicationCookie");


                    

                        // Set current principal
                    System.Threading.Thread.CurrentPrincipal = new ClaimsPrincipal(identity);
                    
                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;

                    authManager.SignIn(new AuthenticationProperties() { IsPersistent = model.RememberMe }, identity);

                    return Redirect(GetRedirectUrl(returnUrl));
                }

                //user authN failed
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
        }

        public ActionResult ResetPassword(string id)
        {
            string errorMessage = "";
            string messageType = "";

            if (!string.IsNullOrWhiteSpace(id))
            {
                using (MossWorkLogDbEntities context = new MossWorkLogDbEntities())
                {
                    DateTime now = DateTime.Now.AddHours(-1);
                    var request = context.PasswordResetRequests.SingleOrDefault(r => r.RequestId == id && r.Timestamp >= now);

                    if (request != null)
                    {
                        ResetPaswordViewModel vm = new ResetPaswordViewModel()
                        {
                            RequestId = id
                        };
                        return View(vm);
                    }
                    else
                    {
                        errorMessage = "Reset Link Expired.";
                        messageType = "ERROR";
                    }
                }
            }
            else
            {
                errorMessage = "Invalid Parameters.";
                messageType = "ERROR";
            }

            return RedirectToAction("Login", new { message = errorMessage, type = messageType });
        }
        [HttpPost]
        public ActionResult ResetPassword(ResetPaswordViewModel vm)
        {
            string errorMessage = "";
            string messageType = "";
            using (MossWorkLogDbEntities context = new MossWorkLogDbEntities())
            {
                DateTime now = DateTime.Now.AddHours(-1);

                var request = context.PasswordResetRequests.SingleOrDefault(r => r.RequestId == vm.RequestId && r.Timestamp >= now);

                if (request == null)
                {
                    errorMessage = "Invalid Request.";
                    messageType = "ERROR";
                    errorMessage = "Password reset done successfully.";
                }
                else
                {
                    var user = context.tblUsers.SingleOrDefault(x => x.UserId == request.RequestedUserId);
                    user.Password = vm.Password;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Login", new { message = errorMessage, type = messageType });
        }

        [HttpPost]
        public ActionResult Forget(LoginViewModel model)
        {
            string errorMessage = "";
            string messageType = "";


            using (MossWorkLogDbEntities context = new MossWorkLogDbEntities())
            {
                var user = context.tblUsers.SingleOrDefault(u => u.UserName == model.ForgetUserName || u.email == model.ForgetUserName);
                if (user == null)
                {
                    errorMessage = "User not found.";
                    messageType = "ERROR";
                }
                else
                {
                    if (string.IsNullOrEmpty(user.email))
                    {
                        errorMessage = "Email id not valid";
                        messageType = "ERROR";
                    }
                    else
                    {

                        var request = new PasswordResetRequest()
                        {
                            RequestId = Guid.NewGuid().ToString(),
                            RequestedUserId = user.UserId,
                            Timestamp = DateTime.Now
                        };

                        context.PasswordResetRequests.Add(request);
                        context.SaveChanges();

                        string requestUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/Account/ResetPassword/{request.RequestId}";

                        //Send Mail
                        Extension.SendPassswordResetEmail(user.email, requestUrl);

                        errorMessage = "Reset instructions sent on email.";
                    }
                }
            }


            return RedirectToAction("Login", new { message = errorMessage, type = messageType });
        }

        [Authorize]
        public ActionResult UserProfile()
        {
            UserModel vm = new UserModel();

            MossWorkLogDbEntities _context = new MossWorkLogDbEntities();
            int userId = Extension.GetUserId();
            var user = _context.tblUsers.SingleOrDefault(x => x.UserId == userId);
            vm.Email = user.email;
            vm.FullName = user.FullName;
            vm.Mobile = user.Mobile;
            vm.Password = user.Password;
            vm.RoleId = user.RoleId;
            vm.RoleName = user.Role.RoleDesc;
            vm.UserId = user.UserId;
            vm.UserName = user.UserName;
            vm.ManagerId = user.ManagerId;
            vm.Manager = user.ManagerId == null ? "" : _context.tblUsers.SingleOrDefault(x=>x.UserId == user.ManagerId).FullName;
            vm.SupervisorId = user.SupervisorId;
            vm.Supervisor = user.SupervisorId == null ? "" : _context.tblUsers.SingleOrDefault(x => x.UserId == user.SupervisorId).FullName;
            return View(vm);
        }
    }
}