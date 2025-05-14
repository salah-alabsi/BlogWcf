using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLib.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
