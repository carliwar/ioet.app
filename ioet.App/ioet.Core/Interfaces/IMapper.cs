using ioet.Core.Model;
using System.Collections.Generic;

namespace ioet.Core.Interfaces
{
    public interface IMapper
    {
        List<EmployeeWorkingTime> Map(string[] input);
    }
}
