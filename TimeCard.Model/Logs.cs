using System;
using SqlSugar;

namespace TimeCard.Model
{
    public class Logs : BaseID
    {
        public int UserID { get; set; }
        
        [SugarColumn(ColumnDataType = "nvarchar(1000)")]
        public string Description { get; set; }
        
        [SugarColumn(IsIgnore = true)]
        public UserInfo UserInfo { get; set; }

    }
}