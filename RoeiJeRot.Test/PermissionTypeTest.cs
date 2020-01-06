using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RoeiJeRot.Logic;

namespace RoeiJeRot.Test
{
    [TestFixture]
    class PermissionTypeTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PermissionTypeEnumFromStringShouldContainFlags()
        {
            var permissionType = Roles.GetPermissionType(new string[] { Roles.ADMIN,Roles.MC,Roles.WC,Roles.MEMBER,Roles.STAFF });
            Assert.True(permissionType.HasFlag(PermissionType.Mc));
            Assert.True(permissionType.HasFlag(PermissionType.Admin));
            Assert.True(permissionType.HasFlag(PermissionType.Member));
            Assert.True(permissionType.HasFlag(PermissionType.Wc));
        }

        [Test]
        public void GetPermissionTypeEnumFromStringShouldBeNone()
        {
            var permissionType = Roles.GetPermissionType(new string[] { });
            Assert.True(permissionType.HasFlag(PermissionType.None));
        }
    }
}
