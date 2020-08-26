using Abp.AspNetCore.Mvc.Views;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Views
{
    public abstract class ProjetoEstudoBoilerPlateRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected ProjetoEstudoBoilerPlateRazorPage()
        {
            LocalizationSourceName = ProjetoEstudoBoilerPlateConsts.LocalizationSourceName;
        }
    }
}
