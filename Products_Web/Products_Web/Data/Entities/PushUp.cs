using System.ComponentModel.DataAnnotations;

namespace Products_Web.Data.Entities
{
    public class PushUp
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Difficulty { get; set; }

        [Required]
        public string Type { get; set; }

        public PushUp()
        { }

        public PushUp(int id, string name, string difficulty, string type)
            : this(name, difficulty, type)
        {
            Id = id;
        }

        public PushUp(string name, string difficulty, string type)
        {
            Name = name;
            Difficulty = difficulty;
            Type = type;
        }

        public override bool Equals(object? other)
            => Equals((PushUp)other);

        public bool Equals(PushUp other)
            => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            Difficulty == other.Difficulty &&
            Type == other.Type;
    }
}

