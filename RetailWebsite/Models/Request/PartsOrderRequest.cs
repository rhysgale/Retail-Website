using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class PartsOrderRequest
    {
        public IEnumerable<PartsDTO> Parts { get; set; }
        public string Email { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}
