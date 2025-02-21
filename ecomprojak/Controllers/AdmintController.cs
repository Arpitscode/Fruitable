using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecomprojak.Models;

namespace ecomprojak.Controllers
{
    public class AdmintController : Controller
    {
        ecomadoEntities con=new ecomadoEntities();
        // GET: Admint
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        public ActionResult AddCategory()
        {
            if (Session["UserId"] != null)
            {
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Tbl_Category tbc)
        {
            try
            {
                con.Tbl_Category.Add(tbc);
                con.SaveChanges();
                Response.Write("<script>alert('Category Added Successfully.');window.location.href='/Admint/CategoryManagement';</script>");
            }
            catch
            {
                Response.Write("<script>alert('Category Not Added UnSuccessfully.');window.location.href='/Admint/AddCategory';</script>");

            }
            return View();
        }
        public ActionResult CategoryManagement()
        {
            if (Session["UserId"] != null)
            {
                List<Tbl_Category> lst = con.Tbl_Category.ToList();
                return View(lst);
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        public void Delete_Category(int id)
        {
            Tbl_Category tbc=con.Tbl_Category.SingleOrDefault(c=>c.cid==id);
            con.Tbl_Category.Remove(tbc);
            if (con.SaveChanges()>0)
            {
                Response.Write("<script>alert('Category Deleted Successfully.');window.location.href='/Admint/CategoryManagement';</script>");
            }
            else
            {
                Response.Write("<script>alert('Category Not Deleted unsuccessfully.');window.location.href='/Admint/CategoryManagement';</script>");

            }

        }
        public ActionResult Update_Category()
        {
            if (Session["UserId"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                Tbl_Category tbc = con.Tbl_Category.SingleOrDefault(tb => tb.cid == id);
                 return View(tbc);
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update_Category(Tbl_Category tb)
        {
            try {             
                Tbl_Category tbc = con.Tbl_Category.SingleOrDefault(c => c.cid ==tb.cid);
                tbc.cname = tb.cname;
                con.SaveChanges();
                Response.Write("<script>alert('Category Updated Successfully.');window.location.href='/Admint/CategoryManagement';</script>");
            }
            catch
            {
                Response.Write("<script>alert('Category Not Updated Unsuccessfully.');window.location.href='/Admint/CategoryManagement';</script>");
            }
            return View();
        }
        public ActionResult AddProducts()
        {
            if (Session["UserId"] != null)
            {
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }

        [HttpPost]       
        public ActionResult AddProducts(Tbl_Product tbp)
        {
                try
                {
                    HttpPostedFileBase file = Request.Files["ppic"];
                    tbp.ppic = file.FileName.ToString();
                    file.SaveAs(Server.MapPath("~/Content/Productsimg/" + file.FileName));
                    con.Tbl_Product.Add(tbp);
                    con.SaveChanges();
                    ModelState.Clear();
                    Response.Write("<script>alert('Product Added Successfully.');window.location.href='/Admint/ProductManagement';</script>");
                }
                catch
                {
                    Response.Write("<script>alert('Product Not Added Unsuccessfully.');window.location.href='/Admint/AddProducts';</script>");

                }
          return View();
        }
        public ActionResult ProductManagement()
        {
            if (Session["UserId"] != null)
            {
                List<Tbl_Product> lst = con.Tbl_Product.ToList();
                return View(lst);
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn';</script>");
            }
            return View();
        }
        public void Delete_Product(int id)
        {
            Tbl_Product tbp = con.Tbl_Product.SingleOrDefault(c => c.pid == id);
            con.Tbl_Product.Remove(tbp);
            if (con.SaveChanges() > 0)
            {
                Response.Write("<script>alert('Product Deleted Successfully.');window.location.href='/Admint/ProductManagement';</script>");
            }
            else
            {
                Response.Write("<script>alert('Product Not Deleted Unsuccessfully.');window.location.href='/Admint/ProductManagement';</script>");

            }

        }

        public ActionResult Update_Product()
        {
            if (Session["UserId"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                Tbl_Product tb = con.Tbl_Product.SingleOrDefault(c => c.pid ==id);
                return View(tb);
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Update_Product(Tbl_Product tbp)
        {
            try
            {
                Tbl_Product tb = con.Tbl_Product.SingleOrDefault(c => c.pid==tbp.pid);

                HttpPostedFileBase file = Request.Files["ppic"];
                tb.pname=tbp.pname;
                tb.pcate = tbp.pcate;
                tb.price = tbp.price;
                tb.disprice = tbp.disprice;
                tb.pquantity = tbp.pquantity;
                tb.description = tbp.description;
                if (file.FileName !=null&&file.FileName!="")
                {
                    tbp.ppic = file.FileName.ToString();
                    file.SaveAs(Server.MapPath("~/Content/Productsimg/" + file.FileName));
                }
                con.SaveChanges();
                Response.Write("<script>alert('Product Updated Successfully.');window.location.href='/Admint/ProductManagement';</script>");
                ModelState.Clear();
            }
            catch
            {
                Response.Write("<script>alert('Product Not Updated Unsuccessfully.');window.location.href='/Admint/ProductManagement';</script>");

            }
            return View();
        }

        public ActionResult OrderManagement()
        {
            if (Session["UserId"] != null)
            {
                List<Tbl_Order> lst = con.Tbl_Order.ToList();
                return View(lst);
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        public ActionResult RegMGMT()
        {
            if (Session["UserId"] != null)
            {
                List<Tbl_Register> lst = con.Tbl_Register.ToList();
                return View(lst);
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        public void Registerdelete()
        {
            string email = Request.QueryString["em"];
            Tbl_Register tb=con.Tbl_Register.FirstOrDefault(m=>m.email==email);
            if (tb != null)
            {
                con.Tbl_Register.Remove(tb);
                con.SaveChanges();
                Response.Write("<script>alert('Data Deleted Successfully.');window.location.href='/Admint/RegMGMT';</script>");
            }
            else
            {
                Response.Write("<script>alert('Data not Deleted UnSuccessfully.');window.location.href='/Admint/RegMGMT';</script>");
            }
        }
        public ActionResult ContactMGMT()
        {
            if (Session["UserId"] != null)
            {
                List<Tbl_Contact> lst=con.Tbl_Contact.ToList();
                return View(lst);
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        public void Contactdelete()
        {
            int id =int.Parse(Request.QueryString["id"]);
            Tbl_Contact tb = con.Tbl_Contact.FirstOrDefault(m => m.Id == id);
            if (tb != null)
            {
                con.Tbl_Contact.Remove(tb);
                con.SaveChanges();
                Response.Write("<script>alert('Data Deleted Successfully.');window.location.href='/Admint/ContactMGMT';</script>");
            }
            else
            {
                Response.Write("<script>alert('Data not Deleted UnSuccessfully.');window.location.href='/Admint/ContactMGMT';</script>");
            }
        }
        public void LogOut()
        {
            Session.Abandon();
            Response.Write("<script>alert('Logout Successfully');window.location.href='/Home/Index'</script>");
        }
        public ActionResult AdminMGMT()
        {
            if (Session["UserId"] != null)
            {
                List<Tbl_Login> lst = con.Tbl_Login.ToList();
                return View(lst);
            }
            else
            {
                Response.Write("<script>alert('Login First.');window.location.href='/Home/SignIn'</script>");
            }
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string newpass,string confrimpass)
        {
            if (newpass == confrimpass)
            {
                string email = Session["UserId"].ToString();
                Tbl_Login tb = con.Tbl_Login.SingleOrDefault(c => c.email == email);
                tb.password = newpass;
                con.SaveChanges();
                Response.Write("<script>alert('Password Has Been Changed Successfully');window.location.href='/Home/SignIn'</script>");
            }
            else
            {
                Response.Write("<script>alert('Password Has Not Been Changed');window.location.href='/Admint/Index';</script>");

            }
            return View();
        }
    }
}