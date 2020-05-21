using Challenge2_Claims_Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims_Repo
{
    public class ClaimsRepository
    {
        private Queue<Claim> _claimDirectory = new Queue<Claim>();
        public ClaimsRepository()
        {
            SeedRepo();
        }
        private void SeedRepo()
        {
            AddNewClaim(new Claim
            {
                ClaimID = 1,
                ClaimType = ClaimType.Car,
                Description = "Car accident on 465.",
                ClaimAmount = 400.00m,
                DateOfIncident = new DateTime(2018, 4, 25),
                DateOfClaim = new DateTime(2018, 4, 27),
            });
            AddNewClaim(new Claim(2,ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018,04,12)));
            AddNewClaim(new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01)));
        }

        //Create
        //Create new claims

        public bool AddNewClaim(Claim claim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(claim);
            bool wasAdded = _claimDirectory.Count == startingCount + 1;
            return wasAdded;
        }
        //Read
        //receive a list of all claims
        public Queue<Claim> GetClaim()
        {
            return _claimDirectory;
        }

        public Claim GetClaimByClaimID(int claimID)
        {
            foreach (Claim claim in _claimDirectory)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
        //Update
        //update information by claimID
        public bool UpdateClaimByClaimID(int claimID, Claim newClaim)
        {
            Claim iD = GetClaimByClaimID(claimID);

            if (iD == null)
            {
                Console.WriteLine("This is not the content you're looking for...");
                return false;
            }
            else
            {
                iD.ClaimID = newClaim.ClaimID;
                iD.ClaimType = newClaim.ClaimType;
                iD.Description = newClaim.Description;
                iD.ClaimAmount = newClaim.ClaimAmount;
                iD.DateOfIncident = newClaim.DateOfIncident;
                iD.DateOfClaim = newClaim.DateOfClaim;
                return true;
            }
        }
        //Delete
        public bool RemoveClaimByClaimID(int claimID)
        {
            Claim iD = GetClaimByClaimID(claimID);
            if (iD == null)
            {
                Console.WriteLine("This is not a valid ClaimID.");
                return false;
            }
            else
            {
                _claimDirectory = new Queue<Claim>(_claimDirectory.Where(x => x.ClaimID != claimID));
                Console.WriteLine("This claim has been removed from the directory.");
                return true;
            }

        }
    }
}
