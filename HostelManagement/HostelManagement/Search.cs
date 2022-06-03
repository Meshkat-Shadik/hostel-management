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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        public string SearchString = "datasource=localhost;username=root;database=hall_management; password=";
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateUi())
            {
                dis_dta();
                txtId.Text = "";
            }
            
        }
        public void dis_dta()
        {
            MySqlConnection srch = new MySqlConnection(SearchString);
            srch.Open();
            MySqlCommand cmd = srch.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from addstudent where id = '"+txtId.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            srch.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            this.Hide();
            st.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent ast = new AddStudent();
            this.Hide();
            ast.ShowDialog();
        }
        private bool ValidateUi()
        {
            if (txtId.Text.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("Warning", "Please Enter Student Id", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}
