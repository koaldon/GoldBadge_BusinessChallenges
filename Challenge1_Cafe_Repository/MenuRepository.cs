using Challenge1_Cafe_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge1_Cafe_Repository
{
    public class MenuRepository
    {
        private List<Menu> _menuDirectory = new List<Menu>();

        //Create
             //create new menu items
        public bool AddNewMenuItem(Menu item)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(item);
            bool wasAdded = _menuDirectory.Count == startingCount + 1;
            return wasAdded;
        }
        //Read
             //receive a list of all items on cafe menu
        public List<Menu> GetMenu()
        {
            return _menuDirectory;
        }

        public Menu GetItemByName(string name)
        {
            foreach(Menu meal in _menuDirectory)
            {
                if (meal.MealName.ToLower() == name.ToLower())
                {
                    return meal;
                }
            }
            return null;
        }
        //Update
        //not needed at this time
        //Delete
            //delete menu items
        public bool RemoveItemByName(string name)
        {
            Menu meal = GetItemByName(name);
            if (meal == null)
            {
                Console.WriteLine("This is not an item on the current menu.");
                return false;
            }
            else{
                _menuDirectory.Remove(meal);
                Console.WriteLine($"{meal} has been removed from the menu.");
                return true;
            }
        }
            
    }
}
