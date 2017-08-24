using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentCalendar.Models
{
    public class CalendarMonths
    {
        public readonly Dictionary<int,string> Months = new Dictionary<int, string>();

        public CalendarMonths()
        {
            Months.Add(1, "January");
            Months.Add(2, "February");
            Months.Add(3, "March");
            Months.Add(4, "April");
            Months.Add(5, "May");
            Months.Add(6, "June");
            Months.Add(7, "July");
            Months.Add(8, "August");
            Months.Add(9, "September");
            Months.Add(10, "October");
            Months.Add(11, "November");
            Months.Add(12, "December");
        }
    }
}