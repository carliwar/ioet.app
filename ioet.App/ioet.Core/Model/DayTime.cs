using ioet.Core.Enums;
using System;

namespace ioet.Core.Model
{
    public class DayTime
    {
        public Days Day { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
    }
}
