using GastosRegisterO.Data;
using GastosRegisterO.IRepository;

namespace GastosRegisterO.CRepository
{
    public class CContainer : IContainer
    {
        private readonly ApplicationDbContext _context;
        public CContainer(ApplicationDbContext context)
        {
            _context=context;
            gastosRepository = new CGastosRepository(_context);
        }
        public IGastosRepository gastosRepository {get; set;}

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
