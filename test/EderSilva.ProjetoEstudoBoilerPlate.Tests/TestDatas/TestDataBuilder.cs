using EderSilva.ProjetoEstudoBoilerPlate.EntityFrameworkCore;

namespace EderSilva.ProjetoEstudoBoilerPlate.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly ProjetoEstudoBoilerPlateDbContext _context;

        public TestDataBuilder(ProjetoEstudoBoilerPlateDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}