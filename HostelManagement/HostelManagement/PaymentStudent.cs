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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace HostelManagement
{
    public partial class PaymentStudent : Form
    {
        public PaymentStudent()
        {
            InitializeComponent();
        }

        private void PaymentStudent_Load(object sender, EventArgs e)
        {

        }
        public string Paymentstring = "datasource=localhost;username=root;database=hall_management; password=";
        public void dis_dta()
        {
            MySqlConnection srch = new MySqlConnection(Paymentstring);
            srch.Open();
            MySqlCommand cmd = srch.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from payment where id ='" + txtId.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            srch.Close();
        }

        private void btnSee_Click(object sender, EventArgs e)
        {
            if (ValidateUi())
            {
                dis_dta();
                txtId.Text = "";
              //  button1.Visible = true;
            }       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            this.Hide();
            st.ShowDialog();
        }
        private bool ValidateUi()
        {
            if (txtId.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Warning", "Please Enter Student Id", MessageBoxButtons.OK);

            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}