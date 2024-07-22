using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService _dataBaseService;


        public DeleteUserCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<bool> Execute(int userId)
        {

            try
            {
                var entity = await _dataBaseService.User.FirstOrDefaultAsync(x => x.UserId == userId);
                if (entity == null)
                    return false;

                _dataBaseService.User.Remove(entity);
                return await _dataBaseService.SaveAsync();
            }
            catch (TaskCanceledException ex)
            {
                // Log the exception
                Console.WriteLine($"La tarea fue cancelada: {ex.Message}");
                // Puedes intentar reconectar a la base de datos aquí si es necesario
                return false;
            }
            catch (Exception ex)
            {
                // Log other exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
