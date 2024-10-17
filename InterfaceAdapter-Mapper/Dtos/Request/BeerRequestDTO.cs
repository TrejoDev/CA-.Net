using System;

namespace InterfaceAdapter_Mapper.Dtos.Request;

public class BeerRequestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Style { get; set; }
    public decimal Alcohol { get; set; }
}
