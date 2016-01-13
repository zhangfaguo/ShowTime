using Microsoft.Practices.Unity.Mvc;
using ShowTime.Controllers.DTO;
using ShowTime.Core;
using ShowTime.Data;
using ShowTime.DomainService.Contracts;
using ShowTime.DomainService.Objects;
using ShowTime.DomainService.Services;
using ShowTime.Objects.Model;
using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using StackExchange.Profiling.EntityFramework6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShowTime.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {


        #region Unity

        private void RegistUnity()
        {
            #region 系统

            UnityContaint.Instance.RegistTypeByThreadLife<DbContext, ShowTimeDataContent>();

            UnityContaint.Instance.RegistTypeByThreadLife<ILogHelper, LogHelper>();
            #endregion

            UnityContaint.Instance.RegistType<IUserService, UserService>();

            #region SysUser And Role
            UnityContaint.Instance.RegistType<IRoleService, RoleService>();
            UnityContaint.Instance.RegistType<ISysFunctionService, SysFunctionService>();
            UnityContaint.Instance.RegistType<ISysUserService, SysUserService>();
            UnityContaint.Instance.RegistType<ISysUserFunExtendService, SysUserFunExtendService>();
            UnityContaint.Instance.RegistType<IRoleFunctionService, RoleFunctionService>();
            #endregion
        }

        #endregion

        protected void Application_Start()
        {
            //注册CONTROLLER SI
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityContaint.Instance.GetContainer()));

            //Unity Containt注入与配置
            RegistUnity();

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //EF性能框架初始化
            MiniProfilerEF6.Initialize();

            //EF性能预热
            //生成VIEWS
            using (var dbcontext = new ShowTimeDataContent())
            {
                var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }

        }

        protected void Application_BeginRequest()
        {
            MiniProfiler.Start();
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

    }
}