using System;
using System.Collections.Generic;
using System.Linq;
using ShowTime.DomainService.Contracts;
using ShowTime.DomainService.Objects;
using ShowTime.Objects.Model;
using ShowTime.BaseServices;

namespace ShowTime.DomainService.Services
{
    public class SysUserFunExtendService : ServiceBase<SysUserFunExtendInfo, SysUserFunExtend>, ISysUserFunExtendService
    {
        public IList<SysUserFunExtendInfo> GetUserFunExtendByUserId(int userId)
        {
            return this.Include(Query, c => c.SysFunction)
                    .Where(c => c.UserId == userId)
                    .MapTo<IList<SysUserFunExtendInfo>>();
        }
    }
}
