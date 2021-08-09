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

        [TestMethod]
        public void ClaimsPrincipal_AuthenticatedIdentityWithEmptyClaims_IsInRole_False()
        {
            var testRoleName = "role123";

            var claims = new List<Claim>();

            var identity = new ClaimsIdentity(claims, "test");

            var principal = new ClaimsPrincipal(identity);

            var expected = false;
            var actual = principal.IsInRole(testRoleName);

            Assert.AreEqual<bool>(expected, actual, "IsInRole return value");
        }

        [TestMethod]
        public void ClaimsPrincipal_AuthenticatedIdentityWithClaims_IsInRole_True()
        {
            var roleThatShouldExist = "role123";
            var roleThatShouldNotExist = "roleASDF";

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, roleThatShouldExist));

            var identity = new ClaimsIdentity(claims, "test");

            var principal = new ClaimsPrincipal(identity);

            Assert.IsTrue(principal.IsInRole(roleThatShouldExist), "IsInRole should be true");
            Assert.IsFalse(principal.IsInRole(roleThatShouldNotExist), "IsInRole should be false");
        }

        [TestMethod]
        public void ClaimsPrincipal_AuthenticatedIdentityWithClaimsAndNonDefaultRoleClaimName_IsInRole_True()
        {
            var nonDefaultRoleClaimName = "nonDefaultRole";

            var roleThatShouldExist = "role123";
            var roleThatShouldNotExist = "roleASDF";

            var claims = new List<Claim>();

            claims.Add(new Claim(nonDefaultRoleClaimName, roleThatShouldExist));
            claims.Add(new Claim(ClaimTypes.Role, roleThatShouldNotExist));

            var identity = new ClaimsIdentity(claims, "test", ClaimTypes.Name, nonDefaultRoleClaimName);

            var principal = new ClaimsPrincipal(identity);

            Assert.IsTrue(principal.IsInRole(roleThatShouldExist), "IsInRole should be true");
            Assert.IsFalse(principal.IsInRole(roleThatShouldNotExist), "IsInRole should be false");
        }
    }
}
