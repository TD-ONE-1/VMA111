namespace RMS.Models
{
    public class AccountJVModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int UserTypeId { get; set; }

        public int BusinessId { get; set; }

        public bool isActive { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreatedBy { get; set; } = null!;
    }
}
