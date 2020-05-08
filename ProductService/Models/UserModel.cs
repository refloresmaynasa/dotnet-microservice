namespace ProductService.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserModel
    {
        public UserModel()
        {
        }
        public UserModel(string username, string name, string email, string token)
        {
            Username = username;
            Name = name;
            Email = email;
            Token = token;
        }
        [Required]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
