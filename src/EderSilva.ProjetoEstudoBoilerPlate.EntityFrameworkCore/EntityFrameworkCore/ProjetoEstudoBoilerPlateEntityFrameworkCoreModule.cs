using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace EderSilva.ProjetoEstudoBoilerPlate.EntityFrameworkCore
{
    [DependsOn(
        typeof(ProjetoEstudoBoilerPlateCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class ProjetoEstudoBoilerPlateEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProjetoEstudoBoilerPlateEntityFrameworkCoreModule).GetAssembly());
        }
    }
}