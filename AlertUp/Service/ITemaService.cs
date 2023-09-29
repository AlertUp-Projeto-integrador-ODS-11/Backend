using AlertUp.Model;

namespace AlertUp.Service;

public interface ITemaService
{
    Task<IEnumerable<Tema>> GetAll();
    
    Task<Tema?> GetById(long id);
    
    Task<IEnumerable<Tema>> GetByDescricao(string descricao);
    
    Task<Tema?> Create(Tema tema);
    
    Task<Tema?> Update(Tema tema);
    
    Task Delete(Tema tema);
}