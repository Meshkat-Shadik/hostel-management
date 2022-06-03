using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace HostelManagement
{
    public partial class ViewAllStudentInfo : Form
    {
        public ViewAllStudentInfo()
        {
            InitializeComponent();
        }

        private void ViewAllStudentInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVeiw_Click(object sender, EventArgs e)
        {
            if (ValidateUi())
            {
                dis_dta();
                dis_payment();
                txtId.Text = "";
            }
        }
        public string ViewString = "datasource=localhost;username=root;database=hall_management; password=";
        public void dis_dta()
        {
            MySqlConnection srch = new MySqlConnection(ViewString);
            srch.Open();
            MySqlCommand cmd = srch.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from addstudent where id ='" + txtId.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            srch.Close();
        }
        public void dis_payment()
        {
            MySqlConnection srch = new MySqlConnection(ViewString);
            srch.Open();
            MySqlCommand cmd = srch.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from payment where id ='" + txtId.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            srch.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            this.Hide();
            ad.ShowDialog();
        }

        String id, lastPayDate, totAmount, payAmount, dueAmount;

        private void button1_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("D:/report_"+id+".pdf", FileMode.Create));
            document.Open();
            Paragraph p0 = new Paragraph("---------------------------------------------------------------------------------");
            Paragraph p1 = new Paragraph("     ID                =       "+id+"            ");
            Paragraph p01 = new Paragraph("--------------------------------------------------------------------------------");
            Paragraph p2 = new Paragraph("     Last Payment Date             =       "+lastPayDate + "         ");
            Paragraph p02 = new Paragraph("---------------------------------------------------------------------------------");
            Paragraph p3 = new Paragraph("     Total Amount              =       "+totAmount + "            ");
            Paragraph p03 = new Paragraph("--------------------------------------------------------------------------------");
            Paragraph p4 = new Paragraph("     Paid Amount               =       "+payAmount + "            ");
            Paragraph p04 = new Paragraph("--------------------------------------------------------------------------------");
            Paragraph p5 = new Paragraph("     Due Amount                =       "+dueAmount + "            ");
            Paragraph p05 = new Paragraph("--------------------------------------------------------------------------------");

            document.Add(p0);
            document.Add(p1);
            document.Add(p01);
            document.Add(p2);
            document.Add(p02);
            document.Add(p3);
            document.Add(p03);
            document.Add(p4);
            document.Add(p04);
            document.Add(p5);
            document.Add(p05);
            document.Close();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView3.SelectedRows[0].Cells["Id"].Value.ToString();
             lastPayDate = dataGridView3.SelectedRows[0].Cells["LastPaymentDate"].Value.ToString();
             totAmount = dataGridView3.SelectedRows[0].Cells["TotalAmount"].Value.ToString();
             payAmount = dataGridView3.SelectedRows[0].Cells["PayAmount"].Value.ToString();
             dueAmount = dataGridView3.SelectedRows[0].Cells["DueAmount"].Value.ToString();

            button1.Visible = true;
        }
    }
 }

