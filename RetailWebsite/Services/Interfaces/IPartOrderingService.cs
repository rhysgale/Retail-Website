﻿using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPartOrderingService
    {
        IEnumerable<DetailLineDTO> GetOrderDetails(Guid orderId, string email);
    }
}
