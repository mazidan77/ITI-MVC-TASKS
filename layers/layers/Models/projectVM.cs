using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace layers.Models
{
    public class projectVM
    {

        [Display(Name = "Project Number")]
        [Required]
    
        public int Pnumber { get; set; }


        [Display(Name = "Project Name")]
        [Required]
        [MinLength(5, ErrorMessage = "Project must have at least 5 characters")]
        public string? Name { get; set; }


        [Display(Name = "Project Location")]
        [Required]
     
        public string? location { get; set; }

        [Display(Name = "Confirm Location")]
        [Compare("location", ErrorMessage = "location doesn't match")]
        public string? Confirmlocation { get; set; }

    }
}
