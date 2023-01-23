using System.ComponentModel.DataAnnotations.Schema;

namespace task2fromcode.Models
{
    public class dependent
    {
        public string name { get; set; }



        public string? sex { get; set; }
        [Column (TypeName = "date")]
        public DateTime? Bdate { get; set; }

        public string relationship { get; set; }

        //foren key
        public int? EmployeeSSN { get; set; }
        public virtual employee? Employee { get; set; }


    }
}
