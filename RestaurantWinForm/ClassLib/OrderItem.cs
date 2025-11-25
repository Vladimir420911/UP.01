using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class OrderItem
    {
        private int MenuItemId;
        public int ID_ { get { return MenuItemId; } }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
       
        public OrderItem(int menuItemId, string name, decimal price, string description)
        {
            MenuItemId = menuItemId;
            Name = name;
            Price = price;
             Description = description;
        }
    }
}
