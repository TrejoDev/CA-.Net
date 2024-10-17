using EnterpriseLayer;

namespace AplicationLayer;
// !1-Contiene la lógica que define cómo se utilizan las entidades para realizar tareas específicas.
// !2- La interacción entre entidades y otros componentes.
public class GetBeerUseCase<TEntity, TOutput>
{
    private readonly IRepository<TEntity> _repository;
    private readonly IPresenter<TEntity, TOutput> _presenter;

    public GetBeerUseCase(IRepository<TEntity> repository, IPresenter<TEntity, TOutput> presenter)
    {
        _repository = repository;
        _presenter = presenter;
    }

    public async Task<IEnumerable<TOutput>> ExecuteAsync()
    {
        var beers = await _repository.GetAllAsync();
        return _presenter.Present(beers);
    }
}
