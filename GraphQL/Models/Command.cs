using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        public string HowTo { get; set; } = null!;
        public string CommandLine { get; set; } = null!;
        public int PlatformID { get; set; }
        public Platform Platform { get; set; } = null!;
    }
}
