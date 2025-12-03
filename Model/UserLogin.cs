namespace PMS.Model
{
    public class UserLoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class UserRegisterModel
    {
        public int? Userid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}   