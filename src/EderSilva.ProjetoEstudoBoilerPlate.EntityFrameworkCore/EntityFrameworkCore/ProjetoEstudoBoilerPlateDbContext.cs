using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EderSilva.ProjetoEstudoBoilerPlate.EntityFrameworkCore
{
    public class ProjetoEstudoBoilerPlateDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Cadeira> Cadeiras { get; set; }

        public ProjetoEstudoBoilerPlateDbContext(DbContextOptions<ProjetoEstudoBoilerPlateDbContext> options) 
            : base(options)
        {

        }
    }
}
