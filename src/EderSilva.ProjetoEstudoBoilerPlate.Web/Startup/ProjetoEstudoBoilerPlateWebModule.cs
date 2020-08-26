using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EderSilva.ProjetoEstudoBoilerPlate.Configuration;
using EderSilva.ProjetoEstudoBoilerPlate.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Startup
{
    [DependsOn(
        typeof(ProjetoEstudoBoilerPlateApplicationModule), 
        typeof(ProjetoEstudoBoilerPlateEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class ProjetoEstudoBoilerPlateWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ProjetoEstudoBoilerPlateWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(ProjetoEstudoBoilerPlateConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<ProjetoEstudoBoilerPlateNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ProjetoEstudoBoilerPlateApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProjetoEstudoBoilerPlateWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ProjetoEstudoBoilerPlateWebModule).Assembly);
        }
    }
}