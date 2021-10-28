using ioet.Core.Enums;
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
            List<DayTime> arg = null;

            //Act Assert
            Assert.Throws<ArgumentNullException>(() => paymentService.GetPayment(arg));
        }

        [Test]
        public void ProcessPayment_OneItemMonday10to11_Returns15()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
                {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(10,0,0),
                        EndHour = new TimeSpan(11,0,0)
                    }
            };

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void ProcessPayment_OneItemMonday10to12_Returns30()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
                {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(10,0,0),
                        EndHour = new TimeSpan(12,0,0)
                    }
            };

            const int expected = 30;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_OneItemMonday17to19_Returns35()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
                {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(17,0,0),
                        EndHour = new TimeSpan(19,0,0)
                    }
            };
            const int expected = 35;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_OneItemMonday19to21_Returns40()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
                {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(19,0,0),
                        EndHour = new TimeSpan(21,0,0)
                    }
            };
            const int expected = 40;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_OneItemMonday2to5_Returns75()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
                {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(2,0,0),
                        EndHour = new TimeSpan(5,0,0)
                    }
            };
            const int expected = 75;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_OneItemMonday7to10_Returns65()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
                {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(7,0,0),
                        EndHour = new TimeSpan(10,0,0)
                    }
            };
            const int expected = 65;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_OneItemMonday7to20_Returns225()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
                {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(7,0,0),
                        EndHour = new TimeSpan(20,0,0)
                    }
            };
            const int expected = 225;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_TwoItemsMOtoFR7to9_Returns225()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
            {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(7,0,0),
                        EndHour = new TimeSpan(10,0,0)
                    },
                    new DayTime
                    {
                        Day = Days.Tuesday,
                        StartHour = new TimeSpan(7,0,0),
                        EndHour = new TimeSpan(10,0,0)
                    }
            };
            const int expected = 130;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_TwoItemsSAtoSUN9to10_Returns20()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
            {
                    new DayTime
                    {
                        Day = Days.Saturday,
                        StartHour = new TimeSpan(9,0,0),
                        EndHour = new TimeSpan(10,0,0)
                    }
            };
            const int expected = 20;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_TwoItemsSAtoSUN7to10_Returns80()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
            {
                    new DayTime
                    {
                        Day = Days.Saturday,
                        StartHour = new TimeSpan(7,0,0),
                        EndHour = new TimeSpan(10,0,0)
                    }
            };
            const int expected = 80;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProcessPayment_TwoItemsSAtoSUN16to19_Returns65()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
            {
                    new DayTime
                    {
                        Day = Days.Saturday,
                        StartHour = new TimeSpan(16,0,0),
                        EndHour = new TimeSpan(19,0,0)
                    }
            };
            const int expected = 65;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test, Description("ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00")]
        public void ProcessPayment_TestNumber1_Returns85()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
            {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(10,0,0),
                        EndHour = new TimeSpan(12,0,0)
                    },
                    new DayTime
                    {
                        Day = Days.Thursday,
                        StartHour = new TimeSpan(12,0,0),
                        EndHour = new TimeSpan(14,0,0)
                    },
                    new DayTime
                    {
                        Day = Days.Sunday,
                        StartHour = new TimeSpan(20,0,0),
                        EndHour = new TimeSpan(21,0,0)
                    }
            };
            const int expected = 85;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test, Description("RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00")]
        public void ProcessPayment_TestNumber2_Returns215()
        {
            //Arrange
            var paymentService = new PaymentService();
            var records = new List<DayTime>
            {
                    new DayTime
                    {
                        Day = Days.Monday,
                        StartHour = new TimeSpan(10,0,0),
                        EndHour = new TimeSpan(12,0,0)
                    },
                    new DayTime
                    {
                        Day = Days.Tuesday,
                        StartHour = new TimeSpan(10,0,0),
                        EndHour = new TimeSpan(12,0,0)
                    },
                    new DayTime
                    {
                        Day = Days.Thursday,
                        StartHour = new TimeSpan(1,0,0),
                        EndHour = new TimeSpan(3,0,0)
                    },
                    new DayTime
                    {
                        Day = Days.Saturday,
                        StartHour = new TimeSpan(14,0,0),
                        EndHour = new TimeSpan(18,0,0)
                    },
                    new DayTime
                    {
                        Day = Days.Sunday,
                        StartHour = new TimeSpan(20,0,0),
                        EndHour = new TimeSpan(21,0,0)
                    }
            };
            const int expected = 215;

            //Act
            var result = paymentService.GetPayment(records);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
