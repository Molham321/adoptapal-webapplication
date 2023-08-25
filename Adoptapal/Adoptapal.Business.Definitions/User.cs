/*
 * File: User.cs
 * Namespace: Adoptapal.Business.Definitions
 * 
 * Description:
 * This file defines the "User" entity class, representing users with properties including
 * name, email, password, reset token, phone number, photo path, and associated address.
 * 
 */

using System.ComponentModel.DataAnnotations;

namespace Adoptapal.Business.Definitions
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the reset token for the user's password reset.
        /// </summary>
        public string? ResetToken { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the photo path for the user's profile photo.
        /// </summary>
        public string? PhotoPath { get; set; }

        /// <summary>
        /// Gets or sets the address associated with the user.
        /// </summary>
        [Display(Name = "Address")]
        public Address? Address { get; set; }
    }
}
