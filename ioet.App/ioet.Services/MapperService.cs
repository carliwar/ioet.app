using ioet.Core.Enums;
using ioet.Core.Model;
using System;
using System.Collections.Generic;

namespace ioet.Services
{
    public class MapperService
    {
        public List<EmployeeWorkingTime> Map(string[] input)
        {
            var result = new List<EmployeeWorkingTime>();

            ValidateInput(input);

            for (int i = 0; i < input.Length; i++)
            {
                var currentInput = input[i];
                var currentObject = new EmployeeWorkingTime
                {
                    Schedule = new List<DayTime>()
                };
                string[] nameAndSchedule = currentInput.Split('=');
                var currentSchedule = nameAndSchedule[1];
                string[] scheduleDays = currentSchedule.Split(',');

                // Get Name of current Employee
                currentObject.Name = nameAndSchedule[0];

                // Get Schedule days of Employee data
                for (int j = 0; j < scheduleDays.Length; j++)
                {
                    var currentWorkTime = new DayTime();
                    SetDayOfWork(scheduleDays, j, currentWorkTime);
                    SetHoursOfWork(scheduleDays, j, currentWorkTime);

                    currentObject.Schedule.Add(currentWorkTime);
                }


                result.Add(currentObject);
            }


            return result;

        }

        #region Private Methods
        private static void SetHoursOfWork(string[] scheduleDays, int j, DayTime currentWorkTime)
        {
            var timeWithoutDay = scheduleDays[j].Remove(0, 2);
            var hours = timeWithoutDay.Split('-');

            currentWorkTime.StartHour = TimeSpan.Parse(hours[0]);
            currentWorkTime.EndHour = TimeSpan.Parse(hours[1]);
        }

        private static void SetDayOfWork(string[] scheduleDays, int j, DayTime currentWorkTime)
        {
            // Set the day of the week
            var day = scheduleDays[j].Substring(0, 2);

            // find day in list of days
            switch (day)
            {
                case "MO":
                    currentWorkTime.Day = Days.Monday;
                    break;
                case "TU":
                    currentWorkTime.Day = Days.Tuesday;
                    break;
                case "WE":
                    currentWorkTime.Day = Days.Wednesday;
                    break;
                case "TH":
                    currentWorkTime.Day = Days.Thursday;
                    break;
                case "FR":
                    currentWorkTime.Day = Days.Friday;
                    break;
                case "SA":
                    currentWorkTime.Day = Days.Saturday;
                    break;
                case "SU":
                    currentWorkTime.Day = Days.Sunday;
                    break;
            }
        }

        private static void ValidateInput(string[] input)
        {
            if (input == null)
                throw new NullReferenceException();

            var inputLength = input.Length;

            for (int i = 0; i < inputLength; i++)
            {
                if (input[i] == null)
                    throw new ArgumentNullException();
            }
        } 
        #endregion
    }
}
