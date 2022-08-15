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

        //verify if admin or user
        public string accType = textBoxUsername.Text;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "Admin" && textBoxPassword.Text == "admin")
            {
                this.Hide();
                DashboardUI dashboard = new DashboardUI();
                dashboard.Show();
            }
            else if (textBoxUsername.Text == "User" && textBoxPassword.Text == "user")
            {
                this.Hide();
                DashboardUI dashboard = new DashboardUI();
                dashboard.Show();
            }
            else 
            {
                MessageBox.Show("Incorrect username/password.");
            }
        }
    }
}