using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Keepers
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Details> Details { get; set; }
    }
}
