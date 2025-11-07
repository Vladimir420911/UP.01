using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void BeginCookingButton_Click(object sender, EventArgs e)
        {
            if (OrderTable.SelectedRows.Count > 0)
            { 
                 foreach (DataGridViewRow selectedRow in OrderTable.SelectedRows) 
                {
                    orderManager.UpdateOrderStatus(selectedRow.Index + 1, OrderStatus.Cooking);
                } 
                    
            }

        }
    }
}
