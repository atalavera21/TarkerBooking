using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword
{
    public class GetUserByUsernameAndPasswordQuery : IGetUserByUsernameAndPasswordQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        //Inicializame las clases privadas en un constructor    
        public GetUserByUsernameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        
        public async Task<GetUserByUsernameAndPasswordModel> Execute(string username, string password)
        {
            //Obtengo el primer usuario que coincide con la condición
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

            //Retorna el usuario que obtuviste convertido al -> "GetUserByUsernameAndPasswordModel"
            return _mapper.Map<GetUserByUsernameAndPasswordModel>(entity);
        }

    }
}
