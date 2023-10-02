using AlertUp.Model;

namespace AlertUp.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User?> GetById(long id);

        Task<User?> Create(User user);

        Task<User?> Update(User user);

        Task Delete(User user);
    }
}
