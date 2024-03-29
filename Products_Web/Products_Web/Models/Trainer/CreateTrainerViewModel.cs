namespace Products_Web.Models.Product
{
    public class CreateTrainerViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gym { get; set; }

        public CreateTrainerViewModel(string name, string email, string gym)
        {
            Name = name;
            Email = email;
            Gym = gym;
        }
    }
}
