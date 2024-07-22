﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByType
{
    public class GetBookingByTypeQuery : IGetBookingByTypeQuery
    {
        private readonly IDataBaseService _dataBaseService; 
        
        public GetBookingByTypeQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;           
        }

        public async Task<List<GetBookingByTypeModel>> Execute(string type)
        {
            var result = await (from booking in _dataBaseService.Booking join
                                customer in _dataBaseService.Customer on
                                booking.CustomerId equals customer.CustomerId
                                where booking.Type == type                               
                                select new GetBookingByTypeModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber
                                }).ToListAsync();

            return result;            
        }


    }
}
