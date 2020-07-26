using System.Collections.Generic;

namespace Models.DTO
{
    public class CustomerCartDTO
    {
        public IEnumerable<DetailLineDTO> DetailLines { get; set; }
    }
}
