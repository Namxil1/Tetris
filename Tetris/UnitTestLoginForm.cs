using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetris.Tests
{
    [TestClass]
    public class LoginFormTests
    {
        [TestMethod]
        public void TestLogin()
        {
            // Arrange
            LoginForm loginForm = new LoginForm();
            string Username = "admin";
            string Password = "admin";

            // Act
            int result = loginForm.login.loginUser(Username, Password);

            // Assert
            Assert.IsTrue(result > 0, "login erfolgreich");
        }

        [TestMethod]
        public void TestRegistrierung()
        {
            // Arrange
            LoginForm loginForm = new LoginForm();
            string Username = "NeuerUser";
            string Password = "NeuesPasswort";

            // Act
            int[] result = loginForm.login.registerUser(Username, Password);

            // Assert
            Assert.IsTrue(result[0] == 1 && result[1] > 0, "registrierung erfolgreich");
        }
    }
}
