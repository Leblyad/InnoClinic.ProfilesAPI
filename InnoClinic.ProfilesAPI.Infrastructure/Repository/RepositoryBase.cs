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

        //FirstName,LastName
        //Кирилл,Лебедев
        public IQueryable<T> GetByManyParameters(QueryStringParameters parameters)
        {
            int i = 0;
            var itemsQuery = FindAll(trackChanges: false);
            var nameArray = parameters.PropertyName.Split(',');
            var valueArray = parameters.PropertyValue.Split(',');

            if (nameArray.Length == valueArray.Length)
            {
                while (nameArray.Length > i)
                {
                    itemsQuery = FilterData(itemsQuery, nameArray[i], valueArray[i]);
                    i++;
                }
            }

            return itemsQuery;
        }

        public IQueryable<T> FilterData(IQueryable<T> queryableData, string PropertyName, string PropertyValue)
        {
            PropertyInfo propInfo = typeof(T).GetProperty(PropertyName);
            ParameterExpression pe = Expression.Parameter(typeof(T), PropertyName);
            Expression left = Expression.Property(pe, propInfo);
            Expression right = Expression.Constant(PropertyValue, propInfo.PropertyType);
            Expression predicateBody = Expression.Equal(left, right);

            MethodCallExpression whereCallExpression = Expression.Call(
                                typeof(Queryable),
                                "Where",
                                new Type[] { queryableData.ElementType },
                                queryableData.Expression,
                                Expression.Lambda<Func<T, bool>>(predicateBody, new ParameterExpression[] { pe }));

            return queryableData.Provider.CreateQuery<T>(whereCallExpression).Cast<T>();
        }
    }
}
