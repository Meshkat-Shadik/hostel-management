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
    public partial class ViewPayment : Form
    {
        public ViewPayment()
        {
            InitializeComponent();
        }

        private void ViewPayment_Load(object sender, EventArgs e)
        {
            dis_dta();
        }
        public string Paymentstring = "datasource=localhost;username=root;database=hall_management; password=";
        public void dis_dta()
        {
            MySqlConnection srch = new MySqlConnection(Paymentstring);
            srch.Open();
            MySqlCommand cmd = srch.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from payment";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            srch.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            this.Hide();
            ad.ShowDialog();
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            Payment py = new Payment();
            this.Hide();
            py.ShowDialog();
        }
    }
}
