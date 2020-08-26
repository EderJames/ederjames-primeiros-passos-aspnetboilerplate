using Abp.Modules;
using Abp.Reflection.Extensions;
using EderSilva.ProjetoEstudoBoilerPlate.Localization;

namespace EderSilva.ProjetoEstudoBoilerPlate
{
    public class ProjetoEstudoBoilerPlateCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            ProjetoEstudoBoilerPlateLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProjetoEstudoBoilerPlateCoreModule).GetAssembly());
        }
    }
}