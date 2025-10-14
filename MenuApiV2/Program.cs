using MenuApiV2.Data;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<FoodAppDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    

builder.Services.AddScoped<ICookRepository, CookRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDeliveryCyclistRepository, DeliveryCyclistRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FoodAppDbContext>();
    FoodAppDbSeeder.Seed(context);
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// }
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();


app.Run();


