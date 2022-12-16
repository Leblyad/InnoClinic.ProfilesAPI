using InnoClinic.ProfilesAPI.Core.Contracts.Repositories;
using InnoClinic.ProfilesAPI.Core.Entities.QueryParameters;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace InnoClinic.ProfilesAPI.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            RepositoryContext.Set<T>() :
            RepositoryContext.Set<T>()
            .AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            trackChanges ?
            RepositoryContext.Set<T>()
            .Where(expression) :
            RepositoryContext.Set<T>()
            .Where(expression)
            .AsNoTracking();

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public IQueryable<T> GetByParameters(QueryStringParameters parameters)
        {
            IQueryable<T> queryableData = FindAll(trackChanges: false);

            PropertyInfo propInfo = typeof(T).GetProperty(parameters.PropertyName);
            ParameterExpression pe = Expression.Parameter(typeof(T), parameters.PropertyName);
            Expression left = Expression.Property(pe, propInfo);
            Expression right = Expression.Constant(parameters.PropertyValue, propInfo.PropertyType);
            Expression predicateBody = Expression.Equal(left, right);

            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { queryableData.ElementType },
                queryableData.Expression,
                Expression.Lambda<Func<T, bool>>(predicateBody, new ParameterExpression[] { pe }));

            return queryableData.Provider.CreateQuery<T>(whereCallExpression).Cast<T>();
        }

        //public IQueryable<T> GetByParameters(QueryStringParameters parameters, IQueryable<T> queryableData)
        //{
        //    int i = 1;
        //    while (parameters.FieldsForFilterBy >= i)
        //    {
        //        PropertyInfo propInfo = typeof(T).GetProperty(parameters.PropertyName[i]);
        //        ParameterExpression pe = Expression.Parameter(typeof(T), parameters.PropertyName[i]);
        //        Expression left = Expression.Property(pe, propInfo);
        //        Expression right = Expression.Constant(parameters.PropertyValue, propInfo.PropertyType);
        //        Expression predicateBody = Expression.Equal(left, right);

        //        MethodCallExpression whereCallExpression = Expression.Call(
        //            typeof(Queryable),
        //            "Where",
        //            new Type[] { queryableData.ElementType },
        //            queryableData.Expression,
        //            Expression.Lambda<Func<T, bool>>(predicateBody, new ParameterExpression[] { pe }));

        //        queryableData = queryableData.Provider.CreateQuery<T>(whereCallExpression).Cast<T>();
        //    }

        //    return queryableData;
        //}
    }
}
