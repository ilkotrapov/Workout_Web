namespace Products_Web.Models.Product
{
    public class CreatePullUpViewModel
    {
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string Type { get; set; }

        public CreatePullUpViewModel()
        { }

        public CreatePullUpViewModel(string name, string difficulty, string type)
        {
            Name = name;
            Difficulty = difficulty;
            Type = type;
        }
    }
}
