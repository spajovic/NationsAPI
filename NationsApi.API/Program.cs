using NationsApi.API.Core;
using NationsApi.Application;
using NationsApi.Application.Commands.Continents;
using NationsApi.Application.Commands.Regions;
using NationsApi.Application.Commands.Roles;
using NationsApi.Application.Commands.Users;
using NationsApi.Application.Email;
using NationsApi.Application.Interfaces;
using NationsApi.Application.Mapper;
using NationsApi.Application.Queries.Continent;
using NationsApi.Application.Queries.Region;
using NationsApi.Application.Queries.Roles;
using NationsApi.Application.Queries.User;
using NationsApi.Application.Settings;
using NationsApi.DataAccess;
using NationsApi.Implementation.EfCommands.ContinentCommands;
using NationsApi.Implementation.EfCommands.RegionCommands;
using NationsApi.Implementation.EfCommands.RoleCommands;
using NationsApi.Implementation.EfCommands.UserCommands;
using NationsApi.Implementation.EfQueries.ContinentQueries;
using NationsApi.Implementation.EfQueries.RegionQueries;
using NationsApi.Implementation.EfQueries.RoleQueries;
using NationsApi.Implementation.EfQueries.UserQueries;
using NationsApi.Implementation.Email;
using NationsApi.Implementation.Logging;
using NationsApi.Implementation.Validators.Continent;
using NationsApi.Implementation.Validators.Region;
using NationsApi.Implementation.Validators.Role;
using NationsApi.Implementation.Validators.Users;

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
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
builder.Services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
builder.Services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();

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
