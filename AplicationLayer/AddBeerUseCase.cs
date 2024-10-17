using System;
using AplicationLayer.Exceptions;
using EnterpriseLayer;

namespace AplicationLayer;
// !1-Contiene la lógica que define cómo se utilizan las entidades para realizar tareas específicas.
// !2- La interacción entre entidades y otros componentes.
public class AddBeerUseCase<TDTO>
{
    private readonly IRepository<Beer> _repository;
    private readonly IMapper<TDTO, Beer> _mapper;

    public AddBeerUseCase(IRepository<Beer> repository, IMapper<TDTO, Beer> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task ExecuteAsync(TDTO beerDTO)
    {
        var beer = _mapper.ToEntity(beerDTO);

        if (string.IsNullOrEmpty(beer.Name)) throw new ValidationException("Name is required");

        await _repository.AddAsync(beer);
    }
}
