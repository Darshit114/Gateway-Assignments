using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace SourceControlAssignment1.Models
{
    [Bind(Exclude = "Id")]
    public class User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string UsrName { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public UserDBContext() { }

        public DbSet<User> Users { get; set; }
    }
}