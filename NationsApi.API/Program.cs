using AutoMapper;
using NationsApi.API.Core;
using NationsApi.Application;
using NationsApi.Application.Commands.Continents;
using NationsApi.Application.Commands.Countries;
using NationsApi.Application.Commands.CountryFlags;
using NationsApi.Application.Commands.CountryStats;
using NationsApi.Application.Commands.Languages;
using NationsApi.Application.Commands.Regions;
using NationsApi.Application.Commands.RoleCase;
using NationsApi.Application.Commands.Roles;
using NationsApi.Application.Commands.Users;
using NationsApi.Application.Email;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Mapper;
using NationsApi.Application.Queries.Continent;
using NationsApi.Application.Queries.Countries;
using NationsApi.Application.Queries.CountryStat;
using NationsApi.Application.Queries.Language;
using NationsApi.Application.Queries.Region;
using NationsApi.Application.Queries.Roles;
using NationsApi.Application.Queries.UseCaseLog;
using NationsApi.Application.Queries.User;
using NationsApi.Application.Settings;
using NationsApi.DataAccess;
using NationsApi.Implementation.EfCommands.ContinentCommands;
using NationsApi.Implementation.EfCommands.CountryCommands;
using NationsApi.Implementation.EfCommands.CountryFlagCommands;
using NationsApi.Implementation.EfCommands.CountryStatCommands;
using NationsApi.Implementation.EfCommands.LanguageCommands;
using NationsApi.Implementation.EfCommands.RegionCommands;
using NationsApi.Implementation.EfCommands.RoleCaseCommands;
using NationsApi.Implementation.EfCommands.RoleCommands;
using NationsApi.Implementation.EfCommands.UserCommands;
using NationsApi.Implementation.EfQueries.ContinentQueries;
using NationsApi.Implementation.EfQueries.CountryQueries;
using NationsApi.Implementation.EfQueries.CountryStatQueries;
using NationsApi.Implementation.EfQueries.LanguageQueries;
using NationsApi.Implementation.EfQueries.RegionQueries;
using NationsApi.Implementation.EfQueries.RoleQueries;
using NationsApi.Implementation.EfQueries.UseCaseLogQueries;
using NationsApi.Implementation.EfQueries.UserQueries;
using NationsApi.Implementation.Email;
using NationsApi.Implementation.Logging;
using NationsApi.Implementation.Validators.Continent;
using NationsApi.Implementation.Validators.Country;
using NationsApi.Implementation.Validators.CountryFlag;
using NationsApi.Implementation.Validators.CountryStat;
using NationsApi.Implementation.Validators.Language;
using NationsApi.Implementation.Validators.Region;
using NationsApi.Implementation.Validators.Role;
using NationsApi.Implementation.Validators.RoleCase;
using NationsApi.Implementation.Validators.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database Context
builder.Services.AddDbContext<NationsContext>();

// Cika Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Actor
builder.Services.AddTransient<IAppActor, FakeApiActor>();

// Logger
builder.Services.AddTransient<IUseCaseLogger, DbUseCaseLogger>();

// Mapper
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped(provider => new MapperConfiguration(config =>
{
    config.AddProfile(new MapperProfile(provider.GetService<NationsContext>()));
}).CreateMapper());

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

//Roles
builder.Services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
builder.Services.AddTransient<AddRoleValidator>();
builder.Services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
builder.Services.AddTransient<UpdateRoleValidator>();
builder.Services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
builder.Services.AddTransient<IGetOneRoleQuery, EfGetOneRoleQuery>();
builder.Services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();

// mail sending
builder.Services.AddTransient<IEmailSender, SMTPEmailSender>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

//Users
builder.Services.AddTransient<IAddUserCommand, EfAddUserCommand>();
builder.Services.AddTransient<AddUserValidator>();
builder.Services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
builder.Services.AddTransient<UpdateUserValidator>();
builder.Services.AddTransient<IDeleteCountryCommand, EfDeleteCountryCommand>();
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
builder.Services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
builder.Services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();

//Countries
builder.Services.AddTransient<IAddCountryCommand, EfAddCountryCommand>();
builder.Services.AddTransient<AddCountryValidator>();
builder.Services.AddTransient<IUpdateCountryCommand, EfUpdateCountryCommand>();
builder.Services.AddTransient<UpdateCountryValidator>();
builder.Services.AddTransient<IGetOneCountryQuery, EfGetOneCountryQuery>();
builder.Services.AddTransient<IGetCountriesQuery, EfGetCountriesQuery>();

//Language
builder.Services.AddTransient<IAddLanguageCommand, EfAddLanguageCommand>();
builder.Services.AddTransient<LanguageValidator>();
builder.Services.AddTransient<IUpdateLanguageCommand, EfUpdateLanguageCommand>();
builder.Services.AddTransient<UpdateLanguageValidator>();
builder.Services.AddTransient<IDeleteLanguageCommand, EfDeleteLanguageCommand>();
builder.Services.AddTransient<IGetOneLanguageQuery, EfGetOneLanguageQuery>();
builder.Services.AddTransient<IGetLanguagesQuery, EfGetLanguagesQuery>();

//Country Stat
builder.Services.AddTransient<IAddCountryStatCommand, EfAddCountryStatCommand>();
builder.Services.AddTransient<AddCountryStatValidator>();
builder.Services.AddTransient<IUpdateCountryStatCommand, EfUpdateCountryStatCommand>();
builder.Services.AddTransient<UpdateCountryStatValidator>();
builder.Services.AddTransient<IDeleteCountryStatCommand, EfDeleteCountryStatCommand>();
builder.Services.AddTransient<RemoveCountryStatValidator>();
builder.Services.AddTransient<IGetOneCountryStatQuery, EfGetOneCountryStatQuery>();
builder.Services.AddTransient<IGetCountryStatsQuery, EfGetCountryStatsQuery>();

//UseCaseLogs
builder.Services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();

//Role UseCase
builder.Services.AddTransient<IAddRoleUseCaseCommand, EfAddRoleUseCaseCommand>();
builder.Services.AddTransient<AddRoleUseCaseValidator>();
builder.Services.AddTransient<IDeleteRoleUseCaseCommand, EfDeleteRoleUseCaseCommand>();
builder.Services.AddTransient<DeleteRoleUseCaseValidator>();

//Country Flag
builder.Services.AddTransient<IAddCountryFlagCommand, EfAddCountryFlagCommand>();
builder.Services.AddTransient<AddCountryFlagValidator>();
builder.Services.AddTransient<IUpdateCountryFlagCommand, EfUpdateCountryFlagCommand>();
builder.Services.AddTransient<UpdateCountryFlagValidator>();
builder.Services.AddTransient<IDeleteCountryFlagCommand, EfDeleteCountryFlagCommand>();
builder.Services.AddTransient<DeleteCountryFlagValidator>();

var app = builder.Build();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger(x => x.SerializeAsV2 = true);

app.UseAuthorization();

app.MapControllers();

app.Run();
