
using Evento.API.Mapper;
using Evento.UseCases.Users.QueryGetUsers;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.DataAccessLogic;
using Repository.DataContext;
using Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EventoDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IDataRepositoryBase<>), typeof(DataRepositoryBase<>));
builder.Services.AddScoped(typeof(IDataRepository<>), typeof(DataRepository<>));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
//builder.Services.AddApplicationDependencies();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(GetUsersHandler).Assembly));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(UserProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EventoDBContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
