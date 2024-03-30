namespace Products_Web.Models.Product
{
    public class SquatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string Type { get; set; }

        public SquatViewModel()
        {

        }

        public SquatViewModel(int id, string name, string difficulty, string type)
        {
            Id = id;
            Name = name;
            Difficulty = difficulty;
            Type = type;

        }
    }
}
