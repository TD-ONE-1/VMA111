namespace RMS.Models
{
    public class ConfirmSignUpModel
    {
        public int Id { get; set; }

        public string UserCode { get; set; } = null!;

        public string username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int UserTypeId { get; set; }

        public bool isActive { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreatedBy { get; set; } = null!;
    }
}
