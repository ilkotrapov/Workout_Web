namespace Products_Web.Models.Product
{
    public class CreateDietViewModel
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }

        public CreateDietViewModel(string name, string duration, string description)
        {
            Name = name;
            Duration = duration;
            Description = description;
        }
    }
}
