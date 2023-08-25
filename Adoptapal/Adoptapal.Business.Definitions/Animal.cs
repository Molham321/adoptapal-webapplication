/*
 * File: Animal.cs
 * Namespace: Adoptapal.Business.Definitions
 * 
 * Description:
 * This file defines the "Animal" entity class, representing various attributes of an animal
 * available for adoption, such as its name, birthday, category, description, color, gender,
 * weight, image path, and associated user.
 * 
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Adoptapal.Business.Definitions
{
    /// <summary>
    /// Represents an animal available for adoption.
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Gets or sets the unique identifier for the animal.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the animal.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthday of the animal.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the category of the animal.
        /// </summary>
        public string? AnimalCategory { get; set; }

        /// <summary>
        /// Gets or sets the description of the animal.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the color of the animal.
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the animal is male.
        /// </summary>
        [Display(Name = "Is Male")]
        public bool? IsMale { get; set; }

        /// <summary>
        /// Gets or sets the weight of the animal.
        /// </summary>
        public float? Weight { get; set; }

        /// <summary>
        /// Gets or sets the file path for the animal's image.
        /// </summary>
        [DisplayName("Image")]
        public string? ImageFilePath { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the animal.
        /// </summary>
        public User? User { get; set; }
    }
}
