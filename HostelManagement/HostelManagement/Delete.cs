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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }
        public string dltstring = "datasource=localhost;username=root;database=hall_management; password=";

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateUi())
            {
                delete();
            }
            
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            this.Hide();
            ad.ShowDialog();
        }
        private bool ValidateUi()
        {
            if (txtDltID.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Warning", "Please Enter Student Id", MessageBoxButtons.OK);
                return false;
            }
            if (txtRoom.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Warning", "Please Enter Room Number", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void delete()
        {
            MySqlConnection dlt = new MySqlConnection(dltstring);
            dlt.Open();

            MySqlCommand cmd = dlt.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from addstudent where id ='" + txtDltID.Text + "'and RoomNo='" + txtRoom.Text + "'";
            string p = "update room set AvailableSeat =AvailableSeat+1 where RoomNo ='" + txtRoom.Text + "'";
            string pay = "Delete from payment where Id ='" + txtDltID.Text + "'";
            MySqlCommand updt = new MySqlCommand(p, dlt);
            MySqlCommand pa = new MySqlCommand(pay, dlt);
            cmd.ExecuteNonQuery();
            updt.ExecuteNonQuery();
            pa.ExecuteNonQuery();
            dlt.Close();

            MessageBox.Show("Delete Succeessful");
            ViewStudent dlth = new ViewStudent();
            this.Hide();
            dlth.ShowDialog();
        }
    }
}
