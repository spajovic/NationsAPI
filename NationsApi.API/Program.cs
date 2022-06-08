using NationsApi.API.Core;
using NationsApi.Application;
using NationsApi.Application.Commands.Continents;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Mapper;
using NationsApi.Application.Queries.Continent;
using NationsApi.DataAccess;
using NationsApi.Implementation.EfCommands.ContinentCommands;
using NationsApi.Implementation.EfQueries.ContinentQueries;
using NationsApi.Implementation.Logging;
using NationsApi.Implementation.Validators.Continent;

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
