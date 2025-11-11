using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Order
    {
        [DisplayName("Номер заказа")]
        public int OrderId { get; set; }
        [DisplayName("Номер столика")]
        public int SeatId { get; set; }
        public List<OrderItem> Items { get; set; }
        [DisplayName("Блюда")]
        public string ItemsString { get; set; }
        [DisplayName("Счет")]
        public decimal TotalPrice { get; set; }
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
    }
}
