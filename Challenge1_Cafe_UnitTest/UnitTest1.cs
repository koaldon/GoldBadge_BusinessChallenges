using System;
using System.Collections.Generic;
using System.Security.Claims;
using Challenge1_Cafe_Data;
using Challenge1_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge1_Cafe_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepository _testRepo = new MenuRepository();

        [TestInitialize]
        public void SeedRepo()
        {
            List<string> mac = new List<string> { "Cheddar", "Romano", "Asiago", "Elbow Macaroni" };
            Menu macCheese = new Menu(1, "Mac and Cheese", "Creamy blend of 3 cheeses and macaroni noodles.", mac, 6.50m);
            List<string> potato = new List<string> { "Potato", "Butter", "Shredded Cheddar", "Sour Cream" };
            Menu bakedPotato = new Menu(2, "Baked Potato", "Fresh-baked potato topped with butter, cheese, and sour cream.", potato, 10.99m);
            List<string> manhattan = new List<string> { "Roast Beef", "Brown Gravy", "Sliced Bread", "Mashed Potatoes" };
            Menu beefManhattan = new Menu(3, "Beef Manhattan", "Sliced roast beef smothered in gravy, served over bread with a side of mashed potatoes", manhattan, 13.65m);

            _testRepo.AddNewMenuItem(macCheese);
            _testRepo.AddNewMenuItem(bakedPotato);
            _testRepo.AddNewMenuItem(beefManhattan);
        }
        [TestMethod]
        public void ItemGetCountShouldProduceCount()
        {
            //Arrange
            int expected = 3;
            int actual;

            //Act
            actual = _testRepo.GetMenu().Count;

            //Assert          
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddItemShouldAdd()
        {
            //Arrange
            List<string> manhattan2 = new List<string> { "Roast Beef", "Brown Gravy", "Sliced Bread", "Mashed Potatoes" };
            Menu roastBronx = new Menu(4, "Roast Bronx", "Sliced roast beef smothered in gravy, served over bread with a side of mashed potatoes", manhattan2, 13.65m);

            bool expected = true;
            bool actual;

            //Act
            actual = _testRepo.AddNewMenuItem(roastBronx);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetItemByNameShouldGetItem()
        {
            //Arrange
            List<string> manhattan2 = new List<string> { "Roast Beef", "Brown Gravy", "Sliced Bread", "Mashed Potatoes" };
            Menu roastBronx = new Menu(4, "Roast Bronx", "Sliced roast beef smothered in gravy, served over bread with a side of mashed potatoes", manhattan2, 13.65m);
            _testRepo.AddNewMenuItem(roastBronx);

            string testItem = "Roast Bronx";

            Menu expected = roastBronx;
            Menu actual;

            //Act
            actual = _testRepo.GetItemByName(testItem);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveItemByNameShouldRemoveItem()
        {
            //Arrange
            List<string> manhattan2 = new List<string> { "Roast Beef", "Brown Gravy", "Sliced Bread", "Mashed Potatoes" };
            Menu roastBronx = new Menu(4, "Roast Bronx", "Sliced roast beef smothered in gravy, served over bread with a side of mashed potatoes", manhattan2, 13.65m);
            _testRepo.AddNewMenuItem(roastBronx);

            string testItem = "Roast Bronx";

            bool expected = true;
            bool actual;


            //Act
            actual=_testRepo.RemoveItemByName(testItem);

            //Assert
            Assert.AreEqual(expected,actual);
        }

    }
}
