using AutoMapper;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByDocumentNumber;
using Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByType;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserbyId;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User

            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserbyIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUsernameAndPasswordModel>().ReverseMap();

            #endregion

            #region Customer

            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllUserModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentModel>().ReverseMap();

            #endregion                 

            #region Booking
            
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            CreateMap<BookingEntity, GetAllBookingsModel>().ReverseMap();
            CreateMap<BookingEntity, GetBookingByDocumentNumberModel>().ReverseMap();
            CreateMap<BookingEntity, GetBookingByTypeModel>().ReverseMap();            

            #endregion

        }
    }
}
