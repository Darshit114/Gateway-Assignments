using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class RoomEntity
    {
        public int Id { get; set; }
        public int Hotel_Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string IsActive { get; set; }

        // Navigation Properties
        public ICollection<BookingEntity> Bookings { get; set; }
    }

    public enum Category
    {
        /// <summary>
        /// Size < 35 m2
        /// </summary>
        Category1 = 1,

        /// <summary>
        /// Size 36-50 m2
        /// </summary>
        Category2 = 2,

        /// <summary>
        /// Size 51-100 m2
        /// </summary>
        Category3 = 3
    }

}
