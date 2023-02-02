using System.ComponentModel.DataAnnotations;

namespace layers.ViewModels
{
    public class loginVM
    {

        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isper { get; set; }


    }
}
