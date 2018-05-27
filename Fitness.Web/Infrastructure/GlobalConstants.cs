using System.Collections.Generic;

namespace Fitness.Web.Infrastructure
{
    public static class GlobalConstants
    {
        public static List<string> Roles = new List<string>()
        {
            UserRole,
            AdministratorRole
        };

        public const string UserRole = "User";
        public const string AdministratorRole = "Administrator";
    }
}
