using NationsApi.API.Core;
using NationsApi.Application;
using NationsApi.Application.Commands.Continents;
using NationsApi.Application.Commands.Regions;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Mapper;
using NationsApi.Application.Queries.Continent;
using NationsApi.Application.Queries.Region;
using NationsApi.DataAccess;
using NationsApi.Implementation.EfCommands.ContinentCommands;
using NationsApi.Implementation.EfCommands.RegionCommands;
using NationsApi.Implementation.EfQueries.ContinentQueries;
using NationsApi.Implementation.EfQueries.RegionQueries;
using NationsApi.Implementation.Logging;
using NationsApi.Implementation.Validators.Continent;
using NationsApi.Implementation.Validators.Region;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Context
builder.Services.AddDbContext<NationsContext>();

// Actor
builder.Services.AddTransient<IAppActor, FakeApiActor>();

// Logger
builder.Services.AddTransient<IUseCaseLogger, DbUseCaseLogger>();

// Mapper
builder.Services.AddAutoMapper(typeof(MapperProfile));

// Use case executor
builder.Services.AddTransient<UseCaseExecutor>();

// Continent
builder.Services.AddTransient<IAddContinentCommand, EfAddContinentCommand>();
builder.Services.AddTransient<AddContinentValidator>();
builder.Services.AddTransient<IUpdateContinentCommand, EfUpdateContinentCommand>();
builder.Services.AddTransient<UpdateContinentValidator>();
builder.Services.AddTransient<IDeleteContinentCommand, EfDeleteContinentCommand>();
builder.Services.AddTransient<IGetOneContinentQuery, EfGetOneContinentQuery>();
builder.Services.AddTransient<IGetContinentsQuery, EfGetContinentsQuery>();

// Regions
builder.Services.AddTransient<IAddRegionCommand, EfAddRegionCommand>();
builder.Services.AddTransient<AddRegionValidator>();
builder.Services.AddTransient<IUpdateRegionCommand, EfUpdateRegionCommand>();
builder.Services.AddTransient<UpdateRegionValidator>();
builder.Services.AddTransient<IDeleteRegionCommand, EfDeleteRegionCommand>();
builder.Services.AddTransient<IGetOneRegionQuery, EfGetOneRegionQuery>();
builder.Services.AddTransient<IGetRegionsQuery, EfGetRegionsQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
