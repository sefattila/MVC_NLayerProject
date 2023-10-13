using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_NLayerProject.UI.Models.VMs.UserVMs
{
    public class UserLogInVM
    {
        [DisplayName("E Posta")]
        [Required(ErrorMessage = "E Posta Girmek Zorunlu")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }
    }
}
