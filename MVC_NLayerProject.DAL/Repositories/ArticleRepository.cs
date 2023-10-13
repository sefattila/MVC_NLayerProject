using MVC_NLayerProject.CORE.Entities;
using MVC_NLayerProject.CORE.Repositories;
using MVC_NLayerProject.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.DAL.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
