using ProductEntity = Products_Web.Data.Entities.Product;


namespace Products_Web.Models.Product
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public string NutritionInformation { get; set; }

        public DateTime ExpirationDate { get; set; }

        public CreateProductViewModel()
        { }

        public CreateProductViewModel(ProductEntity product)
        {
            Name = product.Name;
            Price = product.Price;
            Stock = product.Stock;
            NutritionInformation = product.Details.NutritionInformation;
            ExpirationDate = product.Details.ExpirationDate;
        }
    }
}