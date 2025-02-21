using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecomprojak.Models;

namespace ecomprojak.Controllers
{
    public class HomeController : Controller
    {
        ecomadoEntities con=new ecomadoEntities();
        // GET: Home
        public ActionResult Index()
        { 


       // List<Tbl_Product>tbl=    con.Tbl_Product.ToList();
            return View(con.Tbl_Product.ToList());
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Products()
        {
            List<Tbl_Product> tbp = con.Tbl_Product.ToList(); 
            return View(tbp);
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Tbl_Contact tbc)
        {
            try
            {
                tbc.regdate = DateTime.Now.ToShortDateString();
                con.Tbl_Contact.Add(tbc);
                con.SaveChanges();
                Response.Write("<script>alert('Submitted Successfully.');window.location.href='/Home/Contact';</script>");
                ModelState.Clear();
            }
            catch
            {
                Response.Write("<script>alert('Submitted Not Successfully.');window.location.href='/Home/Contact';</script>");
            }
            return View();
        }

        public ActionResult SignIn() { 
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Tbl_Register tbreg)
        {
            try
            {
                Tbl_Register t1 = con.Tbl_Register.Where(x => x.email==tbreg.email&&x.password==tbreg.password).SingleOrDefault();
                if (t1 != null)
                {
                    Session["Useremail"] = tbreg.email;//set session
                    Response.Write("<script>alert('Login Successfully.');window.location.href='/Home/Index'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid UserId & Password');window.location.href='/Home/SignIn'</script>");

                }
            }
            catch
            {
                Response.Write("<script>alert('Invalid Something went Wrong.Try Again...');window.location.href='/Home/SignIn';</script>");
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Tbl_Register tbr)
        {
            HttpPostedFileBase file = Request.Files["profile"];
            if (file.FileName != "")
            {
                tbr.profile= file.FileName.ToString();
                tbr.regdate = DateTime.Now.ToShortDateString();
                con.Tbl_Register.Add(tbr);
                con.SaveChanges();
                file.SaveAs(Server.MapPath("../Content/img/" + file.FileName));
                Response.Write("<script>alert('Data Submitted Successfully');window.location.href='/Home/Index';</script>");

            }
            else
            {
                Response.Write("<script>alert('Data Submitted not UnSuccessfully');window.location.href='/Home/SignUp';</script>");
            }
            return View();
        }
        public ActionResult CartOut()
        {
            return View();
        }
        public JsonResult AddtoCart(int id)
        {
            if (Session["cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
                var product = con.Tbl_Product.Find(id);
                if (product != null)
                {
                    cart.Add(new Cart() { 
                        product = product,
                        quantity = 1 
                    });
                    Session["cart"] = cart;
                }
            }
            else
            {
                List<Cart> cart = (List<Cart>)Session["cart"];
                var product = con.Tbl_Product.Find(id);

                if (product != null)
                {
                    var existingItem = cart.FirstOrDefault(c => c.product.pid == id);

                    if (existingItem != null)
                    {
                        existingItem.quantity += 1;
                    }
                    else
                    {
                        cart.Add(new Cart() { 
                            product = product,
                            quantity = 1 });
                    }

                    Session["cart"] = cart;
                }
            }

            return Json("Product Added.",JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemoveToCart(int pid)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            //var product = con.Tbl_Product.Find(pid);
            foreach(var item in cart)
            {
                if (item.product.pid == pid)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("CartOut");
        }
        public ActionResult CheckOut(Tbl_Order tbo)
        {
            if (Session["Useremail"] != null){
                List<Cart> order = (List<Cart>)Session["cart"];
                for(var i = 0; i < order.Count; i++)
                {
                    tbo.Uemail = Session["Useremail"].ToString();
                    tbo.pid= order[i].product.pid;
                    tbo.pname= order[i].product.pname;
                    tbo.pquantity= order[i].product.pquantity;
                    tbo.price= order[i].product.price;
                    tbo.disprice = order[i].product.disprice;
                    tbo.pcate = order[i].product.pcate;
                    tbo.ppic = order[i].product.ppic;
                    tbo.orddate = DateTime.Now.ToShortDateString();
                    con.Tbl_Order.Add(tbo);
                    con.SaveChanges();
                }
                Response.Write("<script>alert('Order Successfully.we will be send Confrimation mail...');");
                   Session["cart"] = null; 
                //}
                //else
                //{
                //    Response.Write("<script>alert('Order Failed Unsuccessfully.');window.location.href='/Home/CartOut'");
                //}
                return Redirect("Index");
        }
            else
            {
                return Redirect("SignIn");
            }
        }
        public ActionResult AdminSignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminSignIn(Tbl_Login tb_login)
        {
            try
            {
                Tbl_Login t1 = con.Tbl_Login.Where(x => x.email == tb_login.email && x.password == tb_login.password).SingleOrDefault();
                if (t1 != null)
                {
                    Session["UserId"] = tb_login.email;//set session
                    Response.Write("<script>alert('Login Successfully.WelCome To admin Page.');window.location.href='/Admint/Index'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid UserId & Password');window.location.href='/Home/AdminSignIn'</script>");

                }
            }
            catch
            {
                Response.Write("<script>alert('Invalid UserId & Password');window.location.href='/Home/AdminSignIn';</script>");
            }
            return View();
        }
        public void LogOut()
        {
            Session["Useremail"]=null;
            Response.Write("<script>alert('Logout Successfully');window.location.href='/Home/SignIn'</script>");
        }
    }
}