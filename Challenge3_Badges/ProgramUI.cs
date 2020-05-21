using Challenge3_Badges_Data;
using Challenge3_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badges
{
    public class ProgramUI
    {
        Badge currentBadge;
        private readonly BadgeRepository BadgeRepo = new BadgeRepository();
        bool continueToRun = true;
        public void Run()
        {
            Console.WriteLine("Welcome to Komodo Insurance's new Badge System!");
            while (continueToRun)
            {
                MainMenu();
            }
        }
        public void MainMenu()
        {
            Console.WriteLine("Please choose an option from the menu:\n" +
                "1.Add a badge\n" +
                "2.Edit a badge\n" +
                "3.List all badges\n" +
                "4.Exit");

            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    AddBadge();
                    break;
                case "2":
                    UpdateBadgePrompt();
                    break;
                case "3":
                    ListAllBadges();
                    break;
                case "4":
                    Console.WriteLine("Thank you! Goodbye!");
                    continueToRun = false;
                    break;
                default:
                    Console.WriteLine("That is not an option.");
                    MainMenu();
                    break;
            }
        }
        //Add a badge
        public void AddBadge()
        {
            Console.WriteLine("What is the BadgeID you would like to enter?");
            string selection = Console.ReadLine();
            int.TryParse(selection, out int badgeID);

            List<string> doorAccess = PromptUserForDoors(new List<string>());

            BadgeRepo.AddNewBadge(new Badge(badgeID, doorAccess));

        }
    public List<string> PromptUserForDoors(List<string> doorAccess)
        {
            Console.WriteLine("What door does this badge need access to?");
            string selection = Console.ReadLine();
            doorAccess.Add(selection);
            return UserPromptMoreDoors(doorAccess);

        }
        public List<string> UserPromptMoreDoors(List<string> doorAccess)
        {
            //More doors?
            Console.WriteLine("Would you like to add another door access?\n" +
                "1.Yes\n" +
                "2.No");

            string selection = Console.ReadLine();
            return ParseUserSelectionForDoorAccess(selection, doorAccess);
        }
        public List<string> ParseUserSelectionForDoorAccess(string selection, List<string> doorAccess)
        {
            if (selection == "1")
            {
                return PromptUserForDoors(doorAccess);
            }
            else
            {
                return doorAccess;
            }
        }

        //Edit a badge
        public void UpdateBadgePrompt()
        {
            Console.WriteLine("What is the BadgeID you wish to update?");//What is the badge number to update
            string selection = Console.ReadLine();
            int.TryParse(selection, out int badgeID);

            currentBadge = BadgeRepo.GetBadgeByBadgeID(badgeID);//list door access for badge

            UpdateDoorAccessOptions();
        }
        public void UpdateDoorAccessOptions()  //Menu Options: Remove Door, Add Door
        {
            Console.WriteLine("How would you like update this BadgeID?\n" +
                "1.Add Door Access\n" +
                "2.Remove Door Access\n" +
                "3.Clear Door Access\n" +
                "4.Exit");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    AddDoorAccess();
                    break;
                case "2":
                    RemoveDoorAccess();
                    break;
                case "3":
                    ClearDoorAccess();
                    break;
                case "4":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("This is not an option.");
                    UpdateDoorAccessOptions();
                    break;
            }
        }
        public void AddDoorAccess()//Add Door: Which door would you like to add?
        {
            Console.WriteLine("Which door would you like to add to this BadgeID?");
            string selection = Console.ReadLine();
            currentBadge.DoorsAccessible.Add(selection);

            BadgeRepo.UpdateBadge(currentBadge);
        }
        public void RemoveDoorAccess()//Remove Door: Which door would you like to Remove?
        {
            Console.WriteLine("Which door would you like to remove from this BadgeID?");
            string selection = Console.ReadLine();
            currentBadge.DoorsAccessible.Remove(selection);

            BadgeRepo.UpdateBadge(currentBadge);
        }
        public void ClearDoorAccess()
        {
            currentBadge.DoorsAccessible.Clear();

            BadgeRepo.UpdateBadge(currentBadge);
        }
        public void ListAllBadges()//List all badges
        {
            List<Badge> badgeList = BadgeRepo.GetBadgeDirectory();
            List<string> header = new List<string>//Key
            {                                     //Badge#       //Door Access
                "BadgeID", "DoorAccess"
            };

            Console.WriteLine(string.Join("\t", header));
            foreach (Badge badge in badgeList)
            {
                DisplayDirectory(badge);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void DisplayDirectory(Badge badge)
        {
            Console.WriteLine($"{badge.BadgeID}\t{string.Join(",", badge.DoorsAccessible)}");
        }
    }
}


