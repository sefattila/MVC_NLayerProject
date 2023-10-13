using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MVC_NLayerProject.BLL.DTOs.ArticleDTOs;
using MVC_NLayerProject.CORE.Entities;
using MVC_NLayerProject.CORE.Enums;
using MVC_NLayerProject.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.BLL.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;

        public ArticleService(IArticleRepository articleRepository, IMapper mapper, IAppUserRepository appUserRepository)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _appUserRepository = appUserRepository;
        }

        public void Create(ArticleCreateDTO articleCreateDTO)
        {
            if (articleCreateDTO == null)
                throw new ArgumentNullException("Eklenecek Makale Bilgisi Yok");

            Article article = _mapper.Map<Article>(articleCreateDTO);
            article.AppUser = _appUserRepository.GetDefault(x => x.Id == article.UserId);

            _articleRepository.Create(article);
        }

        public IList<ArticleDTO> CurrentUserArticles(string userId)
        {
            //Kullanıcı Sildiği makaleleride görebilsin
            IList<Article> articles = _articleRepository.FilteredList(x => x.UserId == userId, y => y.OrderBy(m => m.Header));
            IList<ArticleDTO> articleDTOs = _mapper.Map<IList<ArticleDTO>>(articles);
            return articleDTOs;
        }

        public void Delete(int id)
        {
            Article article = _articleRepository.GetDefaultById(id);
            article.DeleteDate = DateTime.Now;
            article.Status = Status.Passive;
            _articleRepository.Delete(article);
        }

        public IList<ArticleDTO> GetActives()
        {
            IList<Article> articles = _articleRepository.GetDefaults(x => x.Status != Status.Passive);
            IList<ArticleDTO> articleDTOs = _mapper.Map<IList<ArticleDTO>>(articles);
            return articleDTOs;
        }

        public IList<ArticleDTO> GetAll()
        {
            IList<Article> articles = _articleRepository.GetAll();
            IList<ArticleDTO> articleDTOs = _mapper.Map<IList<ArticleDTO>>(articles);
            return articleDTOs;
        }

        public ArticleDTO GetById(int id)
        {
            Article article = _articleRepository.GetDefaultById(id);
            ArticleDTO articleDTO = _mapper.Map<ArticleDTO>(article);
            return articleDTO;
        }

        public void Update(ArticleUpdateDTO articleUpdateDTO)
        {
            if (articleUpdateDTO == null)
                throw new ArgumentNullException("Güncellenecek Makale Bilgisi Yok");
            Article article = _mapper.Map<Article>(articleUpdateDTO);
            article.UpdateDate = DateTime.Now;
            article.Status = Status.Modified;
            _articleRepository.Update(article);
        }
    }
}
