using ioet.Core.Model;
using System.Collections.Generic;

namespace ioet.Core.Interfaces
{
    public interface IPaymentService
    {
        int GetPayment(List<DayTime> records);
    }
}
