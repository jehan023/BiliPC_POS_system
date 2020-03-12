using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace BiliPC
{
    public partial class AdminUI : Form
    {
        public AdminUI()
        {
            InitializeComponent();
            timer1.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
            CustomDesign();
        }

        //TIMER TICK
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        #region Hide-Show Submenu
        private void CustomDesign()
        {
            panelSales.Visible = false;
            panelInventory.Visible = false;
            panelManageEmployees.Visible = false;
        }
        private void HideSubmenu()
        {
            if (panelSales.Visible == true)
                panelSales.Visible = false;
            if (panelInventory.Visible == true)
                panelInventory.Visible = false;
            if (panelManageEmployees.Visible == true)
                panelManageEmployees.Visible = false;
        }
        private void ShowSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                HideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        #endregion

        #region Container Form
        private Form activeForm = null;
        private void openContainerFrom(Form ContainerForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ContainerForm;
            ContainerForm.TopLevel = false;
            ContainerForm.Dock = DockStyle.Fill;
            panelContainerForm.Controls.Add(ContainerForm);
            panelContainerForm.Tag = ContainerForm;
            ContainerForm.BringToFront();
            ContainerForm.Show();
        }
        #endregion

        //SALES PART
        #region Sales
        private void btnSales_Click_1(object sender, EventArgs e)
        {
            ShowSubmenu(panelSales);
        }

        private void btnCreateTransaction_Click_1(object sender, EventArgs e)
        {
            openContainerFrom(new TransactionForm());
            HideSubmenu();
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            //codes for sales history
            HideSubmenu();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            //codes for sales report
            HideSubmenu();
        }

        #endregion

        //INVERTORY PART
        #region Inventory
        private void btnInventory_Click_1(object sender, EventArgs e)
        {
            ShowSubmenu(panelInventory);
        }

        private void btnSearchProducts_Click_1(object sender, EventArgs e)
        {
            openContainerFrom(new ViewProducts());
            HideSubmenu();
        }

        private void btnEditProducts_Click_1(object sender, EventArgs e)
        {
            openContainerFrom(new Products());
            HideSubmenu();
        }
        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            //codes for inventory report
            HideSubmenu();
        }

        #endregion

        //MANAGE EMPLOYEES PART
        #region Manage Employees
        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelManageEmployees);
        }

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            //codes for view employees
            HideSubmenu();
        }

        private void btnTrackEmployees_Click(object sender, EventArgs e)
        {
            //codes for track employees
            HideSubmenu();
        }

        #endregion

        //LOGOUT PART
        #region Logout
        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LoginUI login = new LoginUI();
            login.Show();
        }

        #endregion

        
    }
}