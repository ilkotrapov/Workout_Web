namespace Products_Web.Models.Product
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string Type { get; set; }

        public ExerciseViewModel()
        {

        }

        public ExerciseViewModel(int id, string name, string difficulty, string type)
        {
            Id = id;
            Name = name;
            Difficulty = difficulty;
            Type = type;

        }
    }
}
