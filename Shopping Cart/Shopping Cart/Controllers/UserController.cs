using Shopping_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping_Cart.Controllers
{
    public class UserController : Controller
    {
        MartEntities Db = new MartEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View(Db.products.OrderByDescending(a => a.Id).ToList());
        }
        //---------------------------------Brand Wise-----------------------------
        public ActionResult BrandWise(int id)
        {
            ViewBag.id = id;
            return View(Db.products.Where(a => a.BrandId == id).ToList());
        }
        //---------------------------------End Brand Wise-----------------------------

        //---------------------------------Category Wise-----------------------------
        public ActionResult CategoryWise(int id)
        {
            ViewBag.id = id;
            return View(Db.products.Where(a => a.CategoryId == id).ToList());
        }
        //---------------------------------End Category Wise-----------------------------

        //---------------------------------Product Detail-----------------------------

        public ActionResult ProductDetail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        //---------------------------------End Product Detail-----------------------------

        //---------------------------------Cart-----------------------------
        
        
        public ActionResult Cart()
        {
            ViewBag.check = ok.abc;
            return View();
        }
        [HttpPost]
        public ActionResult Cart(int cid,int cqty)
        {
            
            foreach (var item in ok.abc)
            {  
                if (item.id==cid)
                {
                    item.qty += cqty;
                 
                    ViewBag.check = ok.abc;
                    return View();

                }
                
            } 
            
            cartitem i = new cartitem() { id = cid, qty = cqty };
            ok.abc.Add(i);
            //list going on cart page
            ViewBag.check = ok.abc;
            return View();


        }
       
        //---------------------------------End Cart-----------------------------

        //---------------------------------Remove Item-----------------------------

        public ActionResult RemoveItem(int id)
        {
            var s = ok.abc.RemoveAll(a => a.id == id);
            return RedirectToAction("Cart","User");
        }

        public ActionResult Remove()
        {
            ok.abc.Clear();
            return RedirectToAction("Cart", "User");
        }
        //---------------------------------End Remove Item-----------------------------

        //---------------------------------Login And Register User-----------------------------

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_User e)
        {
            var b = Db.tbl_User.Where(f => f.email == e.email && f.password == e.password).FirstOrDefault();
            if (b != null)
            {
                Session["name"] = b.name;
                Session["id"] = b.id;
                Session["email"] = b.email;
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_User e)
        {
            Db.tbl_User.Add(e);
            Db.SaveChanges();
            return RedirectToAction("Login", "User");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "User");
        }

        //---------------------------------End Login And Register User-----------------------------

        //---------------------------------Check Out-----------------------------

        public ActionResult Checkout(int total)
        {
            ViewBag.tot = total;
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(order o)
        {
            Random rd = new Random();
            o.InvoiceNo=rd.Next(10000,9000000).ToString();
            o.OrderDate = DateTime.Now;
            o.status = 0;
            o.Remarks = "The order is in Pending";
            o.TotalAmount = o.TotalAmount + o.DeliveryCharge;
            o.Amount = (decimal)o.TotalAmount;
            Db.orders.Add(o);
            Db.SaveChanges();
            //orderdetail data insertion
            int v = Db.orders.Select(a => a.Id).DefaultIfEmpty(0).Max();
            var prolist = from pro in ok.abc
                          join od in Db.products
                          on pro.id equals od.Id
                          select new { pid = od.Id, pname = od.Name, pprice = od.Price, oqtn = pro.qty };
            orderdetail odetail = new orderdetail();
            foreach(var item in prolist)
            {
                odetail.Price = item.pprice;
                odetail.Product_Name = item.pname;
                odetail.Quantity = item.oqtn;
                odetail.OrderId = v;
                odetail.ProductId = item.pid;

                Db.orderdetails.Add(odetail);
                Db.SaveChanges();
            }
            ok.abc.Clear();
            return RedirectToAction("Index","User");
        }

        //---------------------------------End Check Out-----------------------------

    }

}