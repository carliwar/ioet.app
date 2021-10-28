using ioet.Core.Enums;
using ioet.Core.Model;
using ioet.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ioet.Tests
{
    [TestFixture]
    public class MapperServiceTests
    {
        [Test]
        public void Map_NullObject_ThrowsNullReferenceException()
        {
            //Arrange
            var mapper = new MapperService();
            const string[] input = null;

            //Act Assert
            Assert.Throws<NullReferenceException>(() => mapper.Map(input));
        }

        [Test]
        public void Map_SomeNullObject_ThrowsArgumentNullException()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[]{ null };

            //Act Assert
            Assert.Throws<ArgumentNullException>(() => mapper.Map(input));
        }

        [Test]
        public void Map_ValidValueOneSingleTime_ReturnObjectWithEmployeeTEST()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=MO10:00-12:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST"
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected.FirstOrDefault().Name, result.FirstOrDefault().Name);

        }

        [Test]
        public void Map_ValidValueOneSingleTime_ReturnObjectWithEmployeeTESTandFirstDayMonday()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=MO10:00-12:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Monday
                        } 
                    }
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().Day, result.FirstOrDefault().Schedule.FirstOrDefault().Day);

        }

        [Test]
        public void Map_ValidValueOneSingleTime_ReturnObjectWithEmployeeTESTandFirstDayTuesday()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=TU10:00-12:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Tuesday
                        }
                    }
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().Day, result.FirstOrDefault().Schedule.FirstOrDefault().Day);

        }

        [Test]
        public void Map_ValidValueOneSingleTime_ReturnObjectWithEmployeeTESTandFirstDayWednesday()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=WE10:00-12:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Wednesday
                        }
                    }
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().Day, result.FirstOrDefault().Schedule.FirstOrDefault().Day);

        }

        [Test]
        public void Map_ValidValueOneSingleTime_ReturnObjectWithEmployeeTESTandFirstDayWednesdayStartHour10()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=WE10:00-12:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Wednesday,
                            StartHour = new TimeSpan(10,0,0)
                        }
                    }
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().StartHour, result.FirstOrDefault().Schedule.FirstOrDefault().StartHour);

        }

        [Test]
        public void Map_ValidValueOneSingleTime_ReturnObjectWithEmployeeTESTandFirstDayWednesdayEndHour12()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=WE10:00-12:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Wednesday,
                            EndHour = new TimeSpan(12,0,0)
                        }
                    }
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().EndHour, result.FirstOrDefault().Schedule.FirstOrDefault().EndHour);

        }

        [Test]
        public void Map_ValidValueOneSingleTime_ReturnObjectWithEmployeeTESTandFirstDayWednesdayEndHour21()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=WE10:00-21:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Wednesday,
                            EndHour = new TimeSpan(21,0,0)
                        }
                    }
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().EndHour, result.FirstOrDefault().Schedule.FirstOrDefault().EndHour);

        }

        [Test]
        public void Map_ValidValueOneSingleTime_ReturnObjectWithEmployeeTESTandFirstDayWednesdayStartHour10EndHour21()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=WE10:00-21:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Wednesday,
                            StartHour = new TimeSpan(10,0,0),
                            EndHour = new TimeSpan(21,0,0)
                        }
                    }
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().EndHour, result.FirstOrDefault().Schedule.FirstOrDefault().EndHour);
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().StartHour, result.FirstOrDefault().Schedule.FirstOrDefault().StartHour);
            Assert.AreEqual(expected: expected.FirstOrDefault().Schedule.FirstOrDefault().Day, result.FirstOrDefault().Schedule.FirstOrDefault().Day);
            Assert.AreEqual(expected: expected.FirstOrDefault().Name, result.FirstOrDefault().Name);
        }

        [Test]
        public void Map_ValidValueTwoRecords_ReturnObjecFullData()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=WE10:00-21:00", "TEST2=TU11:00-13:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Wednesday,
                            StartHour = new TimeSpan(10,0,0),
                            EndHour = new TimeSpan(21,0,0)
                        }
                    }
                },
                new EmployeeWorkingTime
                {
                    Name = "TEST2",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Tuesday,
                            StartHour = new TimeSpan(11,0,0),
                            EndHour = new TimeSpan(13,0,0)
                        }
                    },

                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
           
            Assert.AreEqual(expected: expected[0].Name, result[0].Name);
            Assert.AreEqual(expected: expected[0].Schedule[0].Day, result[0].Schedule[0].Day);
            Assert.AreEqual(expected: expected[0].Schedule[0].StartHour, result[0].Schedule[0].StartHour);
            Assert.AreEqual(expected: expected[0].Schedule[0].EndHour, result[0].Schedule[0].EndHour);
            Assert.AreEqual(expected: expected[1].Name, result[1].Name);
            Assert.AreEqual(expected: expected[1].Schedule[0].Day, result[1].Schedule[0].Day);
            Assert.AreEqual(expected: expected[1].Schedule[0].StartHour, result[1].Schedule[0].StartHour);
            Assert.AreEqual(expected: expected[1].Schedule[0].EndHour, result[1].Schedule[0].EndHour);
        }

        [Test]
        public void Map_ValidValueOneSingleRecordTwoWorkingTimes_ReturnObjectMapped()
        {
            //Arrange
            var mapper = new MapperService();
            string[] input = new string[] { "TEST=WE10:00-21:00,SU08:00-09:00" };

            var expected = new List<EmployeeWorkingTime>
            {
                new EmployeeWorkingTime
                {
                    Name = "TEST",
                    Schedule = new List<DayTime>
                    {
                        new DayTime
                        {
                            Day = Days.Wednesday,
                            StartHour = new TimeSpan(10,0,0),
                            EndHour = new TimeSpan(21,0,0)
                        },
                        new DayTime
                        {
                            Day = Days.Sunday,
                            StartHour = new TimeSpan(8,0,0),
                            EndHour = new TimeSpan(9,0,0)
                        }
                    }
                }
            };

            //Act
            var result = mapper.Map(input);

            //Assert
            Assert.AreEqual(expected: expected[0].Name, result[0].Name);
            Assert.AreEqual(expected: expected[0].Schedule[0].Day, result[0].Schedule[0].Day);
            Assert.AreEqual(expected: expected[0].Schedule[0].StartHour, result[0].Schedule[0].StartHour);
            Assert.AreEqual(expected: expected[0].Schedule[0].EndHour, result[0].Schedule[0].EndHour);
            Assert.AreEqual(expected: expected[0].Schedule[1].Day, result[0].Schedule[1].Day);
            Assert.AreEqual(expected: expected[0].Schedule[1].StartHour, result[0].Schedule[1].StartHour);
            Assert.AreEqual(expected: expected[0].Schedule[1].EndHour, result[0].Schedule[01].EndHour);
        }
    }
}
