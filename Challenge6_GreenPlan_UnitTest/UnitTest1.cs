using System;
using Challenge2_Claims_Data;
using Challenge2_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge2_Claims_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepository _testRepo = new ClaimsRepository();

        [TestMethod]
        public void ClaimCountShouldProduceCount()
        {
            //Assert
            int expected = 3;
            int actual;

            //Act
            actual = _testRepo.GetClaim().Count;

            //Arrange
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddClaimCountShouldAdd()
        {
            //Arrange
            Claim claimFour = new Claim(4, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            _testRepo.AddNewClaim(claimFour);

            bool expected = true;
            bool actual;

            //Act
            actual = _testRepo.AddNewClaim(claimFour);

            //Assert
            Assert.AreEqual(expected, actual); ;
        }
        [TestMethod]
        public void GetClaimByClaimIDShouldGetClaim()
        {
            //Arrange
            Claim claimFour = new Claim(4, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            _testRepo.AddNewClaim(claimFour);
            Claim claimFive = new Claim(5, ClaimType.Home, "Broken Window", 400.00m, new DateTime(2018, 05, 15), new DateTime(2018, 05, 20));
            _testRepo.AddNewClaim(claimFive);
            Claim claimSix = new Claim(6, ClaimType.Car, "Rear bumper damage due to hit and run", 3000.00m, new DateTime(2018, 02, 27), new DateTime(2018, 03, 01));
            _testRepo.AddNewClaim(claimSix);

            int testClaim = 4;

            Claim expected = claimFour;
            Claim actual;

            //Act
            actual = _testRepo.GetClaimByClaimID(testClaim);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveClaimByIDShouldRemoveItem()
        {
            //Arrange
            Claim claimThree = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01));
            _testRepo.AddNewClaim(claimThree);

            bool expected = true;
            bool actual;

            int testClaim = 3;

            //Act
            actual = _testRepo.RemoveClaimByClaimID(testClaim);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateClaimByClaimIDShouldUpdate()
        {
            //Arrange
            Claim newClaimTwo = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4500.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));
            _testRepo.UpdateClaimByClaimID(2, newClaimTwo);

            int testClaim = 2;
            Claim testUpdate = new Claim(2, ClaimType.Home, "House fire in kitchen--arson", 4500.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12));

            bool expected = true;
            bool actual;

            //Act
            actual = _testRepo.UpdateClaimByClaimID(testClaim, testUpdate);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
