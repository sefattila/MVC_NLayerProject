using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.BLL.DTOs.ArticleDTOs
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public double AvgReadingTime { get; set; }
        public string UserId { get; set; }
    }
}
