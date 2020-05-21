using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims_Data
{
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                double claimTime = (DateOfClaim - DateOfIncident).TotalDays;

                if (claimTime <=30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claim()
        { 

        }
        public Claim(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
        }
        public string ToConsoleString()
        {
            return string.Join("\t", 
                new string[] 
                { 
                    ClaimID.ToString(), 
                    ClaimType.ToString(), 
                    Description.PadRight(30), 
                    ClaimAmount.ToString("C").PadLeft(10),
                    DateOfIncident.ToShortDateString(), 
                    DateOfClaim.ToShortDateString(), 
                    IsValid.ToString()
                });
        }

    }
}
