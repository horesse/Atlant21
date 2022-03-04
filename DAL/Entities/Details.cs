using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Details
    {
        public int Id { get; set; }
        [Required]
        public string Num { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int KeepersId { get; set; }
        public virtual Keepers Keepers { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public Nullable<DateTime> DeleteDate { get; set; }
    }
}
