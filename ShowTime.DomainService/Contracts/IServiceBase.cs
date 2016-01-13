using ShowTime.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.DomainService.Contracts
{
    public interface IServiceBase<T, TB>
        where T : class
        where TB : class
    {

        IList<T> Paging(IQueryable<TB> query, PageInfo page, bool isCaching = false);

        IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<TB, bool>> filter = null);

        T2 To<T2, T1>(T1 source);

        T Single(System.Linq.Expressions.Expression<Func<TB, bool>> filter);

        T Add(T entity);

        void AddAndNotSave(T entity);

        int Update(System.Linq.Expressions.Expression<Func<TB, bool>> filter, System.Linq.Expressions.Expression<Func<T, T>> updaeFile);

        int Delete(System.Linq.Expressions.Expression<Func<TB, bool>> filter);

        int Save();

        bool BeginTransaction(Action act);
    }
}
