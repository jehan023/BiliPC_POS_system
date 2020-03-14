using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BiliPC
{
    public partial class LoginUI : Form
    {

        MongoCRUD db = new MongoCRUD("POS_Database");

        public LoginUI()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputUid = textBoxUsername.Text;
            string inputPwd = textBoxPassword.Text;
            bool loggedIn = false;
            var userRecord = db.LoadRecords<UsersModel>("Users");
            
            foreach (var user in userRecord)
            if ((inputUid == user.Username) && (inputPwd == user.Password))
            {
                this.Hide();
                loggedIn = true;
                if (user.isAdmin == true)
                {
                    AdminUI adminUI = new AdminUI();
                    adminUI.Show();
                }
                if (user.isAdmin == false)
                {
                    EmployeeUI employeeUI = new EmployeeUI();
                    employeeUI.Show();
                }
                break;
            }

            if (loggedIn != true)
            {
                MessageBox.Show("Incorrect username/password.");
            }  
        }
        //do not delete this.
        private void LoginUI_Load(object sender, EventArgs e){}
    }
}