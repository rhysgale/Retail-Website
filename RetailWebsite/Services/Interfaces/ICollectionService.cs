using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICollectionService
    {
        IEnumerable<ProductDTO> GetCollection(Guid? categoryId);
    }
}
