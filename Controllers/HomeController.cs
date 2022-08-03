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
        StaffManagementEntitiesModel db = new StaffManagementEntitiesModel();
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
            string email = f["Email"].ToString();
            string password = f["Password"].ToString();
            Staff staff = db.Staffs.SingleOrDefault(s => s.Email == email && s.Password == password);
            if (ModelState.IsValid)
            {
                if(staff != null)
                {
                    Session["Staff"] = staff.Staff_Name;
                    return Redirect("Index");
                }
                else ModelState.AddModelError("", "Incorrect Email or Password");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["Staff"] = null;
            return Redirect("Index");
        }
    }
}