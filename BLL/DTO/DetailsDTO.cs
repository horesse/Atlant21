using System;

namespace BLL.DTO
{
    public class DetailsDTO
    {
        public int Id { get; set; }
        public string Num { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int KeepersId { get; set; }
        public DateTime CreateDate { get; set; }
        public Nullable<DateTime> DeleteDate { get; set; }
    }
}
