using System.ComponentModel.DataAnnotations;

namespace Products_Web.Data.Entities
{
    public class ProductDetails
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public string NutritionInformation { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public virtual Product Product { get; set; }

        public ProductDetails()
        {
        }

        public ProductDetails(int id, string nutritionInformation, DateTime expirationDate)
            : this(nutritionInformation, expirationDate)
        {
            Id = id;
        }

        public ProductDetails(string nutritionInformation, DateTime expirationDate)
        {
            NutritionInformation = nutritionInformation;
            ExpirationDate = expirationDate;
        }
    }
}