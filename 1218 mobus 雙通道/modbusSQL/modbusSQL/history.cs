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

namespace modbusSQL
{
    public partial class history : Form
    {

        string cnstr = @"Data Source=(localDB)\MSSQLLocalDB;" +
              "AttachDbFilename=|DataDirectory|getdata.mdf;" +
              "Integrated Security =True";

        public history()
        {
            InitializeComponent();
        }

        private void history_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        void ShowData()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                SqlDataAdapter daData = new SqlDataAdapter("SELECT * FROM Command1data ORDER BY 筆數 DESC ", cn);
                DataSet ds = new DataSet();
                daData.Fill(ds, "命令一");
               
                dataGridView1.DataSource = ds.Tables["命令一"];


            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[1].HeaderText = "收據編號";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[8].Width = 200;
        }
    }
}
