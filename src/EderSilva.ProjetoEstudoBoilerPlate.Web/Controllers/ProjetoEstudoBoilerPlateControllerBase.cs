using Abp.AspNetCore.Mvc.Controllers;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Controllers
{
    public abstract class ProjetoEstudoBoilerPlateControllerBase: AbpController
    {
        protected ProjetoEstudoBoilerPlateControllerBase()
        {
            LocalizationSourceName = ProjetoEstudoBoilerPlateConsts.LocalizationSourceName;
        }
    }
}