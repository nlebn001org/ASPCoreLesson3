using System;

namespace ASPCoreLesson3Task3
{
    public class SayMeTimeService
    {
        DateTime time;
        public string SayMeTime()
        {
            time = DateTime.Now;
            string value = null;
            if (time.Hour > 12 && time.Hour < 16) value =  "Its day";
            if (time.Hour > 16 && time.Hour < 24) value = "Its evening";
            if (time.Hour > 0 && time.Hour < 4) value = "Its night";
            if (time.Hour > 4 && time.Hour < 12) value = "Its morning";
            return value;
        }

    }
}
