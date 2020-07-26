using Models.DTO;
using System.Collections.Generic;

namespace Models.ViewModels
{
    public class CustomerCartViewModel
    {
        public IEnumerable<DetailLineDTO> DetailLines { get; set; }
        public decimal TotalCost
        {
            get
            {
                decimal price = 0;
                foreach (var line in DetailLines)
                {
                    price = price + line.LineTotalCost;
                }
                return price;
            }
        }

        public int ItemsInCart
        {
            get
            {
                int number = 0;
                foreach (var line in DetailLines)
                    number = number + line.Quantity;
                return number;
            }
        }
    }
}
