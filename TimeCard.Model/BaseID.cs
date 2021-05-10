using System;
using SqlSugar;

namespace TimeCard.Model
{
    public class BaseID
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}