using System.ComponentModel.DataAnnotations;

namespace Products_Web.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
        
        [Required]
        public int Stock { get; set; }

        public Product() 
        { }

        public Product(int id, string name, double price, int stock)
            : this(name, price, stock)
        {
            Id = id;
        }

        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override bool Equals(object? other)
            => Equals((Product)other);

        public bool Equals(Product other)
            => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            Price == other.Price &&
            Stock == other.Stock;
    }
}
