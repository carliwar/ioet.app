using System.Collections.Generic;

namespace ioet.Core.Model
{
    public class EmployeeWorkingTime
    {
        public string Name { get; set; }
        public List<DayTime> Schedule { get; set; }
    }
}
