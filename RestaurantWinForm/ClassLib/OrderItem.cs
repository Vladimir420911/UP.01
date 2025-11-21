using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class OrderItem
    {
        private int MenuItemId;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description{ get; set; }
        public OrderItem(int menuItemId, string name, decimal price, string description)
        {
            MenuItemId = menuItemId;
            Name = name;
            Price = price;
             Description = description;
        }
    }
}
