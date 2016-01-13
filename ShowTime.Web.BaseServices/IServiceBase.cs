using System;
using System.Collections.Generic;
using ShowTime.Objects;

namespace ShowTime.BaseServices
{
    public interface IServiceBase<T>
        where T : class
    {

        IEnumerable<T> Find<TKEY>(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, System.Linq.Expressions.Expression<Func<T, TKEY>> order = null, string descTag = "desc");

        T1 To<T1>(object source)
         where T1 : class;


        T Single(System.Linq.Expressions.Expression<Func<T, bool>> filter);

        T Add(T entity);

        int Update(System.Linq.Expressions.Expression<Func<T, bool>> filter, System.Linq.Expressions.Expression<Func<T, T>> updaeFile);

        int Delete(System.Linq.Expressions.Expression<Func<T, bool>> filter);

        TElment LoadObject<TElment>(System.Linq.Expressions.Expression<Func<T, bool>> filter, System.Linq.Expressions.Expression<Func<T, TElment>> pref, string path)
            where TElment : class;

        System.Collections.Generic.ICollection<TElment> LoadCollen<TElment>(System.Linq.Expressions.Expression<Func<T, bool>> filter, System.Linq.Expressions.Expression<Func<T, System.Collections.Generic.ICollection<TElment>>> pref, string path)
           where TElment : class;

        int Save();

        bool BeginTransaction(Action act);

        int Count(System.Linq.Expressions.Expression<Func<T, bool>> filter);
    }
}
