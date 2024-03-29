namespace Products_Web.Models.Product
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Place { get; set; }


        public WorkoutViewModel()
        {

        }

        public WorkoutViewModel(int id, string name, string duration, string place)
        {
            Id = id;
            Name = name;
            Duration = duration;
            Place = place;

        }
    }
}
