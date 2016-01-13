using System;
using System.Collections.Generic;
using System.Linq;
using ShowTime.DomainService.Contracts;
using ShowTime.DomainService.Objects;
using ShowTime.Objects.Model;
using ShowTime.BaseServices;
using ShowTime.Core;

namespace ShowTime.DomainService.Services
{
    public class SysUserService : ServiceBase<SysUserInfo, SysUser>, ISysUserService
    {
        #region 外部服务

        ISysFunctionService _sysfunctionPrivoder;
        public ISysFunctionService SysFunctionPrivoder
        {
            get
            {
                if (_sysfunctionPrivoder == null)
                    _sysfunctionPrivoder = UnityContaint.Instance.Reloser<ISysFunctionService>();
                return _sysfunctionPrivoder;
            }
        }

        ISysUserFunExtendService _sysuserfunextendPrivoder;
        public ISysUserFunExtendService SysUserFunExtendPrivoder
        {
            get
            {
                if (_sysuserfunextendPrivoder == null)
                    _sysuserfunextendPrivoder = UnityContaint.Instance.Reloser<ISysUserFunExtendService>();
                return _sysuserfunextendPrivoder;
            }
        }
        #endregion

        public SysUserInfo CheckLogin(SysUserInfo.LoginModel model)
        {
            var user = this.Query.FirstOrDefault(c => c.Name == model.Name && c.Password == model.Password).MapTo<SysUserInfo>();

            return user;
        }

        public SysUserInfo GetUserInfoByUserId(int userId)
        {

            var user = this.Query.FirstOrDefault(c => c.Id == userId).MapTo<SysUserInfo>();
            if (user != null)
            {
                user.UserRoles = this.LoadObject(c => c.Id == user.Id, c => c.UserRoles, "UserRoles");
                user.SysUserFunExtend = SysUserFunExtendPrivoder.GetUserFunExtendByUserId(userId);
                user.Function = SysFunctionPrivoder.GetFunctionByUserId(userId);
                user.MenuFunction = SysFunctionPrivoder.GetMenuFunctionByUserId(userId);
            }
            return user;
        }

        public IList<SysUserInfo> GetPage(SysUserInfo.Search condition)
        {
            var query = this.Query;

            query = this.Include(query, c => c.UserRoles);

            if (!string.IsNullOrEmpty(condition.RealName))
                query = query.Where(c => c.RealName.Contains(condition.RealName));
            if (!string.IsNullOrEmpty(condition.Tel))
                query = query.Where(c => c.Tel.Contains(condition.Tel));
            if (condition.Statue > 0)
                query = query.Where(c => c.Statue == condition.Statue);
            query = query.OrderByDescending(c => c.Id);
            query = query.Paging(condition);
            return To<IList<SysUserInfo>>(query);
        }
    }
}
