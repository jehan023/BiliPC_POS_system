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
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("POS_Database");
        static IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Users");

        public LoginUI()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "Admin" && textBoxPassword.Text == "admin")
            {
                this.Hide();
                AdminUI adminUI = new AdminUI();
                adminUI.Show();
            }
            else if (textBoxUsername.Text == "User" && textBoxPassword.Text == "user")
            {
                this.Hide();
                EmployeeUI employeeUI = new EmployeeUI();
                employeeUI.Show();
            }
            else 
            {
                MessageBox.Show("Incorrect username/password.");
            }
        }
    }
}