using AutoMapper;
using NLog;
using PMS.DAL.Database;
using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PMS.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private readonly ProductDbEntities _productDbContext;

        public ProductRepository(ProductDbEntities productDbContext)
        {
            _productDbContext = productDbContext;
        } 

        public bool AddProduct(ProductEntity product)
        {
            if (product != null)
            {
                try
                { 
                   
                    _productDbContext.usp_ProductsCRUD("INSERT", null, product.Name,
                                                        product.Category, product.Price,
                                                        product.Quantity, product.Short_Description,
                                                        product.Long_Description, product.Small_Image,
                                                        product.Large_Image, DateTime.Now, null);
                    

                    return true;

               } catch(Exception e)
               {
                    logger.ErrorException("Error at Insert operation.." + DateTime.Now, e);
                    return false;
               }
                
            }

            return false;
        }

        public bool DeleteProduct(int id)
        {

            try
            {
                var data = _productDbContext.Products.FirstOrDefault(p => p.Id == id);

                if (data != null)
                {
                    _productDbContext.Products.Remove(data);
                    _productDbContext.SaveChanges();

                    return true;
                }

                return false;

            } catch (Exception e)
            {
                logger.ErrorException("Error at delete operation.." + DateTime.Now, e);
                return false;
            }
                
        }

        public IEnumerable<ProductEntity> GetAllProducts()
        {
            try
            {

                var products = _productDbContext.usp_ProductsCRUD("SELECT", null, null, null,
                                                                            null, null, null, null,
                                                                            null, null, null, null);
                List<ProductEntity> _products = new List<ProductEntity>();

                var iMapper = this.GetMapperInstance();

                foreach(var item in products.ToList())
                {
                    var product = iMapper.Map<usp_ProductsCRUD_Result, ProductEntity>(item);

                    _products.Add(product);
                }

                return _products;

            } catch (Exception e)
            {
                logger.ErrorException("Error at Getting data operation.." + DateTime.Now, e);
                throw e;
            }

        }

        public ProductEntity GetProductById(int productId)
        {
            try {

                var product = _productDbContext.Products.Find(productId);

                if(product != null)
                {
                    var iMapper = this.GetMapperInstance();

                    var item = iMapper.Map<Product, ProductEntity>(product);

                    return item;
                }

                return new ProductEntity();
                                
            }catch (Exception e)
            {
                logger.ErrorException("Error at getting single product operation.." + DateTime.Now, e);
                throw e;
            }
        }

        public bool UpdateProduct(ProductEntity product)
        {
            
            var iMapper = this.GetMapperInstance();

            var _product = iMapper.Map<ProductEntity, Product>(this.MapProductData(product));

            try
            {

                _productDbContext.usp_ProductsCRUD("UPDATE", _product.Id, _product.Name,
                                                             _product.Category, _product.Price,
                                                             _product.Quantity, _product.Short_Description,
                                                             _product.Long_Description, _product.Small_Image,
                                                             _product.Large_Image,null,DateTime.Now);
                return true;

            } catch(Exception e)
            {
                logger.ErrorException("Error at Update operation.." + DateTime.Now, e);
                return false;
            }             
        }

                
        public IEnumerable<ProductEntity> SortByProductName()
        {
            try
            {

                var iMapper = this.GetMapperInstance();

                List<ProductEntity> products = new List<ProductEntity>();

                var _products = (from p in _productDbContext.Products
                                 select p).OrderBy(p => p.Name); 

                foreach(var item in _products.ToList())
                {
                    var _product = iMapper.Map<Product, ProductEntity>(item);

                    products.Add(_product);
                }

                return products;

            } catch(Exception e)
            {
                logger.ErrorException("Error at SortingByName operation.." + DateTime.Now, e);
                throw e;
            }

        }

        public IEnumerable<ProductEntity> SortByProductCategories()
        {
            try
            {

                var iMapper = this.GetMapperInstance();

                List<ProductEntity> products = new List<ProductEntity>();

                var _products = (from p in _productDbContext.Products
                                 select p).OrderBy(p => p.Category);

                foreach (var item in _products.ToList())
                {
                    var _product = iMapper.Map<Product, ProductEntity>(item);

                    products.Add(_product);
                }

                return products;

            }
            catch (Exception e)
            {
                logger.ErrorException("Error at SortingByCategory operation.." + DateTime.Now, e);
                throw e;
            }
        }


        public IEnumerable<ProductEntity> SearchProductByTitleOrCategory(string key)
        {
            try
            {

                var iMapper = this.GetMapperInstance();

                List<ProductEntity> products = new List<ProductEntity>();


                var _products = (from p in _productDbContext.Products
                                 select p).Where(p => p.Name.Contains(key));


                foreach (var item in _products.ToList())
                {
                    var _product = iMapper.Map<Product, ProductEntity>(item);

                    products.Add(_product);
                }

                return products;

            }
            catch (Exception e)
            {
                logger.ErrorException("Error at Searching operation.." + DateTime.Now, e);
                throw e;
            }
        }

        public bool DeleteMultipleProducts(List<int> idList)
        {
            try
            {

                foreach(var id in idList)
                {
                    if (DeleteProduct(id))
                        continue;
                    else
                        return false;
                }

                return true;

            } catch (Exception e)
            {
                logger.ErrorException("Error at MultipleDelete operation.." + DateTime.Now, e);
                throw e;
            }
        }

        // Gives the instance of IMapper
        private IMapper GetMapperInstance()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductEntity, Product>();
                cfg.CreateMap<Product, ProductEntity>();
                cfg.CreateMap<usp_ProductsCRUD_Result, ProductEntity>();
            });

            IMapper iMapper = config.CreateMapper();

            return iMapper;
        }

        // Map the null values to existing values while updating Data
        private ProductEntity MapProductData(ProductEntity product)
        {
            var items = _productDbContext.Products.Where(p => p.Id == product.Id);

            Product _product = items.FirstOrDefault();

            if (product.Name == null)
            {
                product.Name = _product.Name;

            }
            else if (product.Category == null)
            {
                product.Category = _product.Category;

            }
            else if (product.Price.ToString() == null)
            {
                product.Price = _product.Price;

            }
            else if (product.Quantity.ToString() == null)
            {
                product.Quantity = _product.Quantity;

            }
            else if (product.Short_Description == null)
            {
                product.Short_Description = _product.Short_Description;

            }
            else if (product.Long_Description == null)
            {
                product.Long_Description = _product.Long_Description;

            }
            else if (product.Small_Image == null)
            {
                product.Small_Image = _product.Small_Image;

            }
            else if (product.Large_Image == null)
            {
                product.Large_Image = _product.Large_Image;

            }
            else if (product.CreatedAt == null)
            {
                product.CreatedAt = (DateTime)_product.CreatedAt;
            }

            return product;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        
    }
}
