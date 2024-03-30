namespace Products_Web.Models.Product
{
    public class CreatePushUpViewModel
    {
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string Type { get; set; }

        public CreatePushUpViewModel()
        { }

        public CreatePushUpViewModel(string name, string difficulty, string type)
        {
            Name = name;
            Difficulty = difficulty;
            Type = type;
        }
    }
}
