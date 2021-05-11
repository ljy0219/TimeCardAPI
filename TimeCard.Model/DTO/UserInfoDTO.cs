using System;

namespace TimeCard.Model.DTO
{
    public class UserInfoDTO
    {
        public string UserName { get; set; }
        
        public string UserType { get; set; } 
        
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}