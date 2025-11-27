using ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiptControl
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void UpdateOrderInfo(Order order)
        {
            if (order != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"=== ЧЕК ===");
                sb.AppendLine($"Заказ #{order.OrderId}");
                sb.AppendLine($"Место: {order.SeatId}");
                sb.AppendLine($"Статус: {order.Status}");
                sb.AppendLine("----------------------------");
                sb.AppendLine("Позиции:");

                if (order.Items != null && order.Items.Count > 0)
                {
                    foreach (var item in order.Items)
                    {
                        var orderItem = item.Key;
                        var quantity = item.Value;
                        sb.AppendLine($"  - {orderItem.Name} x{quantity}");
                        sb.AppendLine($"    {orderItem.Price} руб. × {quantity} = {orderItem.Price * quantity} руб.");
                    }
                }
                else
                {
                    sb.AppendLine("  Нет позиций");
                }

                sb.AppendLine("----------------------------");
                sb.AppendLine($"ИТОГО: {order.TotalPrice} руб.");
                sb.AppendLine("====================");

                richTextBox1.Text = sb.ToString();
            }
            else
            {
                richTextBox1.Text = "Заказ не выбран";
            }
        }
    }
}
