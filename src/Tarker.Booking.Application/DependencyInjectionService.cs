using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Configuration;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByDocumentNumber;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByType;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.DeleteUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserbyId;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword;

namespace Tarker.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            services.AddSingleton(mapper.CreateMapper());

            #region Users
            //Commands
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordDCommand>();

            //Querys
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserbyIdQuery, GetUserbyIdQuery>();
            services.AddTransient<IGetUserByUsernameAndPasswordQuery, GetUserByUsernameAndPasswordQuery>();
            #endregion


            #region Customers
            //Commands
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();

            //Querys
            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddTransient<IGetCustomerByDocumentQuery, GetCustomerByDocumentQuery>();
            #endregion



            #region Bookings
            //Commands
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            
            
            //Querys
            services.AddTransient<IGetAllBookingsQuery, GetAllBookingsQuery>();
            services.AddTransient<IGetBookingByDocumentNumberQuery, GetBookingByDocumentNumberQuery>();
            services.AddTransient<IGetBookingByTypeQuery, GetBookingByTypeQuery>();

            #endregion




            return services;
        }
    }
}
