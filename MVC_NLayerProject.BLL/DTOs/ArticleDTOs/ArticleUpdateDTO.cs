using MVC_NLayerProject.BLL.DTOs.SubjectDTOs;
using MVC_NLayerProject.BLL.DTOs.UserDTOs;
using MVC_NLayerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.BLL.DTOs.ArticleDTOs
{
    public class ArticleUpdateDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int SubjectId { get; set; }
        public string UserId { get; set; }
        public IList<SubjectDTO> Subjects { get; set; }
        public UserDTO AppUser { get; set; }
    }
}
