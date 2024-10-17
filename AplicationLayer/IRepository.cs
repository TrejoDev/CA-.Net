using EnterpriseLayer;

namespace AplicationLayer;
// ! 1-Define cómo interactúan las capas internas con el mundo exterior.
// ! 2-Oculta los detalles de implementación de las capas externas.
public interface IRepository<T>
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(Beer beer);
}
