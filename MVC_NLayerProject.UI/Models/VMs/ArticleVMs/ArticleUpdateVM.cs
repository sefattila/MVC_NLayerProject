using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MVC_NLayerProject.BLL.DTOs.UserDTOs;
using MVC_NLayerProject.UI.Models.VMs.UserVMs;
using MVC_NLayerProject.CORE.Entities;
using MVC_NLayerProject.UI.Models.VMs.SubjectVMs;

namespace MVC_NLayerProject.UI.Models.VMs.ArticleVMs
{
    public class ArticleUpdateVM
    {
        public int Id { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "Başlık Girmek Zorunludur")]
        public string Header { get; set; }
        [DisplayName("İçerik")]
        [Required(ErrorMessage = "İçerik Yazmak Zorunlu")]
        [StringLength(300, ErrorMessage = "Min:10 Max:300", MinimumLength = 10)]
        public string Content { get; set; }
        public int SubjectId { get; set; }
        public IList<SubjectVM> Subjects { get; set; }

        public UserVM AppUser { get; set; }
    }
}
