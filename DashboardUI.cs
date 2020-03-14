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
    public partial class DashboardUI : Form
    {
        public DashboardUI()
        {
            InitializeComponent();
            timer1.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
            CustomDesign();

            LoginUI login = new LoginUI();
            //verify if user is login to hide maanage button
            if (login.accType == "User")
                btnManageEmployees.Visible = false;

        }

        //TIMER TICK
        private void timer1_Tick_1(object sender, EventArgs e)
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
        private void openContainerForm(Form ContainerForm)
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
            openContainerForm(new TransactionForm());
            HideSubmenu();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            //codes for sales report
            HideSubmenu();
        }

        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            //codes for sales history
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
            openContainerForm(new ViewProducts());
            HideSubmenu();
        }

        private void btnEditProducts_Click_1(object sender, EventArgs e)
        {
            openContainerForm(new Products());
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
            openContainerForm(new ViewEmployees());
            HideSubmenu();
        }

        private void btnTrackEmployees_Click(object sender, EventArgs e)
        {
            openContainerForm(new TrackEmployees());
            HideSubmenu();
        }

        #endregion

        //LOGOUT PART
        #region Logout
        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #endregion

        
    }
}