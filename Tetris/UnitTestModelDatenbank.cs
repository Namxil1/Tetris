using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetris.Tests
{
    [TestClass]
    public class ModelDatenbankTests
    {
        private ModelDatenbank _modelDatenbank;

        [TestInitialize]
        public void TestInitialize()
        {
            _modelDatenbank = new ModelDatenbank();
        }

        [TestMethod]
        public void InDatenbankVorhanden()
        {
            // Arrange
            string username = "admin";
            string password = "admin";

            // Act
            int result = _modelDatenbank.GetUserID(username, password);

            // Assert
            Assert.AreEqual(3, result);
        }


        [TestMethod]
        public void TestNeuenUserRegistrieren()
        {
            // Arrange
            string username = "Test";
            string password = "Test";

            // Act
            int result = _modelDatenbank.RegisterUser(username, password);

            // Assert
            Assert.IsTrue(result > 0); 
        }

        [TestMethod]
        public void TestUserBereitsVorhanden()
        {
            // Arrange
            string username = "admin";
            string password = "admin";

            // Act
            int result = _modelDatenbank.RegisterUser(username, password);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestGetName()
        {
            // Arrange
            int userID = 3;

            // Act
            string result = _modelDatenbank.getName(userID);

            // Assert
            Assert.AreEqual("admin", result);
        }

        [TestMethod]
        public void TestAufHighscore()
        {
            // Arrange
            int userID = 1;
            int newScore = 100;

            // Act
            _modelDatenbank.setHighscore(userID, newScore);

            // Assert
            int updatedHighscore = _modelDatenbank.getHighscore(userID);
            Assert.AreEqual(newScore, updatedHighscore);
        }

    }
}
