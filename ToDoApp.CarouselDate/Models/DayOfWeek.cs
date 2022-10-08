using System;

namespace ToDoApp.CarouselDate.Models
{
    public class DayOfWeek
    {
        public DateTime Day { get; set; }
        public string DayNumber { get; set; }
        public string DayMonth { get; set; }
        public string DayName { get; set; }
        public Timeline Status { get; set; }
    }
}
