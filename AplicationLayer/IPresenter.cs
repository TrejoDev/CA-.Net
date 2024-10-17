
namespace AplicationLayer;
// ! Presenters transform Entities to Output for Frontend or Views
public interface IPresenter<TEntity, TOutput>
{
    public IEnumerable<TOutput> Present(IEnumerable<TEntity> data);
}
