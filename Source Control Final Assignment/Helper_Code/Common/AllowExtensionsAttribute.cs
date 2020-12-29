using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Source_Control_Final_Assignment.Helper_Code.Common
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowExtensionsAttribute : ValidationAttribute
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        
        public string Extensions { get; set; } = "png,jpg,jpeg";

        public override bool IsValid(object value)
        {
            // Initialization
            HttpPostedFileBase file = value as HttpPostedFileBase;
            bool isValid = true;

            // Settings
            List<string> allowedExtentions = this.Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            // Verification
            if (file != null)
            {
                // Initialization
                var fileName = file.FileName;

                // Settings
                isValid = allowedExtentions.Any(y => fileName.EndsWith(y));
            }

            // Info
            return isValid;
        }
    }
}
