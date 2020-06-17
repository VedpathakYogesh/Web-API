using DebMobile.Models;
using MobileDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DebMobile.Controllers
{
    public class AddToCartController1 : Controller
    {
        // GET: AddToCart
        DataTable dt;
        MobiledetailDAL _mdal = new MobiledetailDAL();
        public ActionResult Index()
        {
            return View();
        }

        //ProductDetails
        public ActionResult Add(ProductDetails mo)
        {
            if (Session["cart"] == null)
            {
               // List<ProductDetails> li = new List<Mobiles>();
                List<ProductDetails> li = new List<ProductDetails>();
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = 1;
            }
            else
            {
              //  List<Mobiles> li = (List<Mobiles>)Session["cart"];
                List<ProductDetails> li = (List<ProductDetails>)Session["cart"];
                li.Add(mo);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Myorders
        /// </summary>
        /// <returns></returns>
        public ActionResult Myorder()
        {
            return View((List<Mobiles>)Session["cart"]);
        }

        public ActionResult Remove (Mobiles mob)
        {
            if (mob != null)
            {
                List<Mobiles> li = (List<Mobiles>)Session["cart"];
                li.RemoveAll(x => x.slno == mob.slno);
                Session["cart"] = li;
                Session["count"] = Convert.ToInt32(Session["count"]) - 1;
                
            }
            return RedirectToAction("Myorder", "AddToCart");
        }
    }
}