using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBase.Bookings.Queries.GetBookingByType
{
    public  class GetBookingByTypeModel
    {
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerDocumentNumber { get; set; }
    }
}
