using System.Data.Entity;

namespace GenericRepository.Interface
{
    public interface IDatabaseContext
    {
        DbContext Context { get; }
    }
}
