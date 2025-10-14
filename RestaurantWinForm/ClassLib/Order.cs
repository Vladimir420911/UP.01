using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Order
    {
        public int OrderId { get; set; } //Id заказа
        public int SeatId { get; set; } //Id столика
        public List<OrderItem> Items { get; set; } //список блюд
        public decimal TotalPrice { get; set; } //цена
        public string Status { get; set; } //статус
    }
}
