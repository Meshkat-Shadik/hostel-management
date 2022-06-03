using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HostelManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string conString = "datasource=localhost;username=root;database=hall_management; password=";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string query = "select UserRoll from login where username='" + txtUserName.Text.Trim()+ "'and password = '" + txtPassword.Text.Trim() + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query,conString);
            DataTable dta = new DataTable();
            sda.Fill(dta);
            if(dta.Rows.Count==1)
            {
                if (dta.Rows[0][0].ToString()=="1")
                {
                    Admin ad = new Admin();
                    this.Hide();
                    ad.ShowDialog();
                }
                else
                {
                    Student st = new Student();
                    this.Hide();
                    st.ShowDialog();
                }
                
            }
            else
            {
                MessageBox.Show("Username & password incorrect");
            }
            con.Close();          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
                
        }
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
