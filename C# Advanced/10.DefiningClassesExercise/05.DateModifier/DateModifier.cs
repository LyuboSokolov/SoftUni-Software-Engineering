using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public string CalculateDiferensBetweenTwoData(string startData,string endData)
        {
            int diference = int.Parse(((DateTime.Parse(startData) - DateTime.Parse(endData)).TotalDays).ToString());
            diference = Math.Abs(diference);
            
            return diference.ToString();
        }
    }
}
