using System;
using AplicationLayer;
using EnterpriseLayer;

namespace InterfaceAdapter_Present;

public class BeerDetailPresenter : IPresenter<Beer, BeerDetailViewModel>
{
    public IEnumerable<BeerDetailViewModel> Present(IEnumerable<Beer> beers)
        => beers.Select(b => new BeerDetailViewModel
        {
            Id = b.Id,
            Name = b.Name,
            Style = b.Style,
            Alcohol = b.Alcohol + "%",
            Color = b.IsStrogBeer() ? "Red" : "Green",
            Message = b.IsStrogBeer() ? "Strog beer" : "Not strog beer",
        });
}

