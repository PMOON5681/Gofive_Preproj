using UserManage.API.Models.Domain;

namespace UserManage.API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User?> GetById(Guid id);

        Task<User?> UpdateAsync(User user);

        Task<User?> DeleteAsync(Guid id);
    }
}
