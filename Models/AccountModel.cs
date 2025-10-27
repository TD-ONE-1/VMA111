namespace RMS.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string UserCode { get; set; } = null!;

        public string username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool isActive { get; set; }

        public DateTime? creationDate { get; set; }

        public string? createdBy { get; set; }
    }
}