using GenericRepository.Implement;
using GenericRepository.Interface;
using System.Web.Http;
using Test2C2P.Data.Entities;

namespace Test2C2P.Api.Controllers
{
    public class BaseController : ApiController
    {
        public IDatabaseContext databaseContext;
        public TwoC2PEntity context;
        public BaseController()
        {
            context = new TwoC2PEntity();
            databaseContext = new DatabaseContext(context);
        }

    }
}
