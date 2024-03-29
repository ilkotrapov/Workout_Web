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
        {

        }

        public CreateProductViewModel(
            string name, 
            double price,
            int stock,
            string nutritionInformation,
            DateTime expirationDate)
        {
            Name = name;
            Price = price;
            Stock = stock;
            NutritionInformation = nutritionInformation;
            ExpirationDate = expirationDate;
        }
    }
}
