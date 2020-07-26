using Models.DTO;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPartOrderingService
    {
        IEnumerable<DetailLineDTO> GetOrderDetails(Guid orderId, string email);

        IEnumerable<PartsDTO> GetPartsForDetail(DetailSelectedRequest request);
    }
}
