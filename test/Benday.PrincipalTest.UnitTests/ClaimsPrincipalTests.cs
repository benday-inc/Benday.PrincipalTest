using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void ClaimsPrincipal_AuthenticatedIdentityWithoutName_Name_NullOrEmpty()
        {
            var identity = new ClaimsIdentity("test");

            var principal = new ClaimsPrincipal(identity);

            var actual = principal.Identity;

            Assert.IsNotNull(actual);

            Assert.IsTrue(string.IsNullOrEmpty(actual.Name), "Name should be null or empty.");
        }

        [TestMethod]
        public void ClaimsPrincipal_AuthenticatedIdentityWithEmptyClaims_Name_NullOrEmpty()
        {
            var claims = new List<Claim>();

            var identity = new ClaimsIdentity(claims, "test");
            
            var principal = new ClaimsPrincipal(identity);

            var actual = principal.Identity;

            Assert.IsNotNull(actual);

            Assert.IsTrue(string.IsNullOrEmpty(actual.Name), "Name should be null or empty.");
        }

        [TestMethod]
        public void ClaimsPrincipal_AuthenticatedIdentityWithClaims_Name_ValueReadFromClaims()
        {
            var claims = new List<Claim>();

            var expected = "bingbong@test.org";

            claims.Add(new Claim(ClaimTypes.Name, expected));

            var identity = new ClaimsIdentity(claims, "test");

            var principal = new ClaimsPrincipal(identity);

            var actual = principal.Identity.Name;

            Assert.AreEqual<string>(expected, actual, "Name value was wrong.");
        }


    }
}
