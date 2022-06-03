using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace HostelManagement
{
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Room ad = new Room();
            this.Hide();
            ad.ShowDialog();
        }
        public string addstring = "datasource=localhost;username=root;database=hall_management; password=";
        private void button1_Click(object sender, EventArgs e)
        {
            if(ValidateUi())
            {
                MySqlConnection add = new MySqlConnection(addstring);
                add.Open();
                if (add.State == System.Data.ConnectionState.Open)
                {
                    string q = "INSERT INTO Room VALUES('" + txtroom.Text.ToString() + "','" + txtSeat.Text.ToString() + "','" + txtSeat.Text.ToString() + "')";
                    MySqlCommand cmd = new MySqlCommand(q, add);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add successfully");
                    txtroom.Text = "";
                    txtSeat.Text = "";
                }
                Room r = new Room();
                this.Hide();
                r.ShowDialog();
                add.Close();
            }
            
        }

        private void txtroom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSeat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private bool ValidateUi()
        {
            if (txtroom.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Warning", "Please Enter Room Number", MessageBoxButtons.OK);
                return false;
            }
            if (txtSeat.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Warning", "Please Enter Number of Seat", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
    }
}