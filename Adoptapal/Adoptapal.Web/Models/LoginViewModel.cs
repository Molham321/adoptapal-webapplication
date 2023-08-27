/*
 * File: LoginViewModel.cs
 * Namespace: Adoptapal.Web.Models
 * 
 * Description:
 * This file contains the implementation of the LoginViewModel class, which is used
 * to capture user input when logging in. It includes validation attributes to ensure
 * the provided data is valid.
 * 
 */

using System.ComponentModel.DataAnnotations;

namespace Adoptapal.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "please enter a valid email address")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number and one special character.")]
        public string? Password { get; set; }
    }
}
