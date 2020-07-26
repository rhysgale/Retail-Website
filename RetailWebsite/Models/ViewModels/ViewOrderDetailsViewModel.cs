using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class ViewOrderDetailsViewModel
    {
        public IEnumerable<DetailLineDTO> DetailLines { get; set; }
    }
}
