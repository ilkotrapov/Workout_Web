using System.ComponentModel.DataAnnotations;

namespace Products_Web.Data.Entities
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Difficulty { get; set; }

        [Required]
        public string Type { get; set; }

        public Exercise()
        { }

        public Exercise(int id, string name, string difficulty, string type)
            : this(name, difficulty, type)
        {
            Id = id;
        }

        public Exercise(string name, string difficulty, string type)
        {
            Name = name;
            Difficulty = difficulty;
            Type = type;
        }

        public override bool Equals(object? other)
            => Equals((Exercise)other);

        public bool Equals(Exercise other)
            => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            Difficulty == other.Difficulty &&
            Type == other.Type;
    }
}

