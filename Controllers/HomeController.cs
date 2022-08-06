using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffManagement.Controllers
{
    public class HomeController : Controller
    {
        StaffManagementEntities1 db = new StaffManagementEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string username = f["Username"].ToString();
            string password = f["Password"].ToString();
            Account account = db.Accounts.SingleOrDefault(a => a.Username == username && a.Password == password);
            if (ModelState.IsValid)
            {
                if(account != null)
                {
                    Role role = db.Roles.SingleOrDefault(r => r.Role_ID == account.Role_ID);
                    Session["Role"] = role.Role_Name;
                    Session["RoleID"] = role.Role_ID;
                    if (account.Role_ID == "0" || account.Role_ID == "3")
                    {
                        Manager manager = db.Managers.SingleOrDefault(m => m.AccountID == account.ID);
                        Session["Staff"] = manager.Staff_Name;
                        Session["StaffID"] = manager.Staff_ID;
                    }
                    else if (account.Role_ID == "1" || account.Role_ID == "2")
                    {
                        Staff staff = db.Staffs.SingleOrDefault(s => s.AccountID == account.ID);
                        Session["Staff"] = staff.Staff_Name;
                        Session["StaffID"] = staff.Staff_ID;
                    }
                    
                    return Redirect("Index");
                }
                else ModelState.AddModelError("", "Incorrect Username or Password");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("Index");
        }
    }
}