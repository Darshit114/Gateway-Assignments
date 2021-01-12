using PMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Repository
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<ProductEntity> GetAllProducts();
        ProductEntity GetProductById(int productId);
        bool AddProduct(ProductEntity product);
        bool UpdateProduct(ProductEntity product);
        bool DeleteProduct(int productId);
        IEnumerable<ProductEntity> SortByProductName();
        IEnumerable<ProductEntity> SortByProductCategories();
        IEnumerable<ProductEntity> SearchProductByTitleOrCategory(string key);
        bool DeleteMultipleProducts(List<int> list);
    }
}
