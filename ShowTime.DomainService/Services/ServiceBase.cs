using Microsoft.Practices.Unity;
using ShowTime.Core;
using ShowTime.Data;
using ShowTime.DomainService.Contracts;
using ShowTime.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowTime.DomainService.Services
{
    public class ServiceBase<T, TB> : IServiceBase<T, TB>
        where T : class
        where TB : class
    {
        private IEfOfWork _privoder;

        protected IEfOfWork privoder
        {
            get
            {

                _privoder = UnityContaint.Instance.Reloser<IEfOfWork>();
                return _privoder;
            }

        }

        protected IQueryable<TB> Set
        {
            get
            {
                return privoder.Query<TB>();
            }
        }

        #region  Convert
        public T2 To<T2, T1>(T1 source)
        {
            return AutoMapper.Mapper.Map<T2>(source);
        }

        public T Convert<TB>(TB source)
        {
            return AutoMapper.Mapper.Map<T>(source);
        }
        #endregion

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<TB, bool>> filter = null)
        {
            if (filter != null)
                Set.Where(filter);
            return To<IEnumerable<T>, IEnumerable<TB>>(Set);

        }

        public T Single(System.Linq.Expressions.Expression<Func<TB, bool>> filter)
        {
            return Convert(Set.Single(filter));
        }

        #region Add
        public T Add(T entity)
        {
            var model = To<TB, T>(entity);

            return Convert(privoder.Add(model));
        }

        public void AddAndNotSave(T entity)
        {
            var model = To<TB, T>(entity);
            privoder.AddAndNotSave(model);
        }
        #endregion

        public int Update(System.Linq.Expressions.Expression<Func<TB, bool>> filter, System.Linq.Expressions.Expression<Func<TB, TB>> updaeFile)
        {
            privoder.Update(filter, updaeFile);
            return Save();
        }

        public int Delete(System.Linq.Expressions.Expression<Func<TB, bool>> filter)
        {
            privoder.Delete(filter);
            return Save();
        }

        #region Paging

        public IList<T> Paging(System.Linq.Expressions.Expression<Func<TB, bool>> filetr, System.Linq.Expressions.Expression<Func<TB, object>> order, PageInfo page, bool isCaching = false)
        {
            var query = Set.Where(filetr);

            query = query.OrderBy(order);
            return this.Paging(query, page, isCaching);
        }

        public IList<T> Paging(IQueryable<TB> query, PageInfo page, bool isCaching = false)
        {
            page.RecordCount = query.Count();

            if (page.PageSize == 0)
                page.PageSize = 10;

            page.PageCount = (page.RecordCount + page.PageSize - 1) / page.PageSize;

            if (page.PageIndex < 1)
                page.PageIndex = 1;
            if (page.PageIndex > page.PageCount && page.PageCount != 0)
                page.PageIndex = page.PageCount;

            var takeRecord = (page.PageIndex - 1) * page.PageSize;

            var list = query.Skip(takeRecord).Take(page.PageSize);
            if (isCaching)
                list = privoder.Cache(list);

            return To<IList<T>, IList<TB>>(list.ToList());
        }

        #endregion

        public bool BeginTransaction(Action act)
        {
            return privoder.BeginTransaction(act);
        }

        public int Save()
        {
            return privoder.Save();
        }


        protected IQueryable<TB> Include(IQueryable<TB> query, string path)
        {
            return privoder.Include(query, path);
        }


        public int Update(System.Linq.Expressions.Expression<Func<TB, bool>> filter, System.Linq.Expressions.Expression<Func<T, T>> updaeFile)
        {
            throw new NotImplementedException();
        }
    }
}
