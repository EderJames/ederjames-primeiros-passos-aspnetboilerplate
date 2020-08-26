using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EderSilva.ProjetoEstudoBoilerPlate.DTO;
using EderSilva.ProjetoEstudoBoilerPlate.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Controllers
{
    public class CadeirasController : ProjetoEstudoBoilerPlateControllerBase
    {
        private readonly ICadeiraAppService _cadeiraAppService;

        public CadeirasController(ICadeiraAppService cadeiraAppService)
        {
            _cadeiraAppService = cadeiraAppService;
        }

        public async Task<ActionResult> Index(GetAllCadeirasInput input)
        {
            var output = await _cadeiraAppService.GetAll(input);
            var model = new IndexViewModel(output.Items)
            {
                //SelectedCadeiraState = input.State
            };
            return View("List", model);
        }
    }
}
