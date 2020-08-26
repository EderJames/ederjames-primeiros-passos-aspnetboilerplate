using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Abp.AspNetCore.TestBase;
using EderSilva.ProjetoEstudoBoilerPlate.EntityFrameworkCore;
using EderSilva.ProjetoEstudoBoilerPlate.Tests.TestDatas;
using EderSilva.ProjetoEstudoBoilerPlate.Web.Controllers;
using EderSilva.ProjetoEstudoBoilerPlate.Web.Startup;
using EderSilva.ProjetoEstudoBoilerPlate.Web.Tests.Controllers;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shouldly;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Tests
{
    public abstract class ProjetoEstudoBoilerPlateWebTestBase : AbpAspNetCoreIntegratedTestBase<Startup>
    {
        protected static readonly Lazy<string> ContentRootFolder;

        static ProjetoEstudoBoilerPlateWebTestBase()
        {
            ContentRootFolder = new Lazy<string>(WebContentDirectoryFinder.CalculateContentRootFolder, true);
        }

        protected ProjetoEstudoBoilerPlateWebTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return base
                .CreateWebHostBuilder()
                .UseContentRoot(ContentRootFolder.Value)
                .UseSetting(WebHostDefaults.ApplicationKey, typeof(ProjetoEstudoBoilerPlateWebModule).Assembly.FullName);
        }

        #region Get response

        protected async Task<T> GetResponseAsObjectAsync<T>(string url,
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var strResponse = await GetResponseAsStringAsync(url, expectedStatusCode);
            return JsonConvert.DeserializeObject<T>(strResponse, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        protected async Task<string> GetResponseAsStringAsync(string url,
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var response = await GetResponseAsync(url, expectedStatusCode);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<HttpResponseMessage> GetResponseAsync(string url,
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var response = await Client.GetAsync(url);
            response.StatusCode.ShouldBe(expectedStatusCode);
            return response;
        }

        #endregion

        #region UsingDbContext

        protected void UsingDbContext(Action<ProjetoEstudoBoilerPlateDbContext> action)
        {
            using (var context = IocManager.Resolve<ProjetoEstudoBoilerPlateDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected T UsingDbContext<T>(Func<ProjetoEstudoBoilerPlateDbContext, T> func)
        {
            T result;

            using (var context = IocManager.Resolve<ProjetoEstudoBoilerPlateDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected async Task UsingDbContextAsync(Func<ProjetoEstudoBoilerPlateDbContext, Task> action)
        {
            using (var context = IocManager.Resolve<ProjetoEstudoBoilerPlateDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected async Task<T> UsingDbContextAsync<T>(Func<ProjetoEstudoBoilerPlateDbContext, Task<T>> func)
        {
            T result;

            using (var context = IocManager.Resolve<ProjetoEstudoBoilerPlateDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }

        #endregion

        #region ParseHtml

        protected IHtmlDocument ParseHtml(string htmlString)
        {
            return new HtmlParser().ParseDocument(htmlString);
        }

        #endregion
    }
}