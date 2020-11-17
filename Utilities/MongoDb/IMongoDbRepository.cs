using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Utilities.MongoDb
{
    public interface IMongoRepository<T> where T : IDocument
    {
        IQueryable<T> AsQueryable();

        IEnumerable<T> FilterBy(
            Expression<Func<T, bool>> filterExpression);

        IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, TProjected>> projectionExpression);

        Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);

        Task<T> FindByIdAsync(string id);

        Task InsertOneAsync(T document);

        Task InsertManyAsync(ICollection<T> documents);

        Task ReplaceOneAsync(T document);

        Task DeleteOneAsync(Expression<Func<T, bool>> filterExpression);

        Task DeleteByIdAsync(string id);

        Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression);
    }
}
