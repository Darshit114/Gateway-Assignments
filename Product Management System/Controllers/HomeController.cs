using PMS.Entities;
using Product_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using PagedList;

namespace Product_Management_System.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            return View();
        }

        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Products(string id, int? pageNumber)
        {

            IEnumerable<ProductEntity> products = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59086/api/v1/products/");

                var responseTask = client.GetAsync("GetAllProducts");

                switch (id)
                {
                    case "Name":
                        responseTask = client.GetAsync("GetByProductName");
                        break;
                    case "Category":
                        responseTask = client.GetAsync("GetByProductCategory");
                        break;
                }

                
                var res = responseTask.Result;

                if (res.IsSuccessStatusCode)
                {
                    var readResponse = res.Content.ReadAsAsync<IList<ProductEntity>>();
                    readResponse.Wait();

                    products = readResponse.Result;
                }
                else
                {
                    products = new List<ProductEntity>();

                    ModelState.AddModelError(string.Empty, "Internal Server Error!!");
                }



            }

            return View(products.ToPagedList(pageNumber ?? 1,3));
        }

        public ActionResult EditProduct(int id)
        {
            ProductViewModel currentProduct = null;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59086/api/v1/products/");

                // HTTP GET Request
                var responseTask = client.GetAsync("GetProductById/" + id.ToString());
                responseTask.Wait();

                var res = responseTask.Result;

                if(res.IsSuccessStatusCode)
                {
                    var readProduct = res.Content.ReadAsAsync<ProductEntity>();
                    readProduct.Wait();

                    ProductEntity item = readProduct.Result;

                    currentProduct = new ProductViewModel();

                    currentProduct.Id = item.Id;
                    currentProduct.Name = item.Name;
                    currentProduct.Category = (ProductsCategory)Enum.Parse(typeof(ProductsCategory), item.Category);
                    currentProduct.Price = item.Price;
                    currentProduct.Quantity = item.Quantity;
                    currentProduct.ShortDescription = item.Short_Description;
                    currentProduct.LongDescription = item.Long_Description;
                   
                }
            }

            return View(currentProduct);
        }

        public ActionResult DeleteProduct(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59086/api/v1/products/");

                var deleteTask = client.DeleteAsync("DeleteProduct/" + id.ToString());
                deleteTask.Wait();

                var res = deleteTask.Result;

                if (res.IsSuccessStatusCode)
                {
                    return this.RedirectToAction("DeleteProduct", "Products");
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // This method set the session 
        [HttpPost]
        public JsonResult AjaxMethod(UserEntity user)
        {
            if (user != null)
            {
                Session["Id"] = user.Id;
                Session["Username"] = user.Email;

                return Json(new { status = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { redirecturl = false }, JsonRequestBehavior.AllowGet);
        }

        // Clear the session
        [HttpGet]
        public JsonResult ClearSession()
        {
            if (Session["Id"] != null && Session["Username"] != null)
            {
                Session.Clear();
                Session.Abandon();

                return Json(new { status =  true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = false }, JsonRequestBehavior.AllowGet);
        }

        
    }
}
