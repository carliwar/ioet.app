using ioet.Core.Enums;
using ioet.Core.Interfaces;
using ioet.Core.Model;
using System;
using System.Collections.Generic;

namespace ioet.Services
{
    public class PaymentService : IPaymentService
    {
        public int GetPayment(List<DayTime> records)
        {
            var availableHours = new int[] { 0, 0, 0, 0, 0, 0 };

            if (records == null)
                throw new ArgumentNullException();

            foreach(var record in records)
            {
                var numberOfHours = (record.EndHour - record.StartHour).Hours;                

                if(record.Day < Days.Saturday)
                {
                    ProcessMOtoFR(availableHours, record, numberOfHours);
                }
                else
                {
                    ProcessSAtoSU(availableHours, record, numberOfHours);
                }
            }

            // Sum all worked hours
            int result = availableHours[0] * 25; // MO-FR 00-01 to 09:00 ** SA-SU 18:01 to 00:00
            result += availableHours[1] * 15; // 09-01 to 18:00
            result += availableHours[2] * 20; // 18-01 to 00:00 ** SA-SU 09:01 to 18:00
            result += availableHours[3] * 30; // SA-SU 00:01 to 09:00

            return result;
        }

        private static void ProcessMOtoFR(int[] availableHours, DayTime record, int numberOfHours)
        {
            if (record.StartHour.Hours >= 9)
            {
                if (record.StartHour < new TimeSpan(18, 1, 0))
                {
                    var currentHours = numberOfHours;

                    if (record.EndHour > new TimeSpan(18, 0, 0))
                    {
                        var numberOfHoursPast18 = record.EndHour.Hours - 18;

                        availableHours[2] += currentHours - numberOfHoursPast18;
                        availableHours[1] += numberOfHoursPast18;
                    }
                    else
                    {
                        availableHours[1] += numberOfHours;
                    }
                }
                else
                {
                    availableHours[2] += numberOfHours;
                }
            }
            else
            {
                var currentHours = numberOfHours;

                if (record.EndHour > new TimeSpan(18, 0, 0))
                {
                    var numberOfHoursPast18 = record.EndHour.Hours - 18;
                    availableHours[0] += currentHours - numberOfHoursPast18 - 9;
                    availableHours[1] += 9;
                    availableHours[2] += numberOfHoursPast18;

                }
                else if (record.EndHour > new TimeSpan(9, 0, 0))
                {
                    var numberOfHoursPast9 = record.EndHour.Hours - 9;
                    availableHours[0] += currentHours - numberOfHoursPast9;
                    availableHours[1] += numberOfHoursPast9;
                }
                else
                {
                    availableHours[0] += currentHours;
                }
            }
        }

        private static void ProcessSAtoSU(int[] availableHours, DayTime record, int numberOfHours)
        {
            if (record.StartHour.Hours >= 9)
            {
                if (record.StartHour < new TimeSpan(18, 1, 0))
                {
                    var currentHours = numberOfHours;

                    if (record.EndHour > new TimeSpan(18, 0, 0))
                    {
                        var numberOfHoursPast18 = record.EndHour.Hours - 18;

                        availableHours[2] += currentHours - numberOfHoursPast18;
                        availableHours[0] += numberOfHoursPast18;
                    }
                    else
                    {
                        availableHours[2] += numberOfHours;
                    }
                }
                else
                {
                    availableHours[0] += numberOfHours;
                }
            }
            else
            {
                var currentHours = numberOfHours;

                if (record.EndHour > new TimeSpan(18, 0, 0))
                {
                    var numberOfHoursPast18 = record.EndHour.Hours - 18;
                    availableHours[3] += currentHours - numberOfHoursPast18 - 9;
                    availableHours[2] += 9;
                    availableHours[0] += numberOfHoursPast18;

                }
                else if (record.EndHour > new TimeSpan(9, 0, 0))
                {
                    var numberOfHoursPast9 = record.EndHour.Hours - 9;
                    availableHours[3] += currentHours - numberOfHoursPast9;
                    availableHours[2] += numberOfHoursPast9;
                }
                else
                {
                    availableHours[3] += currentHours;
                }
            }
        }
    }
}
