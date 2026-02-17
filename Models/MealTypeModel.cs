namespace RMS.Models
{
    public class MealTypeModel
    {
        public int Id { get; set; }

        public string MealTypeName { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
