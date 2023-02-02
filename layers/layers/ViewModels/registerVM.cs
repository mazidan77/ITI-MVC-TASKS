using System.ComponentModel.DataAnnotations;

namespace layers.ViewModels
{
    public class registerVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="password not matched")]
        public string confirmpassword { get; set; }


    }
}
