using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuingForm
{
    public partial class QueuingForm : Form
    {
        private CashierClass cashier = new CashierClass();
        public QueuingForm()
        {
            InitializeComponent();
            cashier = new CashierClass();
            CashierWindowQueue cashier1 = new CashierWindowQueue();
            cashier1.OpenCashier();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblQueue_Click(object sender, EventArgs e)
        {

        }

        private void QueuingForm_Load(object sender, EventArgs e)
        {

        }
        private void btnCashier_Click(object sender, EventArgs e)
        {
            lblQueue.Text = cashier.CashierGeneratedNumber("P - ");
            CashierClass.getNumberInQueue = lblQueue.Text;
            CashierClass.CashierQueue.Enqueue(CashierClass.getNumberInQueue);

        }
    }
}
