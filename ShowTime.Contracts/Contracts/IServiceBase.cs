using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.Contracts.Contracts
{
    public interface IServiceBase<TD>
        where TD : class
    {
        IQueryable<TD> Query();
    }
}
