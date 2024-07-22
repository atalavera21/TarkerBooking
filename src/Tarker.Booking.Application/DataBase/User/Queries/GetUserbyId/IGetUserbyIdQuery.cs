﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.User.Queries.GetUserbyId
{
    public interface IGetUserbyIdQuery
    {
        Task<GetUserbyIdModel> Execute(int id);
    }
}
