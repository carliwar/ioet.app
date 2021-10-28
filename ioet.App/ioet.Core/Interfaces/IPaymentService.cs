using ioet.Core.Model;
using System.Collections.Generic;

namespace ioet.Core.Interfaces
{
    public interface IPaymentService
    {
        List<string> GetPayments(List<EmployeeWorkingTime> records);
    }
}
