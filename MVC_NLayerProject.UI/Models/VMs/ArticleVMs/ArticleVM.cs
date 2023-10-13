using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_NLayerProject.UI.Models.VMs.ArticleVMs
{
    public class ArticleVM
    {
        public int Id { get; set; }
        [DisplayName("Başlık")]
        public string Header { get; set; }
        [DisplayName("İçerik")]
        public string Content { get; set; }
        [DisplayName("Ortalama Okuma Süresi")]
        public double AvgReadingTime { get; set; }
        public string UserId { get; set; }
    }
}
