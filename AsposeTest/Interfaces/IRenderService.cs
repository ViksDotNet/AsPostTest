using Hangfire.Server;
using System.Threading.Tasks;

namespace AsposeTest.Interfaces
{
    public interface IRenderService
    {
        Task ProcessZavacorReportRequest();
    }
}
