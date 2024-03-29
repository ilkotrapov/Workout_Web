using System.ComponentModel.DataAnnotations;

namespace Products_Web.Data.Entities
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Gym { get; set; }

        public Trainer() 
        { }

        public Trainer(int id, string name, string email, string gym)
            : this(name, email, gym)
        {
            Id = id;
        }

        public Trainer(string name, string email, string gym)
        {
            Name = name;
            Email = email;
            Gym = gym;
        }

        public override bool Equals(object? other)
            => Equals((Trainer)other);

        public bool Equals(Trainer other)
            => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            Email == other.Email &&
            Gym == other.Gym;
    }
}
