using ioet.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ioet.Services
{
    public class PaymentsResultsService
    {
        private IPaymentService _paymentService;
        private IMapper _mapper;

        public PaymentsResultsService(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public List<string> GetPayments(string[] records)
        {
            var result = new List<string>();
            if (records == null)
                throw new ArgumentNullException();

            var objectModels = _mapper.Map(records);

            foreach (var model in objectModels)
            {
                var valueToPay = _paymentService.GetPayment(model.Schedule);
                result.Add($"The amount to pay {model.Name} is: {valueToPay} USD");
            }

            return result;
        }
    }
}
