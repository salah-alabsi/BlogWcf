using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors; // Needed for UserNamePasswordValidator
using System.IdentityModel.Tokens;    // Needed for SecurityTokenException
using System.Linq;
using System.Security.Principal;      // Needed for GenericPrincipal
using System.ServiceModel;            // WCF namespace
using System.Threading;               // Needed to set Thread.CurrentPrincipal

namespace BlogLib.blog
{
    public class CustomUserValidator : UserNamePasswordValidator
    {
        // Simulated "database" tables
        private static readonly List<User> Users = new List<User>()
    {
        new User { Username = "alice", Password = "pass", RoleNames = new[] { "Author" } },
        new User { Username = "bob", Password = "pass", RoleNames = new[] { "Editor" } }
    };

        public override void Validate(string userName, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == userName && u.Password == password);
            if (user == null)
                throw new SecurityTokenException("Invalid credentials");

            var identity = new GenericIdentity(user.Username);
            var principal = new GenericPrincipal(identity, user.RoleNames);

            Thread.CurrentPrincipal = principal;

            if (OperationContext.Current != null)
            {
                OperationContext.Current.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = principal;
            }
        }

        private class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string[] RoleNames { get; set; }
        }
    }

}
