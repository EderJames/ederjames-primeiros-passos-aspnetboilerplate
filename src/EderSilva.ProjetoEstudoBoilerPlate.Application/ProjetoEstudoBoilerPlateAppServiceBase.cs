using Abp.Application.Services;

namespace EderSilva.ProjetoEstudoBoilerPlate
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ProjetoEstudoBoilerPlateAppServiceBase : ApplicationService
    {
        protected ProjetoEstudoBoilerPlateAppServiceBase()
        {
            LocalizationSourceName = ProjetoEstudoBoilerPlateConsts.LocalizationSourceName;
        }
    }
}