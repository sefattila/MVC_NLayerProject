using MVC_NLayerProject.BLL.DTOs.SubjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.BLL.SubjectService
{
    public interface ISubjectService
    {
        IList<SubjectDTO> GetActive();
    }
}
