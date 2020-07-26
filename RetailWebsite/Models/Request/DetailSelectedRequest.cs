using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class DetailSelectedRequest
    {
        public Guid OrderReference { get; set; }

        public Guid ProductId { get; set; }

        public string EmailAddress { get; set; }
    }
}
