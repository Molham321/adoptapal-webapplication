
using System.ComponentModel.DataAnnotations;

namespace Adoptapal.Business.Definitions
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        // FirstName? Lastname?

        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "EmailAddress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required")]
        [Compare("Password", ErrorMessage = "Compare")]
        public string ConfirmPassword { get; set; }

        //public string gender { get; set; }
        // vielleicht als enum? 
        // wird das gebraucht ?
        // ist das notig?
        public Address? Address { get; set; }
    }
}
