using MVC_NLayerProject.CORE.Abstracts;
using MVC_NLayerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.CORE.Entities
{
    public class Article : IBaseEntity
    {
        private string _content;


        public int Id { get; set; }
        public string Header { get; set; }
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                CalculateReadingTime();
            }
        }
        public double AvgReadingTime { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;
        public string UserId { get; set; }
        public int SubjectId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Subject Subject { get; set; }


        private void CalculateReadingTime()
        {
            const double wordsPerMinute = 5;

            int wordCount = Content.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            AvgReadingTime = wordCount / wordsPerMinute;
        }
    }
}
