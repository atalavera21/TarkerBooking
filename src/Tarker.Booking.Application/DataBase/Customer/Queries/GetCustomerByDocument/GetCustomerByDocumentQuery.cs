using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument
{
    public class GetCustomerByDocumentQuery : IGetCustomerByDocumentQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByDocumentQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByDocumentModel> Execute(string documentNumber)
        {
            var entity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber);
            return _mapper.Map<GetCustomerByDocumentModel>(entity);
        }

    }
}
