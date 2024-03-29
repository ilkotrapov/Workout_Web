using System.ComponentModel.DataAnnotations;

namespace Products_Web.Data.Entities
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Duration { get; set; }
        
        [Required]
        public string Place { get; set; }

        public Workout() 
        { }

        public Workout(int id, string name, string email, string place)
            : this(name, email, place)
        {
            Id = id;
        }

        public Workout(string name, string email, string place)
        {
            Name = name;
            Duration = email;
            Place = place;
        }

        public override bool Equals(object? other)
            => Equals((Workout)other);

        public bool Equals(Workout other)
            => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            Duration == other.Duration &&
            Place == other.Place;
    }
}
