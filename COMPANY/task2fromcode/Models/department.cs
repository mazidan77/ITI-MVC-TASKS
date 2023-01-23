
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace task2fromcode.Models
{
    public class department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dnum { get; set; }
        public string? DName { get; set; }

        public virtual List<project>? Projects { get; set; } = new List<project>();

        public virtual List<Dlocations>? DLocations { get; set; }= new List<Dlocations>() ;
        //////////////////////////////////////////////
        ///
        public virtual List<employee> Employees { get; } = new List<employee>();
        public virtual employee Employee { get; set; }


        [ForeignKey("Employee")]
        public int? manageid { get; set; }


    }
}
