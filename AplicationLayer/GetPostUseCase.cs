using System;
using EnterpriseLayer;

namespace AplicationLayer;

public class GetPostUseCase
{
    private readonly IExternalServiceAdapter<Post> _adapter;

    public GetPostUseCase(IExternalServiceAdapter<Post> adapter)
    {
        _adapter = adapter;
    }

    public async Task<IEnumerable<Post>> ExecuteAsync() => await _adapter.GetDataAsync();
}
