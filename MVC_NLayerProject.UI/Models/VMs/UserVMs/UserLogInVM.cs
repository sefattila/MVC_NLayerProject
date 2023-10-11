using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_NLayerProject.UI.Models.VMs.UserVMs
{
    public class UserLogInVM
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Girmek Zorunlu")]
        public string UserName { get; set; }
        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }
    }
}
