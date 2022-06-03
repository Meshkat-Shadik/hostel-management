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
    public partial class RoomMates : Form
    {
        public string ViewString = "datasource=localhost;username=root;database=hall_management; password=";
        public RoomMates()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateUi())
            {
                dis_dta();
                txtroom.Text = "";
            }
        }
        public void dis_dta()
        {
            MySqlConnection srch = new MySqlConnection(ViewString);
            srch.Open();
            MySqlCommand cmd = srch.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from addstudent where RoomNo ='" + txtroom.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            srch.Close();
        }
        private bool ValidateUi()
        {
            if (txtroom.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Warning", "Please Enter Room No", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            this.Hide();
            st.ShowDialog();
        }
    }
}
