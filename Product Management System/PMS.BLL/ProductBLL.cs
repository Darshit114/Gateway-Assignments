using PMS.DAL.Repository;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using NLog;

namespace PMS.BLL
{
    public class ProductBLL : IProductBLL
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IProductRepository _productRepo;

        public ProductBLL(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public bool AddProduct(ProductEntity product)
        {
            return _productRepo.AddProduct(product);
        }

        public bool DeleteMultipleProducts(List<int> list)
        {
            return _productRepo.DeleteMultipleProducts(list);
        }

        public bool DeleteProduct(int id)
        {

            string smallImg = _productRepo.GetProductById(id).Small_Image;
            string largeImg = _productRepo.GetProductById(id).Large_Image;

            bool res = _productRepo.DeleteProduct(id);

            if (res)
            {
                // On Successfull delete object it deletes coresponding images from server
                File.Delete(smallImg);
                File.Delete(largeImg);

                return true;
            }

            return false;
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public ProductEntity GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }

        public IEnumerable<ProductEntity> SearchByNameOrCategory(string key)
        {
            return _productRepo.SearchProductByTitleOrCategory(key);
        }

        public IEnumerable<ProductEntity> SortProductByCategory()
        {
            return _productRepo.SortByProductCategories();
        }

        public IEnumerable<ProductEntity> SortProductByName()
        {
            return _productRepo.SortByProductName();
        }

        public bool UpdateProduct(ProductEntity product, MultipartFormDataStreamProvider provider, string root)
        {
            try
            {

                if (provider.FileData != null || product != null)
                {

                    int id = product.Id;

                    foreach (var file in provider.FileData)
                    {
                        var name = file.Headers.ContentDisposition.FileName;
                        name = name.Trim('"');

                        var localFileName = file.LocalFileName;


                        var filePath = Path.Combine(root, name);

                        if (file.Headers.ContentDisposition.Name.Trim('\"') == "SmallImg")
                        {

                            // Get the path to delete previews small-image and delete it
                            string smallImgPath = _productRepo.GetProductById(id).Small_Image;
                            File.Delete(smallImgPath);

                            product.Small_Image = filePath;
                            
                        }

                        if (file.Headers.ContentDisposition.Name.Trim('\"') == "LargeImg")
                        {

                            // Get the path to delete previews large-image and delete it
                            string largeImgPath = _productRepo.GetProductById(id).Large_Image;
                            File.Delete(largeImgPath);

                            product.Large_Image = filePath;
                             
                        }

                        // Move to the storage location
                        File.Move(localFileName, filePath);

                        
                    }

                    logger.Info("File Deleted and updated..." + DateTime.Now);
                    _productRepo.UpdateProduct(product);

                    return true;
                }

                return false;

            }
            catch (Exception e)
            {
                logger.ErrorException("Error while updating Data..." + DateTime.Now, e);
                return false;
            }

        }

    }
}
