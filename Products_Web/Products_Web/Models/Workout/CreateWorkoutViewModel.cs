namespace Products_Web.Models.Workout
{
    public class CreateWorkoutViewModel
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Place { get; set; }

        public CreateWorkoutViewModel()
        { }

        public CreateWorkoutViewModel(string name, string duration, string place)
        {
            Name = name;
            Duration = duration;
            Place = place;
        }
    }
}
