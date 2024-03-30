namespace Products_Web.Models.Product
{
    public class TrainerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gym { get; set; }

        public TrainerViewModel()
        {

        }

        public TrainerViewModel(int id, string name, string email, string gym)
        {
            Id = id;
            Name = name;
            Email = email;
            Gym = gym;

        }
    }
}
