using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Persistence.Database;


var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddDbContext<DataBaseService>(options => 
                                               options.UseSqlServer(builder.Configuration["SQLConnectionString"]));


builder.Services.AddScoped<IDataBaseService, DataBaseService>();

var app = builder.Build();








// Ejemplo de Minimal API ----------------------------------------------

//// Test EndPoint (create a user)
//app.MapPost("/createTest", async (IDataBaseService _dataService) =>
//{
//    var entity = new Tarker.Booking.Domain.Entities.User.UserEntity
//    {
//        FirstName = "Adrián",
//        LastName = "Talavera",
//        Username = "adriantlv",
//        Password = "123456"
//    };

//    await _dataService.User.AddAsync(entity);
//    await _dataService.SaveAsync(); 

//    return Results.Ok(entity);
//});


//// Test EndPoint (get all users)
//app.MapGet("/getAllUsers", async (IDataBaseService _dataService) =>
//{
//    var users = await _dataService.User.ToListAsync();
//    return Results.Ok(users);
//});

// ----------------------------------------------------------------------


app.Run();

