using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLibrary
{
    public struct Time
    {
        private int time;

        public Time(int t)
        {
            if (t < 0 || t >= 1440)
                throw new ArgumentException("Invalid time argument");
            this.time = t;
        }

        public Time(DateTime t)
        {
            TimeSpan timeOfDay = t.TimeOfDay;
            this.time = (timeOfDay.Hours * 60) + timeOfDay.Minutes;
        }

        public int TimeInMins => time;
        public int Hours => time / 60;

        public int Minutes => time - (Hours * 60);


        public int Noon => 720;

        static public explicit operator int(Time t)
        {
            return t.time;
        }

        static public implicit operator Time(int i)
        {
            return new Time(i);
        }

        static public Time operator +(Time t, Time _t)
        {
            int temp = t.time + _t.time;
            if (temp > 1440)
                return new Time(temp - 1440);
            return new Time(temp);
        }

        static public Time operator -(Time t, Time _t)
        {
            int temp = t.time - _t.time;            
            if (temp < 0)
                return new Time(temp + 1440);
            return new Time(temp);
        }

        public override string ToString()
        {
            if (Hours < 10 && Minutes < 10)
                return $"0{Hours}:0{Minutes}";
            if (Hours < 10)
                return $"0{Hours}:{Minutes}";
            if (Minutes < 10)
                return $"{Hours}:0{Minutes}";
            return $"{Hours}:{Minutes}";

        }
    }
}
