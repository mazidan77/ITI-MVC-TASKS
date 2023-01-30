using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using task2fromcode.CustomAttribute;

namespace task2fromcode.Models
{
    public class projectVM
    {

        [Display(Name = "Project Number")]
        [Required]
        [unique]
        public int Pnumber { get; set; }


        [Display(Name = "Project Name")]
        [Required]
        [MinLength(5, ErrorMessage = "Project must have at least 5 characters")]
        public string? Name { get; set; }


        [Display(Name = "Project Location")]
        [Required]
        [Remote("locationname", "customvalidation",ErrorMessage ="ONLY (cairo - alex - giza ) are allowed")]
        public string? location { get; set; }

        [Display(Name = "Confirm Location")]
        [Compare("location", ErrorMessage = "location doesn't match")]
        public string? Confirmlocation { get; set; }

    }
}
