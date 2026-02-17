namespace RMS.Models
{
    public class EidReservationModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int NoOfMembers { get; set; }

        public int BookingTypeId { get; set; }

        public int SlotId { get; set; }

        public int MealTypeId { get; set; }

        public bool SpecialRequest { get; set; }
    }
}
