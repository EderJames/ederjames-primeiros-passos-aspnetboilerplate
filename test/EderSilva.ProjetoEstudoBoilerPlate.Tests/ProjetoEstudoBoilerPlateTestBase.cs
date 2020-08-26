using System;
using System.Threading.Tasks;
using Abp.TestBase;
using EderSilva.ProjetoEstudoBoilerPlate.EntityFrameworkCore;
using EderSilva.ProjetoEstudoBoilerPlate.Tests.TestDatas;

namespace EderSilva.ProjetoEstudoBoilerPlate.Tests
{
    public class ProjetoEstudoBoilerPlateTestBase : AbpIntegratedTestBase<ProjetoEstudoBoilerPlateTestModule>
    {
        public ProjetoEstudoBoilerPlateTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<ProjetoEstudoBoilerPlateDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<ProjetoEstudoBoilerPlateDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<ProjetoEstudoBoilerPlateDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ProjetoEstudoBoilerPlateDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<ProjetoEstudoBoilerPlateDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<ProjetoEstudoBoilerPlateDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<ProjetoEstudoBoilerPlateDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<ProjetoEstudoBoilerPlateDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
