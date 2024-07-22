﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IGetAllBookingsQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;   
        
        public GetAllBookingsQuery(IDataBaseService dataBaseService, IMapper mapper)
        {            
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }


        public async Task<List<GetAllBookingsModel>> Execute()
        {
            var result = await (from booking in _dataBaseService.Booking join
                                     customer in _dataBaseService.Customer on
                                     booking.CustomerId equals customer.CustomerId
                                     select new GetAllBookingsModel
                                     {
                                         BookingId = booking.BookingId,
                                         Code = booking.Code,
                                         RegisterDate = booking.RegisterDate,
                                         Type = booking.Type,
                                         CustomerFullName = customer.FullName,
                                         CustomerDocumentNumer = customer.DocumentNumber

                                     }).ToListAsync();
                                     

            return result;
        }

    }
}
