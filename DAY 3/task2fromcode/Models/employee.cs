using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace task2fromcode.Models
{
    public class employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SSN { get; set; }
        [StringLength(50)]
        public string? Fname { get; set; }
        [StringLength(50)]
        public string? Mname { get; set; }
        [StringLength(50)]
        public string? Lname { get; set; }
        [StringLength(20)]
        public string? sex { get; set; }
        [StringLength(100)]
        public string? address { get; set; }

        public int? salary { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Bdate { get; set; }

        public virtual List<dependent>? dependents { get; set; } = new List<dependent>();

        public virtual List<workfor>? workfors { get; set; } = new List<workfor>();

        //fkey
        [ForeignKey("Employee")]
        public int? superid { get; set; }
        public virtual employee? Employee { get; set; }

        ////////////////////////////////////////////////
        ///
      public virtual department? ManageDepartment { get; set; }
        public virtual department? WorkDepartment { get; set; }

        //fkey
        [ForeignKey("WorkDepartment")]
        public int? workid { get; set; }

    }
}
