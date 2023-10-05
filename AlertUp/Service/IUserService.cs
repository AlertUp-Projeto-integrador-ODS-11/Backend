using AlertUp.Model;

namespace AlertUp.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User?> GetById(long id);

        Task<User?> GetByUsuario(string usuario);

        Task<User?> Create(User usuario);

        Task<User?> Update(User usuario);
    }
}
