namespace MVC_NLayerProject.UI.Models.VMs.ArticleVMs
{
    public class UserArticleVM
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public double AvgReadingTime { get; set; }
        public string UserName { get; set; }
    }
}
