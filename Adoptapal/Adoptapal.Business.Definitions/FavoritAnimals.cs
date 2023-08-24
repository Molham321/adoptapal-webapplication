using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adoptapal.Business.Definitions
{
    public class FavoritAnimals
    {
        public Guid Id { get; set; }
        public User? User { get; set; }
        public Animal? Animal { get; set; }
    }
}
