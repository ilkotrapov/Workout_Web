namespace Products_Web.Models.Product
{
    public class CreateSquatViewModel
    {
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string Type { get; set; }

        public CreateSquatViewModel()
        { }

        public CreateSquatViewModel(string name, string difficulty, string type)
        {
            Name = name;
            Difficulty = difficulty;
            Type = type;
        }
    }
}
