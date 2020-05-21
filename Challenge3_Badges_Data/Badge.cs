using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badges_Data
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorsAccessible { get; set; }

        public Badge()
        {

        }
        public Badge(int badgeID, List<string> doorAccess)
        {
            BadgeID = badgeID;
            DoorsAccessible = doorAccess;
        }
        public string ToConsoleString()
        {
            return string.Join("\t",
                new string[]
                {
                    BadgeID.ToString(),
                    DoorsAccessible.ToString()
                });
        }
    }
}
