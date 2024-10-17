using System;

namespace AplicationLayer;

public interface IExternalServiceAdapter<T>
{
    Task<IEnumerable<T>> GetDataAsync();
}
