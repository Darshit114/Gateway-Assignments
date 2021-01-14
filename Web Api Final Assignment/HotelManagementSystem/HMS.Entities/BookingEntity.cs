namespace HMS.Entities
{
    public class BookingEntity
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public Status status { get; set; }
    }

    public enum Status
    {
        Optional,
        Definitive,
        Cancelled,
        Deleted
    }
}
