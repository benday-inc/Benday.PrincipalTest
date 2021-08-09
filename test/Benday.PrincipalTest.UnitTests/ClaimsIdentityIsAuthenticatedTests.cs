using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Claims;

namespace Benday.PrincipalTest.UnitTests
{
    [TestClass]
    public class ClaimsIdentityIsAuthenticatedTests
    {
        [TestMethod]
        public void ClaimsIdentity_DefaultConstructor_IsAuthenticated_False()
        {
            var identity = new ClaimsIdentity();

            Assert.IsFalse(identity.IsAuthenticated, "IsAuthenticated");
        }

        [TestMethod]
        public void ClaimsIdentity_AuthenticationTypeSetToNull_IsAuthenticated_False()
        {
            var identity = new ClaimsIdentity(authenticationType: null);

            Assert.IsFalse(identity.IsAuthenticated, "IsAuthenticated");
        }

        [TestMethod]
        public void ClaimsIdentity_AuthenticationTypeSet_IsAuthenticated_True()
        {
            var identity = new ClaimsIdentity(authenticationType: "test");

            Assert.IsTrue(identity.IsAuthenticated, "IsAuthenticated");
        }
    }
}
