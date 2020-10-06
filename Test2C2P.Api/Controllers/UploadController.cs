using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Test2C2P.Api.Services;
using Test2C2P.Data.Interfaces;

namespace Test2C2P.Api.Controllers
{
    public class UploadController : BaseController
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IFileImport fileImport;

        public UploadController(IPaymentRepository paymentRepository, IFileImport fileImport)
        {
            this.paymentRepository = paymentRepository;
            this.fileImport = fileImport;
        }
        [HttpPost]
        public IHttpActionResult UploadFile()
        {

            var file = HttpContext.Current.Request.Files.Count > 0 ?
                        HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var exttension = Path.GetExtension(file.FileName);

                switch (exttension.ToUpper())
                {
                    case ".CSV":
                        fileImport.CSV(file.InputStream);
                        break;
                    case ".XML":
                        fileImport.XML(file.InputStream);
                        break;
                    default:
                        return Content(HttpStatusCode.BadRequest, "Unknown format");
                }
            }

            return Content(HttpStatusCode.OK, "Upload completed");
        }

    }
}
