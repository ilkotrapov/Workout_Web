namespace Products_Web.Models.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public CreateProductViewModel(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
