﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.BLL.DTOs.ArticleDTOs
{
    public class ArticleCreateDTO
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}