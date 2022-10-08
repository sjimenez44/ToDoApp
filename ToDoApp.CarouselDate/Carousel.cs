using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ToDoApp.CarouselDate.Models;

namespace ToDoApp.CarouselDate
{

    public class Carousel
    {
        public DateTime DateToDo { get; private set; }
        public List<Models.DayOfWeek> Days { get; private set; }
        public DayRange DayRangeWeek { get; set; }
        private DateTime StartOfWeek { get; set; }

        public Carousel()
        {
            DateToDo = DateTime.Now;
            UpdateDaysOfWeek();
            CalculateDayRange();
        }

        public void LastWeek()
        {
            DateToDo = DateToDo.AddDays(-7);
            UpdateDaysOfWeek();
            CalculateDayRange();
        }
        
        public void NextWeek()
        {
            DateToDo = DateToDo.AddDays(7);
            UpdateDaysOfWeek();
            CalculateDayRange();
        }

        private void UpdateDaysOfWeek()
        {
            StartOfWeek = DateToDo.AddDays(
                (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
                (int)DateToDo.DayOfWeek);

            DateTime dayNow = DateTime.Now;
            Days = Enumerable.Range(0, 7).Select(i => new Models.DayOfWeek()
                {
                    Day = StartOfWeek.AddDays(i),
                    DayNumber = StartOfWeek.AddDays(i).ToString("dd"),
                    DayMonth = StartOfWeek.AddDays(i).ToString("MMMM-dd"),
                    DayName = StartOfWeek.AddDays(i).ToString("dddd").Substring(0, 2),
                    Status = CalculateTimeline(StartOfWeek.AddDays(i), dayNow),
                }).ToList();
        }

        private Timeline CalculateTimeline(DateTime actual, DateTime reference)
        {
            if (actual.Date > reference.Date)
            {
                return Timeline.Future;
            }
            else if (actual.Date == reference.Date)
            {
                return Timeline.Present;
            }
            else
            {
                return Timeline.Past;
            }
        }

        private void CalculateDayRange()
        {
            DayRangeWeek = new DayRange()
                {
                    Start = Days[0].DayMonth,
                    End = Days[6].DayMonth,
                };
        }
    }
}
