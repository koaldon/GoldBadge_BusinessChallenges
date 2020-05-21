using System;
using System.Collections.Generic;
using Challenge3_Badges_Data;
using Challenge3_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge3_Badges_UnitTest
{
    [TestClass]
    public class RepositoryTest
    {
        private BadgeRepository _testRepo = new BadgeRepository();

        [TestInitialize]
        public void SeedRepo()
        {
            List<string> one = new List<string> { "A1", "B1", "C3" };
            Badge badgeOne = new Badge(1, one);
            List<string> two = new List<string> { "B1" };
            Badge badgeTwo = new Badge(2, two);

            _testRepo.AddNewBadge(badgeOne);
            _testRepo.AddNewBadge(badgeTwo);
        }

        [TestMethod]
        public void BadgeGetCountShouldProduceCount()
        {
            //Arrange
            int expected = 2;
            int actual;

            //Act
            actual = _testRepo.GetBadgeDirectory().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddBadgeShouldAddNewBadge()
        {
            //Arrange
            List<string> three = new List<string> { "A4", "A5" };
            Badge badgeThree = new Badge(3, three);
            bool expected = true;
            bool actual;

            //Act
            actual = _testRepo.AddNewBadge(badgeThree);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetBadgeByBadgeIDShouldGetBadge()
        {
            //Arrange
            List<string> three = new List<string> { "A4", "A5" };
            Badge badgeThree = new Badge(3, three);
            _testRepo.AddNewBadge(badgeThree);

            List<string> four = new List<string> { "C4", "D5" };
            Badge badgeFour = new Badge(4, four);
            _testRepo.AddNewBadge(badgeFour);

            List<string> five = new List<string> { "E4", "F5" };
            Badge badgeFive = new Badge(5, five);
            _testRepo.AddNewBadge(badgeFive);

            int testBadgeID = 4;

            Badge expected = badgeFour;
            Badge actual;

            //Act
            actual = _testRepo.GetBadgeByBadgeID(testBadgeID);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateBadgeByBadgeID()
        {
            //Arrange
            List<string> three = new List<string> { "A4", "A5" };
            Badge badgeThree = new Badge(3, three);
            _testRepo.AddNewBadge(badgeThree);
            int testBadgeID = 3;
            List<string> testDoors = new List<string>{ "A3", "B2" };
            Badge testUpdate = new Badge(3, testDoors);

            bool expected = true;
            bool actual;

            //Act
            actual = _testRepo.UpdateBadgeByBadgeID(testBadgeID, testUpdate);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RemoveBadgeByBadgeIDShouldRemoveBadge()
        {
            //Arrange
            List<string> three = new List<string> { "A4", "A5" };
            Badge badgeThree = new Badge(3, three);
            _testRepo.AddNewBadge(badgeThree);

            bool expected = true;
            bool actual;

            int testBadgeID = 2;

            //Act
            actual = _testRepo.DeleteBadgeByBadgeID(2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
