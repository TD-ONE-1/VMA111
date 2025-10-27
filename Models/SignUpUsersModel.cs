namespace RMS.Models
{
    public class SignUpUsersModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime? Date { get; set; }

        public bool? Status { get; set; }
    }
}
