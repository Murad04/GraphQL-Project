using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Platform
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = null!;


        [Required]
        public string License { get; set; } = null!;

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
