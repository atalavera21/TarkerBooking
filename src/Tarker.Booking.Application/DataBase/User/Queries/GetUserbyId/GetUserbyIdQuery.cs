using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserbyId
{
    public class GetUserbyIdQuery : IGetUserbyIdQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;


        
        public GetUserbyIdQuery(IDataBaseService dataBaseService, IMapper mapper)
        {           
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserbyIdModel> Execute(int userId)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return _mapper.Map<GetUserbyIdModel>(entity);            
        }
    }
}
