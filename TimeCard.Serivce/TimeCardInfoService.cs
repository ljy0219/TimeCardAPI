using TimeCard.IRepository;
using TimeCard.IService;
using TimeCard.Model;

namespace TimeCard.Serivce
{
    public class TimeCardInfoService : BaseService<TimeCards>, ITimeCardInfoService
    {
        private readonly ITimeCardInfoRepository _iTimeCardInfoRepository;
        public TimeCardInfoService(ITimeCardInfoRepository iTimeCardInfoRepository)
        {
            base._iBaseRepository = iTimeCardInfoRepository;
            _iTimeCardInfoRepository = iTimeCardInfoRepository;
        }
    }
}