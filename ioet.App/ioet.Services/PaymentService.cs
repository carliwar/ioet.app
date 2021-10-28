using ioet.Core.Interfaces;
using ioet.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ioet.Services
{
    public class PaymentService : IPaymentService
    {
        public List<string> GetPayments(List<EmployeeWorkingTime> records)
        {
            var results = new List<string>();

            if(records == null)
                throw new ArgumentNullException();

            return results;
        }
    }
}
