using System;
using AplicationLayer;
using EnterpriseLayer;

namespace InterfaceAdapter_Present;

public class BeerPresenter : IPresenter<Beer, BeerViewModel>
{
    public IEnumerable<BeerViewModel> Present(IEnumerable<Beer> beers)
    {
        return beers.Select(b => new BeerViewModel
        {
            Id = b.Id,
            Name = b.Name,
            Alcohol = b.Alcohol + "%"
        });
    }
}
