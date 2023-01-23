using System.ComponentModel.DataAnnotations.Schema;

namespace task2fromcode.Models
{
    public class Dlocations
    {
      
        public string Dlocation { get; set; }
        //fkey
        [ForeignKey("Department")]
        public int? Dnum { get; set; }
        //public int DepartmentDnum { get; set; }
        public virtual department? Department { get; set; }
    }
}
