using System;

namespace InterfaceAdapter_Adapter.Dtos;

public interface IExternalService<T>
{
    public Task<IEnumerable<T>> GetContentAsync();
}
