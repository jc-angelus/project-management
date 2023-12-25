using System.Linq.Expressions;

namespace ProjectManagementInfrastructure.Repositories.Interfaces.Generic
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 12/23/2023
    /// Interface: IGenericRepository
    /// </summary
    public interface IGenericRepository<T> where T : class
    {        
        Task<T> CreateAsync(T entity);
        Task<T> ReadAsync(int id);
        T? ReadByConditionAsync(Expression<Func<T, bool>> whereCondition = null);
        Task<T> UpdateAsync(T entity, object key);
        Task<bool> DeleteAsync(object key);
        Task<IEnumerable<T>> ListAsync();
    }


}
