namespace Products_Web.Models.Product
{
    public class CreateExerciseViewModel
    {
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public string Type { get; set; }

        public CreateExerciseViewModel()
        { }

        public CreateExerciseViewModel(string name, string difficulty, string type)
        {
            Name = name;
            Difficulty = difficulty;
            Type = type;
        }
    }
}
