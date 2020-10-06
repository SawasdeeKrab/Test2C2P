using System.IO;
using Test2C2P.Data.Interfaces;

namespace Test2C2P.Api.Services
{
    public interface IFileImport
    {
        void CSV(Stream fileStream);
        void XML(Stream fileStream);
    }
}
