using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByDocumentNumber
{
    public class GetBookingByDocumentNumberQuery : IGetBookingByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;   
        
        public GetBookingByDocumentNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {            
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }


        public async Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber)
        {
            var lstEntity = await (from booking in _dataBaseService.Booking join
                                        customer in _dataBaseService.Customer on
                                        booking.CustomerId equals customer.CustomerId
                                        where customer.DocumentNumber == documentNumber
                                    select new GetBookingByDocumentNumberModel
                                    {
                                        Code = booking.Code,
                                        RegisterDate = booking.RegisterDate,
                                        Type = booking.Type
                                    }).ToListAsync();


            return lstEntity;
        }

    }
}
