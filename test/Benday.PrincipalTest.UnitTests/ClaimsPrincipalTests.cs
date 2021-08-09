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


    }
}
