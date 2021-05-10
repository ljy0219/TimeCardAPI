using System;
using System.Reflection.PortableExecutable;
using SqlSugar;

namespace TimeCard.Model
{
    public class TimeCards : BaseID
    {
        [SugarColumn(IsIgnore = true)]
        public UserInfo UserInfo { get; set; }

        public int UserID { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        [SugarColumn(ColumnDataType = "DECIMAL(3,1)")]
        public float Mon { get; set; }
        
        [SugarColumn(ColumnDataType = "DECIMAL(3,1)")]
        public float Tues { get; set; }
        
        [SugarColumn(ColumnDataType = "DECIMAL(3,1)")]
        public float Wed { get; set; }
        
        [SugarColumn(ColumnDataType = "DECIMAL(3,1)")]
        public float Thur { get; set; }
        
        [SugarColumn(ColumnDataType = "DECIMAL(3,1)")]
        public float Fri { get; set; }
        
        [SugarColumn(ColumnDataType = "DECIMAL(3,1)")]
        public float Sat { get; set; }
        
        [SugarColumn(ColumnDataType = "DECIMAL(3,1)")]
        public float Sun { get; set; }

        [SugarColumn(ColumnDataType = "DECIMAL(3,1)")]
        public float Total { get; set; }
    }
}