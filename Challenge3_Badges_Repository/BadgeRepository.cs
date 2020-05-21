using Challenge3_Badges_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badges_Repository
{
    public class BadgeRepository
    {
        //Create a dictionary of badges
       
        private Dictionary<int, Badge> _badgeDirectory = new Dictionary<int, Badge>();

        public bool AddNewBadge(Badge badge)//Create a new badge
        {
            if (_badgeDirectory.ContainsKey(badge.BadgeID))
            {
                return false;
            }
            else
            {
                int startingCount = _badgeDirectory.Count;
                _badgeDirectory.Add(badge.BadgeID, badge); //key for dictionary will be BadgeID //value for the dictionary will be the List of Door Names
                bool wasAdded = _badgeDirectory.Count == startingCount + 1;
                return wasAdded;
            }
        }
        public List<Badge> GetBadgeDirectory() //show a list with all badge numbers and door access
        {
            return _badgeDirectory.Select(x => x.Value).ToList();
        }
        public Badge GetBadgeByBadgeID(int badgeID)
        {
            foreach (KeyValuePair<int, Badge> badge in _badgeDirectory)
            {
                if (badge.Key == badgeID)
                {
                    return badge.Value;
                }
            }
            return null;
        }
        public bool UpdateBadgeByBadgeID(int badgeID, Badge newBadge) //Update
        {
            Badge badge = GetBadgeByBadgeID(badgeID);
                if (badge == null)
            {
                Console.WriteLine("The BadgeID was not found.");
                return false;
            }
                else
            {
                badge.BadgeID = newBadge.BadgeID;
                badge.DoorsAccessible = newBadge.DoorsAccessible;
                return true;
            }
        }
        public bool DeleteBadgeByBadgeID(int badgeID) //Delete
        {
            Badge badge = GetBadgeByBadgeID(badgeID);
            if (badge == null)
            {
                Console.WriteLine("The BadgeID was not found.");
                return false;
            }
            else
            {
                _badgeDirectory.Remove(badge.BadgeID);
                Console.WriteLine($"BadgeID: {badge.BadgeID} has been removed.");
                return true;
            }
        }
    }
}
