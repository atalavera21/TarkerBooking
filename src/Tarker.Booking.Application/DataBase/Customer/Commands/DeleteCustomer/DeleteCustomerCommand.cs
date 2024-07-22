using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {

        private readonly IDataBaseService _dataBaseService;

        public DeleteCustomerCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }


        public async Task<bool> Execute(int CustomerId)
        {
            try
            {
                var entity = await _dataBaseService.Customer.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
                if (entity == null)
                    return false;

                _dataBaseService.Customer.Remove(entity);

                return await _dataBaseService.SaveAsync();
            }
            catch (Exception ex)
            {
                // Generame un codigo para capturar la excepcion
                Console.WriteLine($"Error al eliminar el cliente: {ex.Message}"); 
                return false;
            }
        }                     
    }
}
