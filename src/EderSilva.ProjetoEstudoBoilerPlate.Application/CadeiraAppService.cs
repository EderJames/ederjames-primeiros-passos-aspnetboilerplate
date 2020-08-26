using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using EderSilva.ProjetoEstudoBoilerPlate.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EderSilva.ProjetoEstudoBoilerPlate
{
    public class CadeiraAppService : ProjetoEstudoBoilerPlateAppServiceBase, ICadeiraAppService
    {

        private readonly IRepository<Cadeira> _cadeiraRepository;

        public CadeiraAppService(IRepository<Cadeira> cadeiraRepository)
        {
            _cadeiraRepository = cadeiraRepository;
        }

        public async Task<ListResultDto<CadeiraListDto>> GetAll(GetAllCadeirasInput input)
        {
            var cadeiras = await _cadeiraRepository
                .GetAll()
                .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
                .OrderByDescending(t => t.CreationTime)
                .ToDynamicListAsync();

            return new ListResultDto<CadeiraListDto>(
                ObjectMapper.Map<List<CadeiraListDto>>(cadeiras));
        }

    }
}
