using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_CompanyOuting_Data
{
    public enum EventType {Golf, Bowling, Amusement_Park, Concert}
    public class Outing
    {
        public EventType EventType { get; set; }
        public int Attendance { get; set; }
        public DateTime EventDate { get; set; }
        public decimal TotalCost { get; set; }
        public decimal PerPersonCost
        {
            get
            {
                decimal PerPersonCost = TotalCost / Attendance;
                return PerPersonCost;
            }
        }
        public Outing()
        {

        }
        public Outing(
            EventType eventType,
            int attendance,
            DateTime eventDate,
            decimal totalCost)
        {
            EventType = eventType;
            Attendance = attendance;
            EventDate = eventDate;
            TotalCost = totalCost;
        }
        public string ToConsoleString()
        {
            return string.Join("\t",
                new string[]
                {
                    EventDate.ToShortDateString().PadRight(10),
                    EventType.ToString().PadRight(15),
                    Attendance.ToString().PadLeft(5),
                    TotalCost.ToString("C").PadLeft(17),
                    PerPersonCost.ToString("C").PadLeft(10)
                });
        }
    }
}
