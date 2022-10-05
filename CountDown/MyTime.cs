using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountDown
{
    public class MyTime
    {
        private int minute;
        private int second;

        public MyTime()
        {
            minute = 0;
            second = 0;
        }


        public void Init(int minute, int second)
        {
            this.minute = minute;
            this.second = second;
            
        }

        public void Tick()
        {
            if(second ==0 && minute == 0)
            {
                return;
            }
            second -= 1;
            if(second < 0)
            {
                minute -= 1;
                second = 59;
            }
        }

        public bool IsCountDownFinish()
        {
            if(this.minute == 0 && this.second == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetCurrentTimeString()
        {

            if (minute >= 10 && second >= 10)
            {
                return Convert.ToString(minute) + ":" + Convert.ToString(second);
            }
            else if (minute < 10 && second >= 10)
            {
                return "0" + Convert.ToString(minute) + ":" + Convert.ToString(second);
            }
            else if (minute >= 10 && second < 10)
            {
                return Convert.ToString(minute) + ":" + "0" + Convert.ToString(second);
            }
            else
            {
                return "0" + Convert.ToString(minute) + ":" + "0" + Convert.ToString(second);
            }
            
        }

    }
}
