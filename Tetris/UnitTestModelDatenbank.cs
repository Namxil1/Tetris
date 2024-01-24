using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetris.Tests
{
    [TestClass]
    public class ModelDatenbankTests
    {
        private IModel model;

        [TestInitialize]
        public void TestInitialize()
        {
            model = new ModelDatenbank();
        }

        [TestMethod]
        public void InDatenbankVorhanden()
        {
            // Arrange
            string username = "admin";
            string password = "admin";

            // Act
            int result = model.GetUserID(username, password);

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
            int result = model.RegisterUser(username, password);

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
            int result = model.RegisterUser(username, password);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestGetName()
        {
            // Arrange
            int userID = 3;

            // Act
            string result = model.getName(userID);

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
            model.setHighscore(userID, newScore);

            // Assert
            int updatedHighscore = model.getHighscore(userID);
            Assert.AreEqual(newScore, updatedHighscore);
        }

    }
}
