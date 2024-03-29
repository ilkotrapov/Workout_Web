namespace Products_Web.Models.Product
{
    public class DietViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }

        public DietViewModel()
        {

        }

        public DietViewModel(int id, string name, string duration, string description)
        {
            Id = id;
            Name = name;
            Duration = duration;
            Description = description;

        }
    }
}
