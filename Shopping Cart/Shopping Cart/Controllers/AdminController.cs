using Shopping_Cart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Cart.Controllers
{
    public class AdminController : Controller
    {
        MartEntities Db = new MartEntities();

        // GET: Admin

        //-------------------------------------------Dashboard--------------------------------------
        public ActionResult Index()
        {
            if (Session["name"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        //-----------------------------------------End DashBoard ----------------------------------------
        //---------------------------Category------------------------------------
        public ActionResult AddCategory()
        {
            if (Session["name"] != null)
            {

                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult AddCategory(category c)
        {
            if (Session["name"] != null)
            {
                Db.categories.Add(c);
                Db.SaveChanges();
                return RedirectToAction("ListCategory", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult ListCategory()
        {
            if (Session["name"] != null)
            {

                return View(Db.categories.OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult DeleteCategory(int id)
        {
            if (Session["name"] != null)
            {
                //var u =Db.categories.Find(id);
                //or
                var u = Db.categories.Where(a => a.Id == id).FirstOrDefault();
                Db.categories.Remove(u);
                Db.SaveChanges();
                return RedirectToAction("ListCategory", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult EditCategory(int id)
        {
            if (Session["name"] != null)
            {
                var s = Db.categories.Where(a => a.Id == id).FirstOrDefault();
                return View(s);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult EditCategory(category c)
        {
            if (Session["name"] != null)
            {
                var s = Db.categories.Where(a => a.Id == c.Id).FirstOrDefault();
                s.Name = c.Name;
                Db.SaveChanges();
                return RedirectToAction("ListCategory", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        //---------------------------End Category------------------------------------

        //---------------------------Brand------------------------------------
        public ActionResult AddBrand()
        {
            if (Session["name"] != null)
            {

                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult AddBrand(brand c)
        {
            if (Session["name"] != null)
            {
                Db.brands.Add(c);
                Db.SaveChanges();
                return RedirectToAction("ListBrand", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult ListBrand()
        {
            if (Session["name"] != null)
            {

                return View(Db.brands.OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult DeleteBrand(int id)
        {
            if (Session["name"] != null)
            {
                //var u =Db.brands.Find(id);
                //or
                var u = Db.brands.Where(a => a.Id == id).FirstOrDefault();
                Db.brands.Remove(u);
                Db.SaveChanges();
                return RedirectToAction("ListBrand", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult EditBrand(int id)
        {
            if (Session["name"] != null)
            {
                var s = Db.brands.Where(a => a.Id == id).FirstOrDefault();
                return View(s);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult EditBrand(brand c)
        {
            if (Session["name"] != null)
            {
                var s = Db.brands.Where(a => a.Id == c.Id).FirstOrDefault();
                s.Name = c.Name;
                Db.SaveChanges();
                return RedirectToAction("ListBrand", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        //---------------------------End Brand------------------------------------

        //---------------------------User------------------------------------

        public ActionResult ListUser()
        {
            if (Session["name"] != null)
            {

                return View(Db.users.OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult DeleteUser(int id)
        {
            if (Session["name"] != null)
            {
                //var u =Db.brands.Find(id);
                //or
                var u = Db.users.Where(a => a.Id == id).FirstOrDefault();
                Db.users.Remove(u);
                Db.SaveChanges();
                return RedirectToAction("ListUser", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult EditUser(int id)
        {
            if (Session["name"] != null)
            {
                var s = Db.users.Where(a => a.Id == id).FirstOrDefault();
                return View(s);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult EditUser(user c)
        {
            if (Session["name"] != null)
            {
                var s = Db.users.Where(a => a.Id == c.Id).FirstOrDefault();
                s.Name = c.Name;
                s.Password = c.Password;
                s.Email = c.Email;
                s.Role = c.Role;
                Db.SaveChanges();
                return RedirectToAction("ListUser", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        //---------------------------End User------------------------------------

        //---------------------------Contact Query------------------------------------
        public ActionResult ListContact()
        {
            if (Session["name"] != null)
            {

                return View(Db.contactqueries.OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult DeleteContact(int id)
        {
            if (Session["name"] != null)
            {

                var u = Db.contactqueries.Where(a => a.Id == id).FirstOrDefault();
                Db.contactqueries.Remove(u);
                Db.SaveChanges();
                return RedirectToAction("ListContact", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }

        //---------------------------End Contact Query------------------------------------

        //---------------------------Product------------------------------------

        public ActionResult AddProduct()
        {
            if (Session["name"] != null)
            {
                ViewBag.BrandId = new SelectList(Db.brands.ToList(), "Id", "Name");
                ViewBag.CategoryId = new SelectList(Db.categories.ToList(), "Id", "Name");
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult AddProduct(product c)
        {
            if (Session["name"] != null)
            {
                ViewBag.BrandId = new SelectList(Db.brands.ToList(), "Id", "Name");
                ViewBag.CategoryId = new SelectList(Db.categories.ToList(), "Id", "Name");
                Db.products.Add(c);
                Db.SaveChanges();
                return RedirectToAction("ListProduct", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult ListProduct()
        {
            if (Session["name"] != null)
            {

                return View(Db.products.OrderByDescending(a => a.Id).ToList());
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult DeleteProduct(int id)
        {
            if (Session["name"] != null)
            {
                //var u =Db.brands.Find(id);
                //or
                var u = Db.products.Where(a => a.Id == id).FirstOrDefault();
                Db.products.Remove(u);
                Db.SaveChanges();
                return RedirectToAction("ListProduct", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult EditProduct(int id)
        {
            if (Session["name"] != null)
            {
                ViewBag.BrandId = new SelectList(Db.brands.ToList(), "Id", "Name");
                ViewBag.CategoryId = new SelectList(Db.categories.ToList(), "Id", "Name");
                var s = Db.products.Where(a => a.Id == id).FirstOrDefault();
                return View(s);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult EditProduct(product c)
        {
            if (Session["name"] != null)
            {
                ViewBag.BrandId = new SelectList(Db.brands.ToList(), "Id", "Name");
                ViewBag.CategoryId = new SelectList(Db.categories.ToList(), "Id", "Name");
                var s = Db.products.Where(a => a.Id == c.Id).FirstOrDefault();
                s.Name = c.Name;
                s.Price = c.Price;
                s.Featured = c.Featured;
                s.Details = c.Details;
                Db.SaveChanges();
                return RedirectToAction("ListProduct", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }

        //---------------------------End Product------------------------------------

        //---------------------------Product Image------------------------------------

        public ActionResult AddProductImage(int id)
        {
            if (Session["name"] != null)
            {
                ViewBag.id = id;
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult AddProductImage(int id, HttpPostedFileBase p)
        {
            if (Session["name"] != null)
            {
                //image to folder
                string file = Path.Combine(Server.MapPath("~/img/product/"), Path.GetFileName(p.FileName));
                p.SaveAs(file);

                //image to database
                productimage g = new productimage();
                g.ImageURL = p.FileName;
                g.ProductId = id;
                Db.productimages.Add(g);
                Db.SaveChanges();
                return RedirectToAction("ListProduct", "Admin");
            }
            return RedirectToAction("Login", "Account");
        }


        //---------------------------End Product Image------------------------------------

        //---------------------------Allow / Deny User------------------------------------

        public ActionResult TrueStatus(int id)
        {
            var b=Db.users.Where(a => a.Id == id).FirstOrDefault();
            b.status="True";
            Db.SaveChanges();
            return RedirectToAction("ListUser", "Admin");
        }

        public ActionResult FalseStatus(int id)
        {
            var b = Db.users.Where(a => a.Id == id).FirstOrDefault();
            b.status = "False";
            Db.SaveChanges();
            return RedirectToAction("ListUser", "Admin");
        }
        //---------------------------End Allow / Deny User------------------------------------

    }
}