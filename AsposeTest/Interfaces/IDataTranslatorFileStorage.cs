using System.Threading.Tasks;

namespace AsposeTest.Interfaces
{
    public interface IDataTranslatorFileStorage
    {
        Task<string> SavePDFFile(string htmlPropModel);
    }
}
