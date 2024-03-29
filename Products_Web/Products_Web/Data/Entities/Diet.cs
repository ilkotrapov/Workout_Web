using System.ComponentModel.DataAnnotations;

namespace Products_Web.Data.Entities
{
    public class Diet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Duration { get; set; }
        
        [Required]
        public string Description { get; set; }

        public Diet() 
        { }

        public Diet(int id, string name, string duration, string description)
            : this(name, duration, description)
        {
            Id = id;
        }

        public Diet(string name, string duration, string description)
        {
            Name = name;
            Duration = duration;
            Description = description;
        }

        public override bool Equals(object? other)
            => Equals((Diet)other);

        public bool Equals(Diet other)
            => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            Duration == other.Duration &&
            Description == other.Description;
    }
}
