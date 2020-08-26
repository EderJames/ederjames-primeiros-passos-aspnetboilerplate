using Microsoft.EntityFrameworkCore;

namespace EderSilva.ProjetoEstudoBoilerPlate.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<ProjetoEstudoBoilerPlateDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for ProjetoEstudoBoilerPlateDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
