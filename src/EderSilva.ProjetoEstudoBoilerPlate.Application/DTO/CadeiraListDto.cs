using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace EderSilva.ProjetoEstudoBoilerPlate.DTO
{
    public class GetAllCadeirasInput
    {
        public CadeiraState? State { get; set; }
    }

    [AutoMapFrom(typeof(Cadeira))]
    public class CadeiraListDto : EntityDto, IHasCreationTime
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public CadeiraState State { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
