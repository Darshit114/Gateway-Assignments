using PMS.Entities;
using System.Collections.Generic;
using System.Net.Http;

namespace PMS.BLL
{
    public interface IProductBLL
    {
        bool AddProduct(ProductEntity product);
        IEnumerable<ProductEntity> GetAllProducts();
        ProductEntity GetProductById(int id);
        bool UpdateProduct(ProductEntity product, MultipartFormDataStreamProvider provider, string root);
        bool DeleteProduct(int id);
        IEnumerable<ProductEntity> SortProductByName();
        IEnumerable<ProductEntity> SortProductByCategory();
        IEnumerable<ProductEntity> SearchByNameOrCategory(string key);
        bool DeleteMultipleProducts(List<int> list);
    }
}
