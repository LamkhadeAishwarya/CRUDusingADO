using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Student
    {
       public int Rno { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City{ get; set; }
        [Required]
        public int Per { get; set; }
    }
}
