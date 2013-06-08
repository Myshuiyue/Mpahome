using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mpahome.WebUI.Models;
using WebMatrix.WebData;
using System.Web.Security;
using Mpahome.WebUI.Filters;
using Mpahome.Domain.Entities;
using Mpahome.Domain.Concrete;


namespace Mpahome.WebUI.Areas.SimpleMembershipAdministration.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /SimpleMembershipAdministration/Main/

        public ActionResult Index()
        {

            return View();
        }

         
        [InitializeSimpleMembership]
        public ActionResult Users()
        {
            IEnumerable<User> users;
            using (EFDbContext db = new EFDbContext())
            {
                users = db.Users.ToList();
            }

            ViewBag.Roles = System.Web.Security.Roles.GetAllRoles();
            
            return View(users);
        }
        [InitializeSimpleMembership]
        public ActionResult Roles()
        {
            var roles = System.Web.Security.Roles.GetAllRoles();
            return View(roles);
        }

        [HttpPost]
        public ActionResult AddRole(string rolename)
        {
            System.Web.Security.Roles.CreateRole(rolename);
            var roles = System.Web.Security.Roles.GetRolesForUser();

            return View("Roles", roles);
        }
        [HttpPost]
        public ActionResult UserToRole(string rolename, string username, bool? ischecked)
        {
            if (ischecked.HasValue && ischecked.Value)
            {
                System.Web.Security.Roles.AddUserToRole(username, rolename);
            }
            else
            {
                System.Web.Security.Roles.RemoveUserFromRole(username, rolename);
            }
            return RedirectToAction("Users");
        }
    }
}
