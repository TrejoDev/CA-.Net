using AplicationLayer;
using EnterpriseLayer;
using InterfaceAdapter_Mapper.Dtos.Request;

namespace InterfaceAdapter_Mapper;

public class BeerMapper : IMapper<BeerRequestDTO, Beer>
{
    public Beer ToEntity(BeerRequestDTO dto)
        => new Beer()
        {
            Id = dto.Id,
            Name = dto.Name,
            Style = dto.Style,
            Alcohol = dto.Alcohol
        };
}
