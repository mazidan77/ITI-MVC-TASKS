using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task2fromcode.Models
{
    public class projectVM
    {

        [Display(Name = "Project Number")]
        [Required]

        public int Pnumber { get; set; }


        [Display(Name = "Project Name")]
        [Required]
        [MinLength(5)]
        public string? Name { get; set; }


        [Display(Name = "Project Location")]
        [Required]
        [Remote("locationname", "customvalidation",ErrorMessage ="ONLY (cairo - alex - giza ) are allowe")]
        public string? location { get; set; }

        [Display(Name = "Confirm Location")]
        [Compare("location", ErrorMessage = "location doesnot match")]
        public string? Confirmlocation { get; set; }

    }
}
