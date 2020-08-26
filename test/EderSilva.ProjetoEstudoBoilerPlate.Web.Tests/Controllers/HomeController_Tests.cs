using System.Threading.Tasks;
using EderSilva.ProjetoEstudoBoilerPlate.Web.Controllers;
using Shouldly;
using Xunit;

namespace EderSilva.ProjetoEstudoBoilerPlate.Web.Tests.Controllers
{
    public class HomeController_Tests: ProjetoEstudoBoilerPlateWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
