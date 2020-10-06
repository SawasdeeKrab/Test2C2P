using System.Data.Entity;
using GenericRepository.Interface;

namespace GenericRepository.Implement
{
    public class DatabaseContext : IDatabaseContext
    {
        private DbContext _context;
        
        public DatabaseContext(DbContext context)
        {
            _context = context;
        }

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }
    }
}
