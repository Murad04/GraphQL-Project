using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class Command
    {
        [key]
        public int Id { get; set; }
        public string HowTo { get; set; } = null!;
        public string CommandLine { get; set; } = null!;
        public int PlatformID { get; set; }
        public Platform Platform { get; set; } = null!;
    }
}
