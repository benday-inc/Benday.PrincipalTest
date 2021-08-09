using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Security.Claims;

namespace Benday.PrincipalTest.UnitTests
{
    [TestClass]
    public class ClaimsIdentityTests
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

        [TestMethod]
        public void ClaimsIdentity_DefaultNameClaimType_ClaimTypesName()
        {
            var identity = new ClaimsIdentity(authenticationType: "test");

            var expected = ClaimTypes.Name;

            var actual = identity.NameClaimType;

            Assert.AreEqual<string>(expected, actual, "NameClaimType was wrong");
        }

        [TestMethod]
        public void ClaimsIdentity_AuthenticatedIdentityWithEmptyClaims_Name_NullOrEmpty()
        {
            var claims = new List<Claim>();

            var identity = new ClaimsIdentity(claims, "test");

            Assert.IsTrue(string.IsNullOrEmpty(identity.Name), "Name should be null or empty.");
        }

        [TestMethod]
        public void ClaimsIdentity_AuthenticatedIdentityWithClaims_Name_ValueReadFromClaims()
        {
            var claims = new List<Claim>();

            var expected = "bingbong@test.org";

            claims.Add(new Claim(ClaimTypes.Name, expected));

            var identity = new ClaimsIdentity(claims, "test");

            var actual = identity.Name;

            Assert.AreEqual<string>(expected, actual, "Name value was wrong.");            
        }

        [TestMethod]
        public void ClaimsIdentity_DefaultRoleClaimType_ClaimTypesRole()
        {
            var identity = new ClaimsIdentity(authenticationType: "test");

            var expected = ClaimTypes.Role;

            var actual = identity.RoleClaimType;

            Assert.AreEqual<string>(expected, actual, "RoleClaimType was wrong");
        }
    }
}
