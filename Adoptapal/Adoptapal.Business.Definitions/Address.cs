
namespace Adoptapal.Business.Definitions
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
