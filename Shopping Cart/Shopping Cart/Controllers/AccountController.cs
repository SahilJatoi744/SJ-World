using Shopping_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Cart.Controllers
{
    public class AccountController : Controller
    {
        MartEntities Db = new MartEntities();
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user u)
        {
            Db.users.Add(u);
            Db.SaveChanges();
            return RedirectToAction("Login","Account");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user a)
        {
            var b = Db.users.Where(f => f.Name == a.Name && f.Password == a.Password).FirstOrDefault();
            if (b != null)
            {
                if (b.status== "True")
                {
                    Session["Name"] = b.Name;
                    Session["Role"] = b.Role;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.msg = "Still Request is in Pending";
                    return View();
                }
            }
            else 
            {
                ModelState.Clear();
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login","Account");
        }
    }
}