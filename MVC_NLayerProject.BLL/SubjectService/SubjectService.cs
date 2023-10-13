using AutoMapper;
using MVC_NLayerProject.BLL.DTOs.SubjectDTOs;
using MVC_NLayerProject.CORE.Entities;
using MVC_NLayerProject.CORE.Enums;
using MVC_NLayerProject.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NLayerProject.BLL.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public IList<SubjectDTO> GetActive()
        {
            IList<Subject> subject = _subjectRepository.GetDefaults(x => x.Status != Status.Passive);
            IList<SubjectDTO> subjectDTOs=_mapper.Map<IList<SubjectDTO>>(subject);
            return subjectDTOs;
        }
    }
}
