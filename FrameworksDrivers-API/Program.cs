using AplicationLayer;
using EnterpriseLayer;
using FrameworksDrivers_API.Middlewares;
using InterfaceAdapter_Data;
using InterfaceAdapter_Mapper;
using InterfaceAdapter_Mapper.Dtos.Request;
using InterfaceAdapter_Present;
using InterfaceAdapter_Repository;
using Microsoft.EntityFrameworkCore;
using FrameworksDrivers_API.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using InterfaceAdapter_Adapter.Dtos;
using InterfaceAdapter_Adapter;
using FameworkDriver_ExternalService;

// ! Capa superior de detalles de la aplicación
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// * Validators
builder.Services.AddValidatorsFromAssemblyContaining<BeerValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// * Dependencies
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BreweryConnection"));
});

// * UseCases
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerViewModel>>();
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerDetailViewModel>>();
builder.Services.AddScoped<AddBeerUseCase<BeerRequestDTO>>();
builder.Services.AddScoped<GetPostUseCase>();

//* Implementaciones de interfaces  
builder.Services.AddScoped<IRepository<Beer>, Repository>();
builder.Services.AddScoped<IPresenter<Beer, BeerViewModel>, BeerPresenter>();
builder.Services.AddScoped<IPresenter<Beer, BeerDetailViewModel>, BeerDetailPresenter>();
builder.Services.AddScoped<IMapper<BeerRequestDTO, Beer>, BeerMapper>();
builder.Services.AddScoped<IExternalService<PostServiceDto>, PostService>();
builder.Services.AddScoped<IExternalServiceAdapter<Post>, PostExternalServiceAdapter>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// * Middlewares
app.UseMiddleware<ExceptionMiddleware>();

app.MapGet("/beer", async (GetBeerUseCase<Beer, BeerViewModel> beerUseCase) =>
{
    return await beerUseCase.ExecuteAsync();
})
.WithName("beers")
.WithOpenApi();

app.MapGet("/beerDetail", async (GetBeerUseCase<Beer, BeerDetailViewModel> beerUseCase) =>
{
    return await beerUseCase.ExecuteAsync();
})
.WithName("beersDetail")
.WithOpenApi();

app.MapPost("/beer", async (BeerRequestDTO beerRequestDTO,
    AddBeerUseCase<BeerRequestDTO> addBeerUseCase,
    IValidator<BeerRequestDTO> validator) =>
{
    var result = await validator.ValidateAsync(beerRequestDTO);

    if (!result.IsValid)
    {
        return Results.ValidationProblem(result.ToDictionary());
    }

    await addBeerUseCase.ExecuteAsync(beerRequestDTO);
    return Results.Created();
})
.WithName("addBeer")
.WithOpenApi();

app.MapGet("/post", async (GetPostUseCase postUseCase) =>
{
    return await postUseCase.ExecuteAsync();
})
.WithName("posts")
.WithOpenApi();


app.Run();


