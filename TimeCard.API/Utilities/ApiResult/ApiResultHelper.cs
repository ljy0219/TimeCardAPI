namespace TimeCard.API.Utilities.ApiResult
{
    public  class ApiResultHelper
    {
        public static ApiResult Success(dynamic data,string msg)
        {
            return new ApiResult
            {
                Code = 200,
                Data = data,
                Msg = msg
            };
        }
        public static ApiResult Error(string msg)
        {
            return new ApiResult
            {
                Code = 500,
                Data = null,
                Msg = msg
            };
        }
    }
}