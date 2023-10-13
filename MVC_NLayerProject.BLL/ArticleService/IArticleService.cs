using MVC_NLayerProject.BLL.DTOs.ArticleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.BLL.ArticleService
{
    public interface IArticleService
    {
        void Create(ArticleCreateDTO articleCreateDTO);
        void Update(ArticleUpdateDTO articleUpdateDTO);
        void Delete(int id);
        ArticleDTO GetById(int id);
        IList<ArticleDTO> GetActives();
        IList<ArticleDTO> GetAll();
        IList<ArticleDTO> CurrentUserArticles(string userId);
    }
}
