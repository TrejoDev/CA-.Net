using AplicationLayer;
using EnterpriseLayer;
using InterfaceAdapter_Adapter.Dtos;

namespace InterfaceAdapter_Adapter;

public class PostExternalServiceAdapter : IExternalServiceAdapter<Post>
{
    private readonly IExternalService<PostServiceDto> _externalService;

    public PostExternalServiceAdapter(IExternalService<PostServiceDto> externalService)
    {
        _externalService = externalService;
    }

    public async Task<IEnumerable<Post>> GetDataAsync()
    {
        var postES = await _externalService.GetContentAsync();
        var post = postES.Select(p => new Post
        {
            Id = p.Id,
            Title = p.Title,
            Body = p.Body
        });
        return post;
    }
}
