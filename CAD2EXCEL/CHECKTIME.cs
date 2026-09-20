using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAD2EXCEL
{
    class CHECKTIME
    {
        public static bool CHECKLICENSE(Double time)
        {
            bool CHECK = false;
            DateTime networkTime = DateTime.Now;
            string dateTimeString = networkTime.ToString("yyyy MM dd").Replace(" ", "");
            if(time-Double.Parse(dateTimeString)>0)
            {
                CHECK = true;
            }
            return CHECK;
        }
        public static double date(Double time1)
        {
            double CHECK1;
            DateTime networkTime = NtpTime.GetNetworkTime();
            string dateTimeString = networkTime.ToString("yyyy MM dd").Replace(" ", "");
          
                CHECK1 = time1 - Double.Parse(dateTimeString) ;
          
            return CHECK1 ;
        }
    }
}
