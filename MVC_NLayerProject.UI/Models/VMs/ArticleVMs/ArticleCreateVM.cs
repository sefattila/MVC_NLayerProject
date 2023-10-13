using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_NLayerProject.UI.Models.VMs.ArticleVMs
{
    public class ArticleCreateVM
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage ="Başlık Girmek Zorunludur")]
        public string Header { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage ="İçerik Yazmak Zorunlu")]
        [StringLength(300,ErrorMessage ="Min:10 Max:300",MinimumLength =10)]
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
