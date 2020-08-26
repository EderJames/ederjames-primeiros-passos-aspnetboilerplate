using EderSilva.ProjetoEstudoBoilerPlate.Configuration;
using EderSilva.ProjetoEstudoBoilerPlate.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EderSilva.ProjetoEstudoBoilerPlate.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class ProjetoEstudoBoilerPlateDbContextFactory : IDesignTimeDbContextFactory<ProjetoEstudoBoilerPlateDbContext>
    {
        public ProjetoEstudoBoilerPlateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProjetoEstudoBoilerPlateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(ProjetoEstudoBoilerPlateConsts.ConnectionStringName)
            );

            return new ProjetoEstudoBoilerPlateDbContext(builder.Options);
        }
    }
}