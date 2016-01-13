using System;
using System.Collections.Generic;
using System.Linq;
using ShowTime.DomainService.Objects;
using ShowTime.BaseServices;


namespace ShowTime.DomainService.Contracts
{
    public interface ISysUserService : IServiceBase<SysUserInfo>
    {
        SysUserInfo CheckLogin(SysUserInfo.LoginModel model);

        SysUserInfo GetUserInfoByUserId(int userId);

        IList<SysUserInfo> GetPage(SysUserInfo.Search condition);
    }
}
