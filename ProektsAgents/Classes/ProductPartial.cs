using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektsAgents.Classes
{
    public partial class Agent
    {
        public string SoldProductCount
        {
            get
            {
                int count = 0;
                foreach (ProductSale product in ProductSale)
                    if (product.SaleDate >= DateTime.Now.AddYears(-1))
                        count += product.ProductCount;
                return count + " продаж за год";
            }
        }
    }
}
