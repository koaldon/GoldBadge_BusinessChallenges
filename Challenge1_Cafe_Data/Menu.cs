using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe_Data
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string>Ingredients { get; set; } = new List<string>();
        public decimal Price { get; set; }


        public Menu()
        {

        }

        public Menu(int menuNumber, string mealName, string description, List<string>ingredients, decimal price)
        {
            MealNumber = menuNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
