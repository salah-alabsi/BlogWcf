using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;

namespace BlogLib
{
    public static class PermissionChecker
    {
        // Role to permission mapping
        private static readonly Dictionary<string, List<string>> RolePermissions = new Dictionary<string, List<string>>()
    {
        { "Author", new List<string>() { "add-post" } },
        { "Editor", new List<string>() { "edit-post", "publish-post" } },
        { "Admin", new List<string>() { "add-post", "edit-post", "delete-post", "manage-users" } }
    };

        public static bool CurrentUserHasPermission(string permission)
        {
            var user = Thread.CurrentPrincipal;
            Console.WriteLine("salah is here");

            if (user == null || !user.Identity.IsAuthenticated)
                return false;
           

            // So instead, add a debug log:
            Console.WriteLine($"Current user: {user.Identity.Name}");
            foreach (var role in RolePermissions.Keys)
            {
                if (user.IsInRole(role) && RolePermissions[role].Contains(permission))
                    return true;
            }

            return false;
        }
    }

}
