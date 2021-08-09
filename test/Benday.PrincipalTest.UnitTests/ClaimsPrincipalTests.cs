using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Claims;

namespace Benday.PrincipalTest.UnitTests
{
    [TestClass]
    public class ClaimsPrincipalTests
    {
        [TestMethod]
        public void ClaimsPrincipal_DefaultConstructor_Identity_Null()
        {
            var principal = new ClaimsPrincipal();

            var actual = principal.Identity;

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ClaimsPrincipal_UnauthenticatedIdentity_Name_NullOrEmpty()
        {
            var identity = new ClaimsIdentity();

            var principal = new ClaimsPrincipal(identity);

            var actual = principal.Identity;

            Assert.IsNotNull(actual);

            Assert.IsTrue(string.IsNullOrEmpty(actual.Name), "Name should be null or empty.");
        }
    }
}
