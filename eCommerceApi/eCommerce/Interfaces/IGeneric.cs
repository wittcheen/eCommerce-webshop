namespace eCommerce.Interfaces
{
    public interface IGeneric<TEntity, TCreate, TUpdate>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TCreate input);
        Task<bool> UpdateAsync(int id, TUpdate input);
        Task<bool> DeleteAsync(int id);
    }
}
