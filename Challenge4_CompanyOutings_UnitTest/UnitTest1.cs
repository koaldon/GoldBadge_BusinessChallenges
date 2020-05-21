using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Challenge4_CompanyOuting_Data;
using Challenge4_CompanyOuting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge4_CompanyOutings_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private CompanyOutingRepository _testRepo = new CompanyOutingRepository();

        [TestInitialize]
        public void SeedRepo()
        {
            Outing outingOne = new Outing(EventType.Amusement_Park, 200, new DateTime(2019, 05, 14), 15000);
            Outing outingTwo = new Outing(EventType.Concert, 40, new DateTime(2019, 10, 26), 1200);

            _testRepo.AddEventToDirectory(outingOne);
            _testRepo.AddEventToDirectory(outingTwo);
        }
        [TestMethod]
        public void EventGetCountShouldProduceCount()
        {
            //Arrange
            int expected = 2;
            int actual;

            //Act
            actual = _testRepo.GetOutings().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddEventShouldAdd()
        {
            //Arrange
            Outing outingThree = new Outing(EventType.Golf, 5, new DateTime(2019, 03, 05), 500);
            _testRepo.AddEventToDirectory(outingThree);

            bool expected = true;
            bool actual;

            //Act
            actual = _testRepo.AddEventToDirectory(outingThree);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateEventByEventShouldUpdate()
        {
            //Arrange
            Outing outingThree = new Outing(EventType.Golf, 5, new DateTime(2019, 03, 05), 500);
            _testRepo.AddEventToDirectory(outingThree);
            DateTime testDate = new DateTime(2019, 03, 05);
            Outing testUpdate = new Outing(EventType.Golf, 5, new DateTime(2019, 03, 05), 675);

            bool expected = true;
            bool actual;

            //Act
            actual = _testRepo.UpdateEventByEventDate(testDate, testUpdate);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetEventByEventTypeShouldContainAddedEvent()
        {
            //Arrange
            Outing outingTest = new Outing(EventType.Concert, 40, new DateTime(2019, 05, 26), 1200);
            _testRepo.AddEventToDirectory(outingTest);

            EventType testEvent = EventType.Concert;

            bool expected = true;
            bool actual;

            //Act
            actual = _testRepo.GetEventByEventType(testEvent).Contains(outingTest);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetEventByEventTypeOnlyReturnsEventTypesGiven()
        {
            //Arrange
            Outing outingTest = new Outing(EventType.Concert, 40, new DateTime(2019, 05, 26), 1200);
            _testRepo.AddEventToDirectory(outingTest);
            Outing outingTest1 = new Outing(EventType.Amusement_Park, 200, new DateTime(2020, 05, 26), 1200);
            _testRepo.AddEventToDirectory(outingTest1);
            Outing outingTest2 = new Outing(EventType.Bowling, 10, new DateTime(2018, 05, 26), 1200);
            _testRepo.AddEventToDirectory(outingTest2);

            EventType testEvent = EventType.Concert;

            bool expected = true;
            bool actual;

            //Act
            List<Outing> outings = _testRepo.GetEventByEventType(testEvent);
            bool actual2 = true;
            foreach (Outing outing in outings)//using Foreach to go through the list
            {
                if (outing.EventType != EventType.Concert)
                {
                    actual2 = false;
                }
            }

            actual = outings.All(x => x.EventType == EventType.Concert); //using LINQ to ensure that ALL outings have an EventType of Concert

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actual2);
        }
        [TestMethod]
        public void GetEventByEventDateShouldGetEvent()
        {
            //Arrange
            Outing outingTest = new Outing(EventType.Concert, 40, new DateTime(2019, 05, 26), 1200);
            _testRepo.AddEventToDirectory(outingTest);

            DateTime testDate = new DateTime(2019, 05, 26);

            Outing expected = outingTest;
            Outing actual;

            //Act
            actual = _testRepo.GetEventByEventDate(testDate);

            //Asset
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveEventByEventDateShouldRemoveEvent()
        {
            //Arrange
            Outing outingTest = new Outing(EventType.Concert, 40, new DateTime(2019, 05, 26), 1200);
            _testRepo.AddEventToDirectory(outingTest);
            
            bool expected = true;
            bool actual;

            DateTime testDate = new DateTime(2019, 05, 26);

            //Act
            actual = _testRepo.RemoveEventByEventDate(testDate);

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
