using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Profiles.Domain.Repositories;
using TecFinance_Backend.API.Profiles.Domain.Services;
using TecFinance_Backend.API.Profiles.Persistence.Repositories;
using TecFinance_Backend.API.Profiles.Services;
using TecFinance_Backend.API.Simulation.Domain.Repositories;
using TecFinance_Backend.API.Simulation.Domain.Services;
using TecFinance_Backend.API.Simulation.Persistence.Repositories;
using TecFinance_Backend.API.Simulation.Services;
using TecFinance_Backend.API.Shared.Domain.Repositories;
using TecFinance_Backend.API.Shared.Persistence.Contexts;
using TecFinance_Backend.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Lowercase URLs configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

// Shared Bounded Contexts Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learning Bounded Context Injection Configuration

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IBbpBasedOnHomeValueRepository, BbpBasedOnHomeValueRepository>();
builder.Services.AddScoped<IBbpBasedOnHomeValueService, BbpBasedOnHomeValueService>();
builder.Services.AddScoped<IInitialFeeBasedOnHomeValueRepository, InitialFeeBasedOnHomeValueRepository>();
builder.Services.AddScoped<IInitialFeeBasedOnHomeValueService, InitialFeeBasedOnHomeValueService>();
builder.Services.AddScoped<ITermForPaymentsRepository, TermForPaymentsRepository>();
builder.Services.AddScoped<ITermForPaymentsService, TermForPaymentsService>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(TecFinance_Backend.API.Simulation.Mapping.ModelToResourceProfile),
    typeof(TecFinance_Backend.API.Simulation.Mapping.ResourceToModelProfile),
    typeof(TecFinance_Backend.API.Profiles.Mapping.ModelToResourceProfile),
    typeof(TecFinance_Backend.API.Profiles.Mapping.ResourceToModelProfile));

// Application build

var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
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