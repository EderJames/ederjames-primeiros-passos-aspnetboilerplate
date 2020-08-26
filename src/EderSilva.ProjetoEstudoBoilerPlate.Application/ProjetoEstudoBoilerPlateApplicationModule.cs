using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace EderSilva.ProjetoEstudoBoilerPlate
{
    [DependsOn(
        typeof(ProjetoEstudoBoilerPlateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProjetoEstudoBoilerPlateApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProjetoEstudoBoilerPlateApplicationModule).GetAssembly());
        }
    }
}