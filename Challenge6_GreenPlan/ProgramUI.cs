using Challenge2_Claims_Data;
using Challenge2_Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims
{
    public class ProgramUI
    {
        ClaimsRepository ClaimRepo = new ClaimsRepository();
        bool continueToRun = true;

        public void Run()
        {
            Console.WriteLine("Welcome to Komodo Insurance Claims Department.");

            while (continueToRun)
            {
                MenuOptions();
            }
        }
        public void MenuOptions()
        {
            Console.WriteLine("Please choose an option from the menu:\n" +
                "1.See all claims\n" +
                "2.Take care of next claim\n" +
                "3.Enter a new claim\n" +
                "4.Exit");


            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    SeeAllClaims();
                    break;
                case "2":
                    TakeCareOfNextClaim();
                    break;
                case "3":
                    EnterNewClaim();
                    break;
                case "4":
                    Console.WriteLine("Thank you! Goodbye!");
                    continueToRun = false;
                    break;
                default:
                    Console.WriteLine("That is not an option.");
                    MenuOptions();
                    break;
            }
        }
        //1.See all claims
        public void SeeAllClaims()
        {
            Queue<Claim> claimList = ClaimRepo.GetClaim();
            List<string> Header = new List<string>
            {
                "ClaimID", "Type", "Description".PadRight(30), "Amount".PadLeft(10), "DateOfAccident", "DateOfClaim", "IsValid"
            };
            Console.WriteLine(string.Join("\t", Header));
            foreach (Claim claim in claimList)
            {
                DisplayClaim(claim);
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void DisplayClaim(Claim claim)
        {
            Console.WriteLine(claim.ToConsoleString());
        }
        //2.Take care of next claim
        public void TakeCareOfNextClaim()
        {
            ShowFirstQueue();
            UserPromptDequeue();
        }
        public void ShowFirstQueue()
        {
            Queue<Claim> claimList = ClaimRepo.GetClaim();
            Console.WriteLine("(Peek)   \t{0}", claimList.Peek());
        }
        public void DequeueItem()
        {
            Queue<Claim> claimList = ClaimRepo.GetClaim();
            Console.WriteLine("(Dequeue) \t{0}", claimList.Dequeue());
        }
        public void UserPromptDequeue()
        {
            Console.WriteLine("Do you want to deal with this claim now?\n" +
               "1.Yes\n" +
               "2.No");

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    DequeueItem();
                    Console.WriteLine("This claim has been sent to the bottom of the queue.");
                    break;
                case "2":
                    MenuOptions();
                    break;
                default:
                    Console.WriteLine("That is not an option");
                    UserPromptDequeue();
                    break;
            }
        }
        //3.Enter a new claim
        public void EnterNewClaim()
        {
            Claim newClaim = new Claim();

            newClaim.ClaimID = EnterClaimID();
            newClaim.ClaimType = EnterClaimType();
            newClaim.Description = EnterClaimDescription();
            newClaim.ClaimAmount = EnterClaimAmount();
            newClaim.DateOfIncident = EnterDateOfIncident();
            newClaim.DateOfClaim = EnterDateOfClaim();

            ClaimRepo.AddNewClaim(newClaim);
        }
        public int EnterClaimID()
        {
            Console.WriteLine("What is the ClaimID for this claim?");
            string selection = Console.ReadLine();
            int.TryParse(selection, out int claimID);
            return claimID;
        }
        public ClaimType EnterClaimType()
        {
            Console.WriteLine("What is the ClaimType for this claim?\n" +
                "1.Car\n" +
                "2.Home\n" +
                "3.Theft");

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    return ClaimType.Car;

                case "2":
                    return ClaimType.Home;

                case "3":
                    return ClaimType.Theft;

                default:
                    Console.WriteLine("That is not an option.");
                    return EnterClaimType();
            }
        }
        public string EnterClaimDescription()
        {
            Console.WriteLine("Provide a description for this claim.");
            string description = Console.ReadLine();
            return description;
        }
        public decimal EnterClaimAmount()
        {
            Console.WriteLine("What is the amount for the claim?");
            string amount = Console.ReadLine();
            decimal.TryParse(amount, out decimal claimAmount);
            return claimAmount;
        }
        public DateTime EnterDateOfIncident()
        {
            Console.WriteLine("When did the incident occur?");
            string date = Console.ReadLine();
            DateTime.TryParse(date, out DateTime incidentDate);
            return incidentDate;
        }
        public DateTime EnterDateOfClaim()
        {
            Console.WriteLine("When was the claim submitted?");
            string date = Console.ReadLine();
            DateTime.TryParse(date, out DateTime claimDate);
            return claimDate;
        }

    }
}
