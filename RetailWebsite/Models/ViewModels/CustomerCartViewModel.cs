using Models.DTO;
using System.Collections.Generic;

namespace Models.ViewModels
{
    public class CustomerCartViewModel
    {
        public IEnumerable<DetailLineDTO> DetailLines { get; set; }
    }
}
