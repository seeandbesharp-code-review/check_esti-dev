using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class User
    {
        [EmailAddress, Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
         public string Password { get; set; }
        public int Id { get; set; }
    }

    public class LogUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
