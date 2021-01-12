using PMS.BLL;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using NLog;

namespace Product_Management_System.Controllers
{
    [RoutePrefix("api/v1/products")]
    public class ProductsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IProductBLL _productBll;
            
        public ProductsController(IProductBLL productBll)
        {
            _productBll = productBll;
        }

        [Route("DeleteMultiple")]
        [HttpPost]
        public IHttpActionResult DeleteMultipleProducts([FromBody]MyDto myDto)
        {

            var listData = myDto.list;

            List<int> list = new List<int>(); 
            
            for(int i = 0; i < listData.Length; i++)
            {
                int j = Convert.ToInt32(listData[i]);

                list.Add(j);
            }

            bool res = _productBll.DeleteMultipleProducts(list);

            return Ok();
        }

        [Route("AddProduct")]
        [HttpPost]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public async Task<HttpResponseMessage> AddProduct()
        {
            
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/Assets/Images");
            var provider = new MultipartFormDataStreamProvider(root);

            string smallImg = null, largeImg = null;
           
            try
            {

                // Read the form data       
                await Request.Content.ReadAsMultipartAsync(provider);

                // Here we are getting file names.
                if (provider.FileData != null)
                {

                    foreach (var file in provider.FileData)
                    {
                        var name = file.Headers.ContentDisposition.FileName;
                        name = name.Trim('"');

                        var localFileName = file.LocalFileName;
                        

                        var filePath = Path.Combine(root, name);

                        if (file.Headers.ContentDisposition.Name.Trim('\"') == "SmallImg" )
                        {
                            smallImg = filePath;
                            // System.Web.Hosting.HostingEnvironment.MapPath(filePath);
                        }

                        if (file.Headers.ContentDisposition.Name.Trim('\"') == "LargeImg")
                        {
                            largeImg = filePath;
                            // System.Web.Hosting.HostingEnvironment.MapPath(filePath); 
                        }

                        // Move to the storage location
                        File.Move(localFileName, filePath);
                    }

                }

                ProductEntity product = new ProductEntity();

                product.Name = provider.FormData.Get("Name");
                product.Category = provider.FormData.Get("Category");
                product.Price = Convert.ToDecimal(provider.FormData.Get("Price"));
                product.Quantity = Convert.ToInt64(provider.FormData.Get("Quantity"));
                product.Short_Description = provider.FormData.Get("ShortText");
                product.Long_Description = provider.FormData.Get("LongText");
                product.Small_Image = smallImg;
                product.Large_Image = largeImg;

                bool res = _productBll.AddProduct(product);

                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Succefull!!" });
                }

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = "Error!!!" });

            } catch (Exception e)
            {
                logger.ErrorException("Exception while post the data..." + DateTime.Now, e);

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error!!");
            }
        } 
        
        [Route("GetAllProducts")]
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                var _products = _productBll.GetAllProducts();

                if (_products != null)
                {
                    logger.Info("Getting Data..." + DateTime.Now);
                    return Ok(_products);
                }

                logger.Info("No Data Avalable.." + DateTime.Now);
                return Ok(new { Message = "Sorry!! No Data Avaialable!!!" });

            } catch(Exception e)
            {
                logger.ErrorException("Error while getting the data..." + DateTime.Now, e);
                return InternalServerError();
            }
            
        }

        [Route("GetProductById/{id}")]
        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            ProductEntity product = _productBll.GetProductById(id);

            if(product != null)
            {
                return Ok(product);
            }

            logger.Info("No data found..." + DateTime.Now);
            return Ok(new { Message = "Sorry! No Match Found!!" });
        }

        [Route("UpdateProduct")]
        [HttpPut]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> UpdateProduct()
        {

            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                logger.Info("Unsupported Media File..." + DateTime.Now);
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/Assets/Images");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data 
                await Request.Content.ReadAsMultipartAsync(provider);

                bool res = false;

                if(provider.FileData != null || provider.FormData != null)
                {
                    ProductEntity product = new ProductEntity();

                    product.Id = Convert.ToInt32(provider.FormData.Get("Id"));
                    product.Name = provider.FormData.Get("Name");
                    product.Category = provider.FormData.Get("Category");
                    product.Price = Convert.ToDecimal(provider.FormData.Get("Price"));
                    product.Quantity = Convert.ToInt64(provider.FormData.Get("Quantity"));
                    product.Short_Description = provider.FormData.Get("ShortText");
                    product.Long_Description = provider.FormData.Get("LongText");

                   res =  _productBll.UpdateProduct(product,provider,root);
                }

                if(res)
                {
                    return Ok();
                }

                return InternalServerError();

            } catch (Exception e)
            {
                logger.ErrorException("Error while updating data..." + DateTime.Now, e);
                return InternalServerError();
            }
        }

        [Route("DeleteProduct/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {

            bool res = _productBll.DeleteProduct(id);

            if (res)
                return Ok();       
     
            return InternalServerError();
        }
        
        [Route("GetByProductName")]
        [HttpGet]
        public IHttpActionResult GetByProductName()
        {
            var list = _productBll.SortProductByName();

            if(list != null)
            {
                return Ok(list);
            }

            return InternalServerError();
        }

        [Route("GetByProductCategory")]
        [HttpGet]
        public IHttpActionResult GetByProductCategory()
        {
            var list = _productBll.SortProductByCategory();

            if (list != null)
            {
                return Ok(list);
            }
            
            return InternalServerError();
        }

        [Route("Search/{key}")]
        [HttpGet]
        public IHttpActionResult SearchByNameOrCategory(string key)
        {
            var list = _productBll.SearchByNameOrCategory(key);

            if(list != null)
            {
                return Ok(list);
            }

            return InternalServerError();
        }

        
    }

}
