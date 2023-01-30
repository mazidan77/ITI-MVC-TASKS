using System.ComponentModel.DataAnnotations;
using task2fromcode.Models;

namespace task2fromcode.CustomAttribute
{
    public class uniqueAttribute:ValidationAttribute
    {
        companyDBcontext DB = new companyDBcontext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int? pnum =(int) value ;

           bool invalid = DB.Projects.Any(x=>x.Pnumber== pnum);

            if (invalid)
            {
                return new ValidationResult("this project number already taken");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }
}
