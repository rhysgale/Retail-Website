using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class ViewDetailsRequest
    {
        public Guid OrderReference { get; set; }

        public string EmailAddress { get; set; }
    }
}
