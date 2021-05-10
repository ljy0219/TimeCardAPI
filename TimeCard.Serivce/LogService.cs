using TimeCard.IRepository;
using TimeCard.IService;
using TimeCard.Model;

namespace TimeCard.Serivce
{
    public class LogService : BaseService<Logs>, ILogService
    {
        public LogService(ILogRepository iLogRepository)
        {
            base._iBaseRepository = iLogRepository;
        }
    }
}