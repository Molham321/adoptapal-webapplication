/*
 * File: RegisterViewModel.cs
 * Namespace: Adoptapal.Web.Models
 * 
 * Description:
 * This file contains the implementation of the RegisterViewModel class, which is used
 * for user registration.
 * 
 */

using System.ComponentModel.DataAnnotations;

namespace Adoptapal.Web.Models
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2}.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "please enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number and one special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
