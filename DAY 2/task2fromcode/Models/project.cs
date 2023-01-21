using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2fromcode.Models
{
    public class project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pnumber { get; set; }
        public string? Name { get; set; }

        public string? location { get; set; }


        //FKEY
        public int? DepartmentDnum { get; set; }
        public virtual department? Department { get; set; }
        public virtual List<workfor>? workfor { get;} = new List<workfor>();


    }
}
