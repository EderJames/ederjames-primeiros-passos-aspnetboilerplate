using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EderSilva.ProjetoEstudoBoilerPlate.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EderSilva.ProjetoEstudoBoilerPlate
{
    public interface ICadeiraAppService : IApplicationService
    {
        Task<ListResultDto<CadeiraListDto>> GetAll(GetAllCadeirasInput input);
    }
}
