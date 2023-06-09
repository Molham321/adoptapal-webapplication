
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Adoptapal.Business.Definitions
{
    public class Animal
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2}.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public string? AnimalCategory { get; set; }

        public string? Description { get; set; }

        public string? Color { get; set; }

        public bool? IsMale { get; set; }

        public float? Weight { get; set; }

        public string? ImageFilePath { get; set; }

        public User? User { get; set; }
    }
}
