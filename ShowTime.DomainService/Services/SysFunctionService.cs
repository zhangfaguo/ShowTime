using System;
using System.Collections.Generic;
using System.Linq;
using ShowTime.DomainService.Contracts;
using ShowTime.DomainService.Objects;
using ShowTime.Objects.Model;
using ShowTime.BaseServices;
using ShowTime.DomainService.SqlResource;

namespace ShowTime.DomainService.Services
{
    public class SysFunctionService : ServiceBase<SysFunctionInfo, SysFunction>, ISysFunctionService
    {
        public IList<SysFunctionInfo> GetMenuFunctionByUserId(int userId)
        {
            var sql = SysFunctionSqlResource.ShowUserAllFun;
            var parm = new Dictionary<string, object>();
            parm.Add("V_UID", userId);

            return this.RunSql<SysFunctionInfo>(sql, parm);
        }

        public IList<SysFunctionInfo> GetFunctionByUserId(int userId)
        {
            var q = from c in this.Set
                    join b in this.privoder.Set<RoleFunction>() on c.Id equals b.FnId
                    join f in this.privoder.Set<Role>() on b.RoleId equals f.Id
                    join u in this.privoder.Set<SysUser>() on f.Id equals u.RoleId
                    where u.Id == userId
                    select c;
            return To<IList<SysFunctionInfo>>(q.ToList());
        }

    }
}
