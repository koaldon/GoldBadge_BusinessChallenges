using Challenge1_Cafe_Data;
using Challenge1_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe
{
    public class MenuApp
    {
        private readonly MenuRepository MenuRepo = new MenuRepository();
        bool continueToRun = true;
        public void Run()
        {
            Console.WriteLine("Welcome to the Komodo Cafe!");

            while (continueToRun)
            {
                MenuOptions();
            }
        }
        public void MenuOptions()
        {
            Console.WriteLine("Please choose an option from the following:\n" +
                    "1.Add an item to the menu\n" +
                    "2.Delete an item from the menu\n" +
                    "3.See all items in the menu\n" +
                    "4.Exit");

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    AddToMenu();
                    break;
                case "2":
                    DeleteFromMenu();
                    break;
                case "3":
                    GetMenu();
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
        public void AddToMenu()
        {
            Console.WriteLine("What is the name of the item you wish to add to the menu?");
            string mealName = Console.ReadLine();

            Console.WriteLine("What is the meal number for this item? (ie. 1, 2, 3, etc)");
            string selection = Console.ReadLine();
            int.TryParse(selection, out int menuNumber);

            Console.WriteLine("What is the description for this meal?");
            string description = Console.ReadLine();

            Console.WriteLine("What is the price of this meal?");
            string stringPrice = Console.ReadLine();
            decimal.TryParse(stringPrice, out decimal price);

            List<string> ingredients = PromptUserForIngredients(new List<string>());

            MenuRepo.AddNewMenuItem(new Menu(menuNumber, mealName, description, ingredients, price));
        }

        public List<string> PromptUserForIngredients(List<string> ingredients)
        {
            Console.WriteLine("Would you like to add an ingredient?\n" +
                "1. Yes\n" +
                "2. No");

            string selection = Console.ReadLine();

            return ParseUserSelectionForIngredients(selection, ingredients);
        }
        public List<string> ParseUserSelectionForIngredients(string selection, List<string> ingredients)
        {
            if (selection == "1")
            {
                PromptUserForItem(ingredients);
                return PromptUserForIngredients(ingredients);
            }
            else
            {
                return ingredients;
            }
        }

        public List<string> PromptUserForItem(List<string> ingredients)
        {
            Console.WriteLine("Please enter an ingredient.");
            string ingredient = Console.ReadLine();

            ingredients.Add(ingredient);

            return ingredients;
        }
        public void DeleteFromMenu()
        {
            Console.WriteLine("What is the name of the menu item you would like to delete?");
            string selection = Console.ReadLine();

            MenuRepo.RemoveItemByName(selection);
        }
        public void GetMenu()
        {
            List<Menu> menuList = MenuRepo.GetMenu();

            foreach (Menu meal in menuList)
            {
                DisplayMenu(meal);
            }
            Console.ReadKey();
        }
        public void DisplayMenu(Menu meal)
        {
            Console.WriteLine($"Meal #{meal.MealNumber}: {meal.MealName} -- {meal.Description} -- Contains: {string.Join(", ",meal.Ingredients)}. Price: ${meal.Price}");
        }
    }
}
