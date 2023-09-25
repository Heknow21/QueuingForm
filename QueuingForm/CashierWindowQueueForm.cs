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
    public partial class CashierWindowQueue : Form
    {
        public CashierWindowQueue()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

        }
        Boolean openForm = false;
        customerView customerView = new customerView();
        FormCollection AllForm = Application.OpenForms;
        Form OpenedForm = new Form();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }
        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }
        public delegate void ControlPass(object sender);
        public ControlPass passControl;

        public void OpenCashier()
        {
            if (openForm == false)
            {
                CashierWindowQueue cashierWindow = new CashierWindowQueue();
                cashierWindow.Visible = true;
                openForm = true;
            }
        }

        private void CashierWindowQueue_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);

        }
        private void listCashierQueue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextServing();
        }

        public void NextServing()
        {
            foreach (Form form in AllForm)
            {
                if (form.Name == "CustomerView")
                {
                    OpenedForm = form;
                    openForm = true;
                }
            }
            if (openForm == true)
            {
                if (passControl != null)
                {
                    customerView.lblServing.Text = CashierClass.CashierQueue.Peek();
                    CashierClass.CashierQueue.Dequeue();
                    passControl(customerView.lblServing);
                }
            }
            else
            {
                customerView.Show();
                customerView.lblServing.Text = CashierClass.CashierQueue.Peek().ToString();
                CashierClass.CashierQueue.Dequeue();
            }
        }
    }
}