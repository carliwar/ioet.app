using ioet.Core.Model;
using ioet.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ioet.Tests
{
    [TestFixture]
    public class PaymentServiceTests
    {
        [Test]
        public void ProcessPayment_NullObject_ThrowsException()
        {
            //Arrange
            var paymentService = new PaymentService();
            List <EmployeeWorkingTime> arg = null;

            //Act Assert
            Assert.Throws<ArgumentNullException>(() => paymentService.GetPayments(arg));
        }
    }
}
