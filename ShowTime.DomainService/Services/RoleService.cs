using System;
using System.Collections.Generic;
using System.Linq;
using ShowTime.DomainService.Contracts;
using ShowTime.DomainService.Objects;
using ShowTime.Objects.Model;
using ShowTime.BaseServices;

namespace ShowTime.DomainService.Services
{
    public class RoleService : ServiceBase<RoleInfo, Role>, IRoleService
    {
        public IList<RoleInfo> GetAllRole()
        {
            var query = this.Include(Query, c => c.RoleFunction);
            query = query.OrderBy(c => c.Id);
            return To<IList<RoleInfo>>(query);

        }
    }
}
