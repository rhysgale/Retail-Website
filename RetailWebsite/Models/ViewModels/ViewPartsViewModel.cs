using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class ViewPartsViewModel
    {
        public Guid OrderId { get; set; }
        public string EmailAddress { get; set; }
        public Guid ProductId { get; set; }

        public IEnumerable<PartsDTO> Parts { get; set; }
    }
}
