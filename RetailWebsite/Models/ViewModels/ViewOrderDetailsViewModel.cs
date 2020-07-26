using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class ViewOrderDetailsViewModel
    {
        public IEnumerable<DetailLineDTO> DetailLines { get; set; }

        public Guid OrderReference { get; set; }

        public string Email { get; set; }
    }
}
