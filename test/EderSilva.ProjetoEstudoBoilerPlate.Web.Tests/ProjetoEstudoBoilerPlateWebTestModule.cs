using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EderSilva.ProjetoEstudoBoilerPlate.Web.Startup;
namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Tests
{
    [DependsOn(
        typeof(ProjetoEstudoBoilerPlateWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class ProjetoEstudoBoilerPlateWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProjetoEstudoBoilerPlateWebTestModule).GetAssembly());
        }
    }
}