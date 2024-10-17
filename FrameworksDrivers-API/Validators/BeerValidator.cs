using System;
using System.Net.NetworkInformation;
using FluentValidation;
using InterfaceAdapter_Mapper.Dtos.Request;

namespace FrameworksDrivers_API.Validators;

public class BeerValidator : AbstractValidator<BeerRequestDTO>
{
    public BeerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Style).NotEmpty().WithMessage("Style is required");
        RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage("Alcohol is required");
    }
}
