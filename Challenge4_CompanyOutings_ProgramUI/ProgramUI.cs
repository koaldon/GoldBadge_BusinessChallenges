using Challenge4_CompanyOuting_Data;
using Challenge4_CompanyOuting_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_CompanyOutings_ProgramUI
{
    public class ProgramUI
    {
        private readonly CompanyOutingRepository OutingRepo = new CompanyOutingRepository();
        bool continueToRun = true;
        public void Run()
        {
            Console.WriteLine("Welcome to Komodo's Company Outing Tracking System.");
            
            while(continueToRun)
            {
                MainMenu();
            }
        }
        public void MainMenu()
        {
            Console.WriteLine("Please choose an option from the following \n" +
                "1.Display all Outings\n" +
                "2.Add a new outing\n" +
                "3.Analysis\n" +
                "4.Exit");

            string selection = Console.ReadLine();
            
            switch(selection)
            {
                case "1":
                    DisplayOutingsPrompt();
                    break;
                case "2":
                    AddOutingPrompt();
                    break;
                case "3":
                    AnalysisPrompt();
                    break;
                case "4":
                    Console.WriteLine("Thank you. Goodbye!");
                    continueToRun = false;
                    break;
                default:
                    Console.WriteLine("That is not an option.");
                    MainMenu();
                    break;      
            }
        }
        public void DisplayOutingsPrompt()
        {
            List<Outing> outingList = OutingRepo.GetOutings();
            List<string> header = new List<string>
            {
                "EventDate", "EventType", "Attendance", "TotalCost", "CostPerPerson"
            };
            Console.WriteLine(string.Join("\t", header));
            foreach (Outing outing in outingList)
            {
                DisplayOuting(outing);
            }
            Console.ReadKey();
            Console.ReadKey();
        }
        public void DisplayOuting(Outing outing)
        {
            Console.WriteLine(outing.ToConsoleString());
        }
        public void AddOutingPrompt()
        {
            Outing newOuting = new Outing();

            newOuting.EventDate = AddEventDate();
            newOuting.EventType = AddEventType();
            newOuting.Attendance = AddAttendance();
            newOuting.TotalCost = AddTotalCost();

            OutingRepo.AddEventToDirectory(newOuting);
        }
        public DateTime AddEventDate()
        {
            Console.WriteLine("When did the event occur? (YYYY, MM, DD)");
            string selection = Console.ReadLine();
            DateTime.TryParse(selection, out DateTime eventDate);
            return eventDate;
        }
        public EventType AddEventType()
        {
            Console.WriteLine("What is the EventType for this event?\n" +
                "1.Golf\n" +
                "2.Bowling\n" +
                "3.Amusement Park\n" +
                "4.Concert\n" );

            string selection = Console.ReadLine();

            switch(selection)
            {
                case "1":
                    return EventType.Golf;
                case "2":
                    return EventType.Bowling;
                case "3":
                    return EventType.Amusement_Park;
                case "4":
                    return EventType.Concert;
                default:
                    Console.WriteLine("That is not an option.");
                    return AddEventType();
            }
        }
        public int AddAttendance()
        {
            Console.WriteLine("How many people were in attendance for this event?");
            string selection = Console.ReadLine();
            int.TryParse(selection, out int attendance);
            return attendance;
        }
        public decimal AddTotalCost()
        {
            Console.WriteLine("What was the total cost for this event?");
            string selection = Console.ReadLine();
            decimal.TryParse(selection, out decimal totalCost);
            return totalCost;
        }
        public void AnalysisPrompt()
        {
            Console.WriteLine("How would you like to analyse the event data?\n" +
                "1.Total Cost per EventType\n" +
                "2.Total Cost of All Events\n" +
                "3.Exit");
                    

            string selection = Console.ReadLine();

            switch(selection)
            {
                case "1":
                    CostByEvent();
                    break;
                case "2":
                    TotalCost();
                    break;
                case "3":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("This is not a valid option.");
                    AnalysisPrompt();
                    break;
            }
        }
        public void CostByEvent()
        {
            List<Outing> outings = OutingRepo.GetOutings()
                .GroupBy(x => x.EventType)
                .Select(cx => new Outing
                {
                    TotalCost = cx.Sum(c => c.TotalCost)
                }).ToList(); 
            foreach (Outing outing in outings)
            {
                Console.WriteLine($"{outing.EventType} = ${outing.TotalCost}");
            }
            Console.ReadKey();
        }
        public void TotalCost()
        {
            List<Outing> outings = OutingRepo.GetOutings();
            decimal total = outings.Sum(x => x.TotalCost);

            Console.WriteLine($"Komodo has spent a total of ${total} on company outings.");
            Console.ReadKey();
        }
        
    }
}
