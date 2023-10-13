using MVC_NLayerProject.CORE.Abstracts;
using MVC_NLayerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.CORE.Entities
{
    public class Subject : IBaseEntity
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;

        public virtual ICollection<Article> Articles { get; set; }
    }
}
