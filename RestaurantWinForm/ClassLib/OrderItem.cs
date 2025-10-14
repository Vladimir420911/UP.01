using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class OrderItem
    {
        public int MenuItemId { get; set; } // id блюда
        public string Name { get; set; } //наименование
        public decimal Price { get; set; } //цена
        public int Quantity { get; set; } //количество
    }
}
