using Ims.Application.Customers;
using Ims.Application.Customers.Commands;
using Ims.Application.Interfaces;
using Ims.Infra;
using Ims.Infra.Customers;
using Ims.Infra.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>();
});

builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    var currentUser = sp.GetRequiredService<ICurrentUser>();
    var currentTenant = sp.GetRequiredService<ICurrentTenant>();
    
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICurrentUser, CurrentUserService>();
builder.Services.AddScoped<ICurrentTenant, CurrentTenantService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //db.Database.EnsureCreated();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
