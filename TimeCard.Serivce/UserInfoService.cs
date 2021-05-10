using TimeCard.IRepository;
using TimeCard.IService;
using TimeCard.Model;

namespace TimeCard.Serivce
{
    public class UserInfoService : BaseService<UserInfo> , IUserInfoService
    {
        public UserInfoService(IUserInfoRepository iUserInfoRepository)
        {
            base._iBaseRepository = iUserInfoRepository;
        }
    }
}