using System.ComponentModel.DataAnnotations;
//fix: Removed "using Zxcvbn;" - it is not used in this file (only in PasswordsController)
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

    //Each class goes in its own file, named after the class (for example LoginUser.cs).
    //A full name is clearer than an abbreviation: LoginUser instead of LogUser
    public class LogUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
