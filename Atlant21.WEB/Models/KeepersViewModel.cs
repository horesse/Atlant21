using System.ComponentModel.DataAnnotations;

namespace Atlant21.WEB.Models
{
    public class KeepersViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
