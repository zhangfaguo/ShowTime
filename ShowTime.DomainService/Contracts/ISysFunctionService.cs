using System;
using System.Collections.Generic;
using System.Linq;
using ShowTime.DomainService.Objects;
using ShowTime.BaseServices;


namespace ShowTime.DomainService.Contracts
{
    public interface ISysFunctionService : IServiceBase<SysFunctionInfo>
    {
        IList<SysFunctionInfo> GetMenuFunctionByUserId(int userId);

        IList<SysFunctionInfo> GetFunctionByUserId(int userId);
    }
}
