
using ShowTime.Objects.Model;
using System;
using System.Data.Entity;

namespace ShowTime.Data
{
    public class ShowTimeDataContent : DbContext
    {
        public ShowTimeDataContent()
            : base()
        {
            Database.SetInitializer<ShowTimeDataContent>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> User { get; set; }

        #region 系统用户与角色
        public DbSet<Role> Role { get; set; }

        public DbSet<SysFunction> SysFunction { get; set; }

        public DbSet<SysUser> SysUser { get; set; }

        public DbSet<SysUserFunExtend> SysUserFunExtend { get; set; }

        public DbSet<RoleFunction> RoleFunction { get; set; }
        #endregion

        public DbSet<LockClient> Lock { get; set; }

    }
}
