using ioet.Core.Interfaces;
using ioet.Core.Model;
using ioet.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ioet.Tests
{
    [TextFixture]
    public class PaymentResultsServiceTests
    {
        [Test]
        public void GetPayments_NullObject_ThrowsException()
        {
            //Arrange
            var paymentService = Substitute.For<IPaymentService>();
            var mapper = Substitute.For<IMapper>();
            var paymentsResultsService = new PaymentsResultsService(paymentService, mapper);

            string[] records = null;

            //Act Assert
            Assert.Throws<ArgumentNullException>(() => paymentsResultsService.GetPayments(records));
        }

        [Test]
        public void GetPayments_SingleRecordTestAstrid_ReturnSingleFormattedResult()
        {
            //Arrange
            var paymentService = Substitute.For<IPaymentService>();
            var mapper = Substitute.For<IMapper>();
            var paymentsResultsService = new PaymentsResultsService(paymentService, mapper);

            var modelObjects = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "ASTRID"
                }
            };

            mapper.Map(Arg.Any<string[]>()).Returns(modelObjects);
            paymentService.GetPayment(Arg.Any<List<DayTime>>()).Returns(85);

            string[] records = new string[] { "ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00" };

            var expected = "The amount to pay ASTRID is: 85 USD";
            //Act
            var result = paymentsResultsService.GetPayments(records);

            //Assert
            Assert.AreEqual(expected: expected, result[0]);
        }
        [Test]
        public void GetPayments_SingleRecordRene_ReturnSingleFormattedResult()
        {
            //Arrange
            var paymentService = Substitute.For<IPaymentService>();
            var mapper = Substitute.For<IMapper>();
            var paymentsResultsService = new PaymentsResultsService(paymentService, mapper);

            var modelObjects = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "RENE"
                }
            };

            mapper.Map(Arg.Any<string[]>()).Returns(modelObjects);
            paymentService.GetPayment(Arg.Any<List<DayTime>>()).Returns(215);

            string[] records = new string[] { "RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00" };

            var expected = "The amount to pay RENE is: 215 USD";
            //Act
            var result = paymentsResultsService.GetPayments(records);

            //Assert
            Assert.AreEqual(expected: expected, result[0]);
        }
    }
}
