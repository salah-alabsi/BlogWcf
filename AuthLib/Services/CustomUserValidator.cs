using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
namespace AuthLib.Services
{
    public class CustomUserValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            Console.WriteLine("Validating user: " + userName);
            AuthDbContext db = new AuthDbContext();
            var user = db.Users
            .Include("UserRoles.Role")
            .FirstOrDefault(u => u.Username == userName);


            if (user == null || !VerifyPassword(password, user.PasswordHash))
                throw new SecurityTokenException("Invalid credentials");

            var roleNames = user.UserRoles.Select(r => r.Role.Name).ToArray();
            var identity = new GenericIdentity(user.Username);
            var principal = new GenericPrincipal(identity, roleNames);

            Thread.CurrentPrincipal = principal;

            if (OperationContext.Current != null)
                OperationContext.Current.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = principal;
        }

        private bool VerifyPassword(string plain, string hash)
        {
            return plain == hash; // Replace with real hash check
        }
    }
}