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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            this.Hide();
            ad.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            dis_dta();
        }
        public string ViewString = "datasource=localhost;username=root;database=hall_management; password=";
        public void dis_dta()
        {
            MySqlConnection srch = new MySqlConnection(ViewString);
            srch.Open();
            MySqlCommand cmd = srch.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from addstudent";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            srch.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
