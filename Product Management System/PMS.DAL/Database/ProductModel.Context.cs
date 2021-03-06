﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMS.DAL.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProductDbEntities : DbContext
    {
        public ProductDbEntities()
            : base("name=ProductDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Products { get; set; }
    
        public virtual ObjectResult<usp_ProductsCRUD_Result> usp_ProductsCRUD(string actionName, Nullable<int> productId, string productName, string categoryName, Nullable<decimal> price, Nullable<long> quantity, string short_Description, string long_Description, string small_Img, string large_Img, Nullable<System.DateTime> createdAt, Nullable<System.DateTime> updatedAt)
        {
            var actionNameParameter = actionName != null ?
                new ObjectParameter("ActionName", actionName) :
                new ObjectParameter("ActionName", typeof(string));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(long));
    
            var short_DescriptionParameter = short_Description != null ?
                new ObjectParameter("Short_Description", short_Description) :
                new ObjectParameter("Short_Description", typeof(string));
    
            var long_DescriptionParameter = long_Description != null ?
                new ObjectParameter("Long_Description", long_Description) :
                new ObjectParameter("Long_Description", typeof(string));
    
            var small_ImgParameter = small_Img != null ?
                new ObjectParameter("Small_Img", small_Img) :
                new ObjectParameter("Small_Img", typeof(string));
    
            var large_ImgParameter = large_Img != null ?
                new ObjectParameter("Large_Img", large_Img) :
                new ObjectParameter("Large_Img", typeof(string));
    
            var createdAtParameter = createdAt.HasValue ?
                new ObjectParameter("CreatedAt", createdAt) :
                new ObjectParameter("CreatedAt", typeof(System.DateTime));
    
            var updatedAtParameter = updatedAt.HasValue ?
                new ObjectParameter("UpdatedAt", updatedAt) :
                new ObjectParameter("UpdatedAt", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_ProductsCRUD_Result>("usp_ProductsCRUD", actionNameParameter, productIdParameter, productNameParameter, categoryNameParameter, priceParameter, quantityParameter, short_DescriptionParameter, long_DescriptionParameter, small_ImgParameter, large_ImgParameter, createdAtParameter, updatedAtParameter);
        }
    }
}
