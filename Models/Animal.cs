namespace adoptapal.Models
{
    public class Animal
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public string Birthday { set; get; }

        public string Supplier { set; get; }

        public string Category { set; get; }

        public bool MarkedAsFavorite { set; get; }

        public string Color { set; get; }

        public string ImagePath { set; get; }

        public bool IsMale { set; get; }

        public float Weight { set; get; }
    }
}
