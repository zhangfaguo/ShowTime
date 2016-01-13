using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ShowTime.Core;
using ShowTime.Data;
using ShowTime.Objects;
using System.Data.Entity;
using EntityFramework.Extensions;
using EntityFramework.Caching;
using System.Diagnostics;

namespace ShowTime.BaseServices
{
    public abstract class ServiceBase<T, TB> : IServiceBase<T>
        where T : class
        where TB : class
    {
        private DbContext _privoder;

        protected DbContext privoder
        {
            get
            {

                _privoder = UnityContaint.Instance.Reloser<DbContext>();
                return _privoder;
            }

        }

        protected DbSet<TB> Set
        {
            get
            {
                return privoder.Set<TB>();
            }
        }


        protected IQueryable<TB> Query
        {
            get
            {
                return Set;
            }
        }

        #region  Convert

        public T1 To<T1>(object source)
            where T1 : class
        {
            return source.MapTo<T1>();
        }

        public T Convert(TB source)
        {
            return source.MapTo<T>();
        }

        #endregion

        public IEnumerable<T> Find<TKEY>(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, System.Linq.Expressions.Expression<Func<T, TKEY>> order = null, string descTag = "desc")
        {
            ExpressionVisitor<TB, Func<TB, bool>> vistor = new ExpressionVisitor<TB, Func<TB, bool>>();
            var qurey = Query;
            if (filter != null)
            {
                var f = vistor.Vsit(filter);
                qurey = qurey.Where(f);
            }
            if (order != null)
            {
                ExpressionVisitor<TB, Func<TB, TKEY>> vistor1 = new ExpressionVisitor<TB, Func<TB, TKEY>>();
                var ff = vistor1.Vsit(order);
                if (descTag == "desc")
                    qurey = qurey.OrderByDescending(ff);
                else
                    qurey = qurey.OrderBy(ff);
            }
            return To<IEnumerable<T>>(qurey);

        }

        public T Single(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            ExpressionVisitor<TB, Func<TB, bool>> vistor = new ExpressionVisitor<TB, Func<TB, bool>>();
            var f = vistor.Vsit(filter);

            return Convert(Set.FirstOrDefault(f));
        }

        #region Add
        public T Add(T entity)
        {
            var model = To<TB>(entity);
            var entity1 = Set.Add(model);
            this.Save();
            return Convert(entity1);
        }

        #endregion

        public int Update(System.Linq.Expressions.Expression<Func<T, bool>> filter, System.Linq.Expressions.Expression<Func<T, T>> updaeFile)
        {
            ExpressionVisitor<TB, Func<TB, bool>> vistor = new ExpressionVisitor<TB, Func<TB, bool>>();
            var f = vistor.Vsit(filter);

            ExpressionVisitor<TB, Func<TB, TB>> vistor1 = new ExpressionVisitor<TB, Func<TB, TB>>();
            var ff = vistor1.Vsit(updaeFile);

            return Set.Where(f).Update(ff);

        }

        public int Delete(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            ExpressionVisitor<TB, Func<TB, bool>> vistor = new ExpressionVisitor<TB, Func<TB, bool>>();
            var f = vistor.Vsit(filter);
            return Set.Delete(f);

        }

        public bool BeginTransaction(Action act)
        {
            var rst = false;
            using (var thac = privoder.Database.BeginTransaction())
            {
                try
                {
                    act();
                    rst = true;
                }
                catch (Exception e)
                {
                    thac.Rollback();
                }
                thac.Commit();
            }
            return rst;
        }


        public System.Data.Common.DbParameter CreateParameter(string key, object value)
        {
            var factory = System.Data.Entity.Core.Common.DbProviderServices.GetProviderFactory(this.privoder.Database.Connection);
            var parm = factory.CreateParameter();
            parm.ParameterName = key;
            parm.Value = value;
            return parm;
        }


        /// <summary>
        /// 执行SQL方法
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        protected IList<TEntity> RunSql<TEntity>(string sql, System.Collections.Generic.Dictionary<string, object> dict)
        {
            System.Data.Common.DbParameter[] parmList = null;
            var context = this.privoder.Database;
            if (dict != null && dict.Count > 0)
            {
                List<System.Data.Common.DbParameter> parmList1 = new List<System.Data.Common.DbParameter>();
                foreach (var key in dict)
                {
                    parmList1.Add(CreateParameter(key.Key, key.Value));
                }
                parmList = parmList1.ToArray();
            }
#if DEBUG
            Debug.WriteLine(sql);
#endif
            return context.SqlQuery<TEntity>(sql, parmList).ToList();
        }

        /// <summary>
        /// 执行SQL方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        protected int RunSqlCommand(string sql, System.Collections.Generic.Dictionary<string, object> dict)
        {
            System.Data.Common.DbParameter[] parmList = null;
            var context = this.privoder.Database;
            if (dict != null && dict.Count > 0)
            {
                List<System.Data.Common.DbParameter> parmList1 = new List<System.Data.Common.DbParameter>();
                foreach (var key in dict)
                {
                    parmList1.Add(CreateParameter(key.Key, key.Value));
                }
                parmList = parmList1.ToArray();
            }
#if DEBUG
            Debug.WriteLine(sql);
#endif
            return context.ExecuteSqlCommand(sql, parmList);
        }

        public int Save()
        {
            return privoder.SaveChanges();
        }


        protected IQueryable<TB> Include<N>(IQueryable<TB> query, System.Linq.Expressions.Expression<Func<TB, N>> cludPath)
        {
            return query.Include(cludPath);
        }

        public TElment LoadObject<TElment>(System.Linq.Expressions.Expression<Func<T, bool>> filter, System.Linq.Expressions.Expression<Func<T, TElment>> pref, string path)
            where TElment : class
        {
            ExpressionVisitor<TB, Func<TB, bool>> vistor = new ExpressionVisitor<TB, Func<TB, bool>>();
            var f = vistor.Vsit(filter);
            var entity = Set.Single(f);
            this.privoder.Entry(entity).Reference(path).Load();
            return pref.Compile()(To<T>(entity));
        }

        public System.Collections.Generic.ICollection<TElment> LoadCollen<TElment>(System.Linq.Expressions.Expression<Func<T, bool>> filter, System.Linq.Expressions.Expression<Func<T, System.Collections.Generic.ICollection<TElment>>> pref, string path)
            where TElment : class
        {
            ExpressionVisitor<TB, Func<TB, bool>> vistor = new ExpressionVisitor<TB, Func<TB, bool>>();
            var f = vistor.Vsit(filter);

            var entity = Set.Single(f);
            this.privoder.Entry(entity).Collection(path).Load();
            return pref.Compile()(To<T>(entity));
        }

        public int Count(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            ExpressionVisitor<TB, Func<TB, bool>> vistor = new ExpressionVisitor<TB, Func<TB, bool>>();
            var f = vistor.Vsit(filter);

            return Set.Where(f).Count();
        }
    }
}
