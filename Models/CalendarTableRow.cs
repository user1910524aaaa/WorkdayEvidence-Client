using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class CalendarTableRow
    {
        public int DayNo { get; set; }

        public string DayName { get; set; }

        public DateTime Date { get; set; }

        public int Id { get; set; }

        public bool? ClockedIn { get; set; }

        public DateTime? ClockedInStartDate { get; set; }

        public DateTime? ClockedInEndDate { get; set; }

        public int? AmountOfMinutes { get; set; }

        public string WorkdayType { get; set; }
    }
}
