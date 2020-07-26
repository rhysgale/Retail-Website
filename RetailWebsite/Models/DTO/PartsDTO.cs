using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class PartsDTO
    {
        public Guid PartId { get; set; }
        public string PartName { get; set; }
        public string PartImage { get; set; }

        //When we post back
        public int Quantity { get; set; }
    }
}
