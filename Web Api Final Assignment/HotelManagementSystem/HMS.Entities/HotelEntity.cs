using System;
using System.Collections.Generic;

namespace HMS.Entities
{
    public class HotelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string ContactNumner { get; set; }
        public string ContactPerson { get; set; }
        public string Website { get; set; }
        public string FacebookPage { get; set; }
        public string TwitterAccount { get; set; }
        public string IsActive { get; set; }
        public Nullable<System.DateTime> CreatedeAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Navigation properties
        public ICollection<RoomEntity> Rooms { get; set; }
    }
}
