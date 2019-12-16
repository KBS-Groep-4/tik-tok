using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoeiJeRot.Logic
{
    [Flags]
    public enum PermissionType
    {
        None = 0,
        Admin = 2,
        Member = 4,
        Mc = 8,
        Wc = 16,
        Staff = 32
    }

    public class Roles
    {
        public const string ADMIN = "ADMIN";
        public const string MEMBER = "MEMBER";
        public const string WC = "WC";
        public const string MC = "MC";
        public const string STAFF = "STAFF";

        public static PermissionType GetPermissionType(string[] permissions)
        {
            PermissionType permissionType = PermissionType.None;

            if (permissions.Contains(Roles.ADMIN))
            {
                permissionType |= PermissionType.Admin;
            }
            if (permissions.Contains(Roles.MC))
            {
                permissionType |= PermissionType.Mc;
            }
            if (permissions.Contains(Roles.WC))
            {
                permissionType |= PermissionType.Wc;
            }
            if (permissions.Contains(Roles.MEMBER))
            {
                permissionType |= PermissionType.Member;
            }
            if (permissions.Contains(Roles.STAFF))
            {
                permissionType |= PermissionType.Staff;
            }

            return permissionType;
        }
    }
}
