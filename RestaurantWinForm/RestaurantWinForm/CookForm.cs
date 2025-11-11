using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLib;

namespace RestaurantWinForm
{
    public partial class CookForm : Form
    {
        OrderManager orderManager = new OrderManager();

        public CookForm()
        {
            InitializeComponent();
            List<OrderItem> items1 = new List<OrderItem>();
            items1.Add(new OrderItem() { MenuItemId = 1, Name = "борщ", Price = 5, Quantity = 1 });
            items1.Add(new OrderItem() { MenuItemId = 2, Name = "пюрешка", Price = 10, Quantity = 2 });
            string itemStr = "";
            foreach (OrderItem item in items1)
            {
                itemStr += $"{item.Name} ";
            }

            orderManager.orders.Add(new Order() { OrderId = 1, Items = items1, ItemsString = itemStr, SeatId = 1, Status = OrderStatus.Accepted, TotalPrice = 25});

            OrderTable.DataSource = orderManager.orders; 
        }

        private void BeginCookingButton_Click(object sender, EventArgs e)
        {
            if (OrderTable.SelectedRows.Count > 0)
            { 
                 foreach (DataGridViewRow selectedRow in OrderTable.SelectedRows) 
                 {
                    orderManager.UpdateOrderStatus(selectedRow.Index + 1, OrderStatus.Cooking);
                    OrderTable.DataSource = null;
                    OrderTable.DataSource = orderManager.orders;
                 } 
                    
            }
            else
            {
                MessageBox.Show("не выбран заказ");
            }

        }

        private void OrderReadyButton_Click(object sender, EventArgs e)
        {
            if (OrderTable.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in OrderTable.SelectedRows)
                {
                    orderManager.UpdateOrderStatus(selectedRow.Index + 1, OrderStatus.Ready);
                    OrderTable.DataSource = null;
                    OrderTable.DataSource = orderManager.orders;
                }

            }
            else
            {
                MessageBox.Show("не выбран заказ");
            }
        }
    }
}
