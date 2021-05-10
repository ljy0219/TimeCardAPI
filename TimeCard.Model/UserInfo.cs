using System;
using SqlSugar;

namespace TimeCard.Model
{
    public class UserInfo : BaseID
    {
        [SugarColumn(ColumnName = "nvarchar(30)")]
        public string UserName { get; set; }
        
        [SugarColumn(ColumnName = "nvarchar(100)")]
        public string UserPWD { get; set; }
        
        [SugarColumn(ColumnName = "nvarchar(10)")]
        public string UserType { get; set; } 
        
        public string Email { get; set; }
        
    }
}