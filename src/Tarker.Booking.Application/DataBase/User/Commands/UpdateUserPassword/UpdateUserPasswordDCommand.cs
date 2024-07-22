using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordDCommand : IUpdateUserPasswordCommand
    {
        private readonly IDataBaseService _dataBaseService;


        public UpdateUserPasswordDCommand(IDataBaseService dataBaseService)
        {
           _dataBaseService = dataBaseService;
        }



        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync(x=>x.UserId == model.UserId);

            if (entity == null)
                return false;
            
            entity.Password = model.Password;
            return await _dataBaseService.SaveAsync();
        }

    }
}
