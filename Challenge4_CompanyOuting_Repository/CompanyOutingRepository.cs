
using Challenge4_CompanyOuting_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_CompanyOuting_Repository
{
    public class CompanyOutingRepository
    {
        private List<Outing> _outingDirectory = new List<Outing>();
        public bool AddEventToDirectory(Outing outing) //Create
        {
            int startingCount = _outingDirectory.Count;
            _outingDirectory.Add(outing);
            bool wasAdded = _outingDirectory.Count == startingCount + 1;
            return wasAdded;
        }
        public List<Outing> GetOutings() //Read
        {
            return _outingDirectory;
        }
        public List<Outing> GetEventByEventType(EventType eventType) //Read
        {
            List<Outing> outings = new List<Outing>();
            foreach (Outing outing in _outingDirectory)
            {
                if (outing.EventType == eventType)
                {
                   outings.Add(outing);
                }
            }
            return outings;
        }
        public Outing GetEventByEventDate(DateTime eventDate)
        {
            foreach (Outing outing in _outingDirectory)
            {
                if (outing.EventDate == eventDate)
                {
                    return outing;
                }
            }
            return null;
        }
        public bool UpdateEventByEventDate(DateTime eventDate, Outing newOuting)//Update
        {
            Outing outing = GetEventByEventDate(eventDate);

            if (outing == null)
            {
                Console.WriteLine("There is no event entered for this date.");
                return false;
            }
            else
            {
                outing.EventType = newOuting.EventType;
                outing.Attendance = newOuting.Attendance;
                outing.EventDate = newOuting.EventDate;
                outing.TotalCost = newOuting.TotalCost;
                return true;
            }
        }
        public bool RemoveEventByEventDate(DateTime eventDate) //Delete
        {
            Outing outing = GetEventByEventDate(eventDate);

            if (outing == null)
            {
                Console.WriteLine("There is no event entered for this date.");
                return false;
            }
            else
            {
                _outingDirectory.Remove(outing);
                return true;
            }
        }
    }
}


