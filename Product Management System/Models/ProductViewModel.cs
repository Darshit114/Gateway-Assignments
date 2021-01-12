using PMS.Entities;
using Product_Management_System.Helper_Code.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Product_Management_System.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please chose category")]
        [Display(Name = "Category")]
        public ProductsCategory Category { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter quantity")]
        [Display(Name = "Quantity")]
        public long Quantity { get; set; }

        [Required(ErrorMessage = "Please enter short description about product")]
        [Display(Name = "Short Description")]
        [MaxLength(255)]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        [MaxLength(1000)]
        public string LongDescription { get; set; }

        [Required]
        public string SmallImgUrl { get; set; }
        public string LargeImgUrl { get; set; }

        [Required(ErrorMessage = "Please upload image")]
        [Display(Name = "Upload Small Image")]
        [AllowFileSize(FileSize = 2 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 2 MB")]
        public HttpPostedFileBase smallImgFile { get; set; }

        [Display(Name = "Upload Large Image")]
        [AllowFileSize(FileSize = 8 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 8 MB")]
        public HttpPostedFileBase largeImgFile { get; set; }

    }

    public enum ProductsCategory
    {
        Computers_And_Accessories,
        Cameras_And_Photography,
        Mobiles_And_Accessories,
        Tablets,
        Headphones
    }
}