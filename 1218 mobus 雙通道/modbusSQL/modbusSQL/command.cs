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
    public partial class command : Form
    {
        public command()
        {
            InitializeComponent();
        }
        //設定OK 更新置資料庫
        string cnstr = @"Data Source=(localDB)\MSSQLLocalDB;" +
                 "AttachDbFilename=|DataDirectory|getdata.mdf;" +
                 "Integrated Security =True";
        string add1,add2,add3,add4,add5,add6,add7,add8;//c1


        private void button2_Click(object sender, EventArgs e)//命令二設定完成後動作
        {
            try
            {
                using (SqlConnection cn2 = new SqlConnection())
                {

                    cn2.ConnectionString = cnstr;
                    cn2.Open();
                    string sqlStr1 = "TRUNCATE  TABLE 命令二";
                    SqlCommand Cmd = new SqlCommand(sqlStr1, cn2);//clear table data*/
                    Cmd.ExecuteNonQuery();

                    string sqlstr = "INSERT INTO 命令二(命令,命令參與,數據1名稱,數據1開始,數據1結束,數據1運算,數據1單位,參與1,數據2名稱,數據2開始,數據2結束,數據2運算,數據2單位,參與2,數據3名稱,數據3開始,數據3結束,數據3運算,數據3單位,參與3" +
                      ",數據4名稱, 數據4開始, 數據4結束, 數據4運算, 數據4單位, 參與4,數據5名稱, 數據5開始, 數據5結束, 數據5運算, 數據5單位, 參與5,數據6名稱, 數據6開始, 數據6結束, 數據6運算, 數據6單位, 參與6,數據7名稱, 數據7開始, 數據7結束, 數據7運算, 數據7單位, 參與7 )"
                       + "VALUES(@command,@c2start1,@c2name1,@c2dataf1,@c2datae1,@c2Operation1,@c2unit1,@c2data1start,@c2name2,@c2dataf2,@c2datae2,@c2Operation2,@c2unit2,@c2data2start," +
                       " @c2name3, @c2dataf3, @c2datae3, @c2Operation3, @c2unit3, @c2data3start, @c2name4, @c2dataf4, @c2datae4, @c2Operation4, @c2unit4, @c2data4start, " +
                       "@c2name5, @c2dataf5, @c2datae5, @c2Operation5, @c2unit5, @c2data5start,@c2name6, @c2dataf6, @c2datae6, @c2Operation6, @c2unit6, @c2data6start,@c2name7, @c2dataf7, @c2datae7, @c2Operation7, @c2unit7, @c2data7start)";


                    SqlCommand cmd = new SqlCommand(sqlstr, cn2);
                    ////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@command", SqlDbType.NVarChar));
                    ////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c2name1", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2start1", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@c2dataf1", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2datae1", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2Operation1", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2unit1", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2data1start", SqlDbType.Int));

                    cmd.Parameters["@command"].Value = command2.Text;
                    cmd.Parameters["@c2name1"].Value = c2namedata1.Text;
                    cmd.Parameters["@c2dataf1"].Value = C2dataf1.Text;
                    cmd.Parameters["@c2datae1"].Value = C2datae1.Text;
                    cmd.Parameters["@c2Operation1"].Value = C2combo1.SelectedItem;
                    cmd.Parameters["@c2unit1"].Value = c2unitdata1.Text;
                    if (checkBox2.Checked) { add1 = "1"; } else { add1 = "0"; }
                    if (c2namedata1.Text != null) { add2 = "1"; } else { add2 = "0"; }
                    cmd.Parameters["@c2start1"].Value = add1;
                    cmd.Parameters["@c2data1start"].Value = add2;
                    //////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c2name2", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2dataf2", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2datae2", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2Operation2", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2unit2", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2data2start", SqlDbType.Int));


                    cmd.Parameters["@c2name2"].Value = c2namedata2.Text;
                    cmd.Parameters["@c2dataf2"].Value = C2dataf2.Text;
                    cmd.Parameters["@c2datae2"].Value = C2datae2.Text;
                    cmd.Parameters["@c2Operation2"].Value = C2combo2.SelectedItem;
                    cmd.Parameters["@c2unit2"].Value = c2unitdata2.Text;
                   
                    if (c2namedata2.Text != null) { add3 = "1"; } else { add3 = "0"; }

                    cmd.Parameters["@c2data2start"].Value = add3;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c2name3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2dataf3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2datae3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2Operation3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2unit3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2data3start", SqlDbType.Int));


                    cmd.Parameters["@c2name3"].Value = c2namedata3.Text;
                    cmd.Parameters["@c2dataf3"].Value = C2dataf3.Text;
                    cmd.Parameters["@c2datae3"].Value = C2datae3.Text;
                    cmd.Parameters["@c2Operation3"].Value = C2combo3.SelectedItem;
                    cmd.Parameters["@c2unit3"].Value = c2unitdata3.Text;

                    if (c2namedata3.Text != null) { add4 = "1"; } else { add4 = "0"; }

                    cmd.Parameters["@c2data3start"].Value = add4;
                    ////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c2name4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2dataf4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2datae4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2Operation4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2unit4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2data4start", SqlDbType.Int));


                    cmd.Parameters["@c2name4"].Value = c2namedata4.Text;
                    cmd.Parameters["@c2dataf4"].Value = C2dataf4.Text;
                    cmd.Parameters["@c2datae4"].Value = C2datae4.Text;
                    cmd.Parameters["@c2Operation4"].Value = C2combo4.SelectedItem;
                    cmd.Parameters["@c2unit4"].Value = c2unitdata4.Text;

                    if (c2namedata4.Text != null) { add5 = "1"; } else { add5 = "0"; }

                    cmd.Parameters["@c2data4start"].Value = add5;
                    /////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c2name5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2dataf5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2datae5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2Operation5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2unit5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2data5start", SqlDbType.Int));


                    cmd.Parameters["@c2name5"].Value = c2namedata5.Text;
                    cmd.Parameters["@c2dataf5"].Value = C2dataf5.Text;
                    cmd.Parameters["@c2datae5"].Value = C2datae5.Text;
                    cmd.Parameters["@c2Operation5"].Value = C2combo5.SelectedItem;
                    cmd.Parameters["@c2unit5"].Value = c2unitdata5.Text;
                    if (c2namedata5.Text != null) { add6 = "1"; } else { add6 = "0"; }
                    cmd.Parameters["@c2data5start"].Value = add6;
                    /////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c2name6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2dataf6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2datae6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2Operation6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2unit6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2data6start", SqlDbType.Int));


                    cmd.Parameters["@c2name6"].Value = c2namedata6.Text;
                    cmd.Parameters["@c2dataf6"].Value = C2dataf6.Text;
                    cmd.Parameters["@c2datae6"].Value = C2datae6.Text;
                    cmd.Parameters["@c2Operation6"].Value = C2combo6.SelectedItem;
                    cmd.Parameters["@c2unit6"].Value = c2unitdata6.Text;
                    if (c2namedata6.Text != null) { add7 = "1"; } else { add7 = "0"; }
                    cmd.Parameters["@c2data6start"].Value = add7;

                    /////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c2name7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2dataf7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2datae7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2Operation7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2unit7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c2data7start", SqlDbType.Int));


                    cmd.Parameters["@c2name7"].Value = c2namedata7.Text;
                    cmd.Parameters["@c2dataf7"].Value = C2dataf7.Text;
                    cmd.Parameters["@c2datae7"].Value = C2datae7.Text;
                    cmd.Parameters["@c2Operation7"].Value = C2combo7.SelectedItem;
                    cmd.Parameters["@c2unit7"].Value = c2unitdata7.Text;
                    if (c2namedata7.Text != null) { add8 = "1"; } else { add8 = "0"; }
                    cmd.Parameters["@c2data7start"].Value = add8;

                    cmd.ExecuteNonQuery();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                ShowData2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "erroer");
            }


        }

        private void command_FormClosed(object sender, FormClosedEventArgs e)
        {
         
            this.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        void ShowData1()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                SqlDataAdapter daData = new SqlDataAdapter("SELECT * FROM 命令一 ORDER BY 命令 DESC", cn);
                DataSet ds = new DataSet();
                daData.Fill(ds, "命令一");
                dataGridView1.DataSource = ds.Tables["命令一"];


            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        void ShowData2()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;
                SqlDataAdapter daData = new SqlDataAdapter("SELECT * FROM 命令二 ORDER BY 命令 DESC", cn);
                DataSet ds = new DataSet();
                daData.Fill(ds, "命令二");
                dataGridView2.DataSource = ds.Tables["命令二"];


            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    using (SqlConnection cn1 = new SqlConnection())
                    {
                    
                        cn1.ConnectionString = cnstr;
                        cn1.Open();
                     string sqlStr1= "TRUNCATE  TABLE 命令一";
                     SqlCommand Cmd = new SqlCommand(sqlStr1, cn1);//clear table data*/
                     Cmd.ExecuteNonQuery();
                   
                     string sqlstr= "INSERT INTO 命令一(命令,命令參與,數據1名稱,數據1開始,數據1結束,數據1運算,數據1單位,參與1,數據2名稱,數據2開始,數據2結束,數據2運算,數據2單位,參與2,數據3名稱,數據3開始,數據3結束,數據3運算,數據3單位,參與3" +
                       ",數據4名稱, 數據4開始, 數據4結束, 數據4運算, 數據4單位, 參與4,數據5名稱, 數據5開始, 數據5結束, 數據5運算, 數據5單位, 參與5,數據6名稱, 數據6開始, 數據6結束, 數據6運算, 數據6單位, 參與6,數據7名稱, 數據7開始, 數據7結束, 數據7運算, 數據7單位, 參與7 )"
                        + "VALUES(@command,@c1start1,@c1name1,@c1dataf1,@c1datae1,@c1Operation1,@c1unit1,@c1data1start,@c1name2,@c1dataf2,@c1datae2,@c1Operation2,@c1unit2,@c1data2start," +
                        " @c1name3, @c1dataf3, @c1datae3, @c1Operation3, @c1unit3, @c1data3start, @c1name4, @c1dataf4, @c1datae4, @c1Operation4, @c1unit4, @c1data4start, " +
                        "@c1name5, @c1dataf5, @c1datae5, @c1Operation5, @c1unit5, @c1data5start,@c1name6, @c1dataf6, @c1datae6, @c1Operation6, @c1unit6, @c1data6start,@c1name7, @c1dataf7, @c1datae7, @c1Operation7, @c1unit7, @c1data7start)"; 
                       
             
                     SqlCommand cmd = new SqlCommand(sqlstr, cn1);
 ////////////////////////////////////////////////////////////////////////////
                     cmd.Parameters.Add(new SqlParameter("@command", SqlDbType.NVarChar));
                    ////////////////////////////////////////////////////////////////////
                     cmd.Parameters.Add(new SqlParameter("@c1name1", SqlDbType.NVarChar));
                     cmd.Parameters.Add(new SqlParameter("@c1start1", SqlDbType.Int));
                     cmd.Parameters.Add(new SqlParameter("@c1dataf1", SqlDbType.NVarChar));
                     cmd.Parameters.Add(new SqlParameter("@c1datae1", SqlDbType.NVarChar));
                     cmd.Parameters.Add(new SqlParameter("@c1Operation1", SqlDbType.NVarChar));
                     cmd.Parameters.Add(new SqlParameter("@c1unit1", SqlDbType.NVarChar));              
                     cmd.Parameters.Add(new SqlParameter("@c1data1start", SqlDbType.Int));

                     cmd.Parameters["@command"].Value = command1.Text;
                     cmd.Parameters["@c1name1"].Value =c1name.Text;
                     cmd.Parameters["@c1dataf1"].Value = C1dataf1.Text;
                     cmd.Parameters["@c1datae1"].Value = C1datae1.Text;
                     cmd.Parameters["@c1Operation1"].Value = C1combo1.SelectedItem;
                     cmd.Parameters["@c1unit1"].Value = c1unit.Text;
                     if (checkBox1.Checked) { add1 = "1"; }else { add1 = "0"; }
                     if (c1name.Text != null) { add2 = "1"; } else { add2 = "0";}                                                    
                     cmd.Parameters["@c1start1"].Value = add1;
                     cmd.Parameters["@c1data1start"].Value = add2;
                    //////////////////////////////////////////////////////////////////////////////////////
                     cmd.Parameters.Add(new SqlParameter("@c1name2", SqlDbType.NVarChar));           
                     cmd.Parameters.Add(new SqlParameter("@c1dataf2", SqlDbType.NVarChar));
                     cmd.Parameters.Add(new SqlParameter("@c1datae2", SqlDbType.NVarChar));
                     cmd.Parameters.Add(new SqlParameter("@c1Operation2", SqlDbType.NVarChar));
                     cmd.Parameters.Add(new SqlParameter("@c1unit2", SqlDbType.NVarChar));
                     cmd.Parameters.Add(new SqlParameter("@c1data2start", SqlDbType.Int));

                    
                     cmd.Parameters["@c1name2"].Value = namedata2.Text;
                     cmd.Parameters["@c1dataf2"].Value = C1dataf2.Text;
                     cmd.Parameters["@c1datae2"].Value = C1datae2.Text;
                     cmd.Parameters["@c1Operation2"].Value = C1combo2.SelectedItem;
                     cmd.Parameters["@c1unit2"].Value = unit2.Text;
                     if (checkBox1.Checked) { add1 = "1"; } else { add1 = "0"; }
                     if (namedata2.Text != null) { add3 = "1"; } else { add3 = "0"; }
                     
                     cmd.Parameters["@c1data2start"].Value = add3;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c1name3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1dataf3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1datae3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1Operation3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1unit3", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1data3start", SqlDbType.Int));


                    cmd.Parameters["@c1name3"].Value = namedata3.Text;
                    cmd.Parameters["@c1dataf3"].Value = C1dataf3.Text;
                    cmd.Parameters["@c1datae3"].Value = C1datae3.Text;
                    cmd.Parameters["@c1Operation3"].Value = C1combo3.SelectedItem;
                    cmd.Parameters["@c1unit3"].Value = unit3.Text;
                   
                    if (namedata3.Text != null) { add4 = "1"; } else { add4 = "0"; }
                   
                    cmd.Parameters["@c1data3start"].Value = add4;
     ////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c1name4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1dataf4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1datae4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1Operation4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1unit4", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1data4start", SqlDbType.Int));


                    cmd.Parameters["@c1name4"].Value = namedata4.Text;
                    cmd.Parameters["@c1dataf4"].Value = C1dataf4.Text;
                    cmd.Parameters["@c1datae4"].Value = C1datae4.Text;
                    cmd.Parameters["@c1Operation4"].Value = C1combo4.SelectedItem;
                    cmd.Parameters["@c1unit4"].Value = unit4.Text;

                    if (namedata4.Text != null) { add5 = "1"; } else { add5 = "0"; }

                    cmd.Parameters["@c1data4start"].Value = add5;
                    /////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c1name5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1dataf5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1datae5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1Operation5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1unit5", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1data5start", SqlDbType.Int));


                    cmd.Parameters["@c1name5"].Value = namedata5.Text;
                    cmd.Parameters["@c1dataf5"].Value = C1dataf5.Text;
                    cmd.Parameters["@c1datae5"].Value = C1datae5.Text;
                    cmd.Parameters["@c1Operation5"].Value = C1combo5.SelectedItem;
                    cmd.Parameters["@c1unit5"].Value = unit5.Text;               
                    if (namedata5.Text != null) { add6 = "1"; } else { add6 = "0"; }           
                    cmd.Parameters["@c1data5start"].Value = add6;
                    /////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c1name6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1dataf6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1datae6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1Operation6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1unit6", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1data6start", SqlDbType.Int));


                    cmd.Parameters["@c1name6"].Value = namedata6.Text;
                    cmd.Parameters["@c1dataf6"].Value = C1dataf6.Text;
                    cmd.Parameters["@c1datae6"].Value = C1datae6.Text;
                    cmd.Parameters["@c1Operation6"].Value = C1combo6.SelectedItem;
                    cmd.Parameters["@c1unit6"].Value = unit6.Text;
                    if (namedata6.Text != null) { add7 = "1"; } else { add7 = "0"; }
                    cmd.Parameters["@c1data6start"].Value = add7;

                    /////////////////////////////////////////////////////////////////////////////////////
                    cmd.Parameters.Add(new SqlParameter("@c1name7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1dataf7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1datae7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1Operation7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1unit7", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@c1data7start", SqlDbType.Int));


                    cmd.Parameters["@c1name7"].Value = namedata7.Text;
                    cmd.Parameters["@c1dataf7"].Value = C1dataf7.Text;
                    cmd.Parameters["@c1datae7"].Value = C1datae7.Text;
                    cmd.Parameters["@c1Operation7"].Value = C1combo7.SelectedItem;
                    cmd.Parameters["@c1unit7"].Value = unit7.Text;
                    if (namedata7.Text != null) { add8 = "1"; } else { add8 = "0"; }
                    cmd.Parameters["@c1data7start"].Value = add8;

                    cmd.ExecuteNonQuery();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                    ShowData1();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "erroer");
                }

            
        }

        private void command_Load(object sender, EventArgs e)
        {
            C1combo1.SelectedIndex = 0; C1combo2.SelectedIndex = 0;
            C1combo3.SelectedIndex = 0; C1combo4.SelectedIndex = 0;
            C1combo5.SelectedIndex = 0; C1combo6.SelectedIndex = 0;
            C1combo7.SelectedIndex = 0;

            C2combo1.SelectedIndex = 0; C2combo2.SelectedIndex = 0;
            C2combo3.SelectedIndex = 0; C2combo4.SelectedIndex = 0;
            C2combo5.SelectedIndex = 0; C2combo6.SelectedIndex = 0;
            C2combo7.SelectedIndex = 0;
        }

        private void command1_TextChanged(object sender, EventArgs e)
        {
            command1.Select(command1.Text.Length, 0);
            string Content = command1.Text.Replace(" ", "");//获取去除空格后的字符内容
            int SpaceCount = Content.Length / 2;
            int StartIndex = 2;
            for (int i = 0; i < SpaceCount; i++)
            {
                Content = Content.Insert(StartIndex, " ");             
                StartIndex = StartIndex + 3;
            }

            command1.Text = Content.TrimEnd().ToUpper();
            int SelectionStart = command1.Text.Length;
        }
        private void command2_TextChanged(object sender, EventArgs e)
        {
            command2.Select(command2.Text.Length, 0);
            string Content = command2.Text.Replace(" ", "");//获取去除空格后的字符内容
            int SpaceCount = Content.Length / 2;
            int StartIndex = 2;
            for (int i = 0; i < SpaceCount; i++)
            {
                Content = Content.Insert(StartIndex, " ");            
                StartIndex = StartIndex + 3;
            }

            command2.Text = Content.TrimEnd().ToUpper();
            int SelectionStart = command2.Text.Length;
        }
    }
}
