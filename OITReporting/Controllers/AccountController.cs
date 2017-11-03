using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;
using System;
using OITReporting.Models;
using OITReporting.Models.dbClasses;

namespace OITReporting.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account     
        public ActionResult Index() => View();

        [HttpGet]
        public ActionResult Login() => View();

        private const int V = 525600;
        [HttpPost]
        public ActionResult Login(userLogin ul, string retrurnUrl)
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            #region Check Email Condition
            if (db.userMasters.Where(predicate: a => a.emailID == ul.Email).FirstOrDefault() != null)
            {
                #region Check Password condition
                if (db.userMasters.Where(predicate: b => b.password == ul.Password).FirstOrDefault() != null)
                {
                    #region Store Cookie
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(new FormsAuthenticationTicket(ul.Email, ul.RememberMe, ul.RememberMe ? 525600 : 20)))
                    {
                        #region expire cookie
                        Expires = DateTime.Now.AddMinutes(ul.RememberMe ? V : 20),
                        HttpOnly = true
                        #endregion
                    });
                    #endregion
                    #region check allready login or not
                    if (Url.IsLocalUrl(retrurnUrl))
                    {
                        return Redirect(retrurnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                    #endregion
                }
                else
                {
                    ModelState.AddModelError("passError", "Entered Password is invalid!");
                    return View();
                }
                #endregion
            }
            else
            {
                ModelState.AddModelError("usernameError", "Invalid Username or password!");
                return View("Login");
            }
            #endregion
        }
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            #region Logout session
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
            #endregion
        }
    }
}