﻿using System;
using System.Collections.Generic;
using System.Linq;
using ShowTime.DomainService.Objects;
using ShowTime.BaseServices;


namespace ShowTime.DomainService.Contracts
{
    public interface ISysUserFunExtendService : IServiceBase<SysUserFunExtendInfo>
    {
        IList<SysUserFunExtendInfo> GetUserFunExtendByUserId(int userId);
    }
}
