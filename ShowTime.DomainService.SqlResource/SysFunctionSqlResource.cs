using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.DomainService.SqlResource
{
    public class SysFunctionSqlResource
    {
        public const string ShowUserAllFun = @"with cte as  
                            (  
                        select * from (select a.* from SysFunction a
                        inner join RoleFunction rf on rf.FnId=a.Id
                        inner join [Role] r on r.id=rf.RoleId
                        inner join sysuser ur on ur.RoleId=r.Id  and ur.id=@V_UID
                        union
                        select a.* from  SysFunction a
                        inner join UserFunExtend uf on uf.fnid=a.id and uf.UserId=@V_UID) b
                        union all   
                            select k.*  from SysFunction k inner join cte c on c.Parent = k.Id  
                            )select distinct * from cte ";
    }
}
