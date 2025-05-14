using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;

public static class PermissionChecker
{
    public static bool CurrentUserHasPermission(string permissionCode)
    {
        var principal = Thread.CurrentPrincipal as GenericPrincipal;
        if (principal == null || !principal.Identity.IsAuthenticated)
            return false;
        Console.WriteLine("Checking permissions for user: " + principal.Identity.Name);
        AuthDbContext db = new AuthDbContext();
        var user = db.Users
         .Include("UserRoles.Role.RolePermissions.Permission")
         .FirstOrDefault(u => u.Username == principal.Identity.Name);


        if (user == null)
            return false;

        var permissions = user.UserRoles
                              .SelectMany(ur => ur.Role.RolePermissions)
                              .Select(rp => rp.Permission.Code);

        return permissions.Contains(permissionCode);
    }
}
