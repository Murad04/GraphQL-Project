using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; } = null!;
        [Required]
        public string CommandLine { get; set; } = null!;
        public int PlatformID { get; set; }
        public Platform Platform { get; set; } = null!;
    }
}
