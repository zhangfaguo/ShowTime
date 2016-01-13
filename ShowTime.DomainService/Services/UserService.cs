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
    public class UserService : ServiceBase<UserInfo, User>, IUserService
    {

    }
}
