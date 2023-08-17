
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Adoptapal.Business.Definitions
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2}.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "please enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number and one special character.")]
        public string? Password { get; set; }

        public string? ResetToken { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public string? PhotoPath { get; set; }

        [Display(Name = "Address")]
        public Address? Address { get; set; }
    }
}
