using GenericRepository.Base;
using GenericRepository.Interface;
using Test2C2P.Data.Entities;
using Test2C2P.Data.Interfaces;

namespace Test2C2P.Data.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IDatabaseContext dataContext) : base(dataContext)
        {

        }
    }
}
