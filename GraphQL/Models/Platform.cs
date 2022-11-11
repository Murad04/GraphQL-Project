using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    [GraphQLDescription("Represents any software or service that has a CLI.")]
    public class Platform
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [GraphQLDescription("Represents a purchased, valid license for the platform.")]
        [Required]
        public string License { get; set; } = null!;

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
