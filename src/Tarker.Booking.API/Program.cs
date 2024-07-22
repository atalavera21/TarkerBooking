using Microsoft.EntityFrameworkCore;
using Tarker.Booking.API;
using Tarker.Booking.Common;
using Tarker.Booking.Application;
using Tarker.Booking.Persistence;
using Tarker.Booking.External;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserbyId;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Domain.Enums;


var builder = WebApplication.CreateBuilder(args); 

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddAplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);
    

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


//app.MapPost("/testService-post", async (IDeleteUserCommand service) =>
//{
//    //    var model = new UpdateUserPasswordModel
//    //    {
//    //        UserId = 2,        
//    //        Password = "98765"
//    //    };


//    //return await service.Execute(3);
//    return await service.Execute(4);


//});


//Obtener todos los usuarios
//app.MapPost("/testService-get", async (IGetAllUserQuery service) =>
//{
//    return await service.Execute();
//});


//app.MapPost("/testService-post", async (IGetUserbyIdQuery service) =>
//{
//    return await service.Execute(2);
//});

//app.MapPost("/testService-post", async (IGetUserByUsernameAndPasswordQuery service) =>
//{
//    var model = new GetUserByUsernameAndPasswordModel
//    {
//       Username = "adriantlv",
//       Password = "123456"
//    };

//    return await service.Execute(model.Username, model.Password);
//});


//app.MapPost("/testService-post", async (ICreateCustomerCommand service) =>


//app.MapPost("/testService-post", async (IGetCustomerByDocumentQuery service) =>
//{    
//    return await service.Execute("9876543");
//});


//app.MapPost("/testService-post", async (ICreateBookingCommand service) =>
//{
//    var model = new CreateBookingModel
//    {
//        RegisterDate = DateTime.Now,
//        Code = Guid.NewGuid().ToString(),
//        Type =  BookingType.Documentation.ToString(),
//        CustomerId = 9,
//        UserId = 2
//    };

//    return await service.Execute(model);
//});



app.Run();

