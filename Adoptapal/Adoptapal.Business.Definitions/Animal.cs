using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Adoptapal.Business.Definitions
{
    public class Animal
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Required")]
        public string AnimalCategory { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Required")]
        public bool IsMale { get; set; }

        [Required(ErrorMessage = "Required")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ImageFilePath { get; set; }

        public User? User { get; set; }

        // hier später nicht gespeichert? -wo dann?
        [DefaultValue(false)]
        public bool MarkedAsFavouriteByUser { get; set; }
    }
}
