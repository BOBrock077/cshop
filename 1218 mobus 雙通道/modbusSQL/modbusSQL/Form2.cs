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
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace modbusSQL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public  static bool AutoSend1 = false;
        int i = 0;
        string C1data1, C1data2, C1data3, C1data4, C1data5, C1data6, C1data7,count;
        int PointCount = 10; //點的數量 
        string cnstr = @"Data Source=(localDB)\MSSQLLocalDB;" +
                "AttachDbFilename=|DataDirectory|getdata.mdf;" +
                "Integrated Security =True";


        private void Form2_Load(object sender, EventArgs e)
        {
           

            if (tabControl1.SelectedIndex == 0)
            {
                //if (this.IsHandleCreated)
                //{
                if (AutoSend1 == false)
                {
                    AutoSend1 = true;
                    Thread ThTestL1 = new Thread(new ParameterizedThreadStart(TAutoSend1));
                    ThTestL1.IsBackground = true;
                    ThTestL1.Start(5000);
                }
                // }
                
            }
        }


        private void TAutoSend1(object Interval)
        {
            while (AutoSend1)
            {
                try
                {
                    if (AutoSend1 && this.IsHandleCreated)
                    {
                        for (i = 0; i < 2; i++)
                        {
                            if (i == 0 && Form1.C1add==1&&this.IsHandleCreated)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    Chart1();//chart1.Dispose();
                                   

                                }));
                            }

                            if (i == 1 && Form1.C2add == 1&& this.IsHandleCreated)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {

                                  //  Chart2(); //chart2.Dispose();
                                  
                                }));
                            }
                            Thread.Sleep(5000);
                            
                           
                        }


                      
                    }
                
                    
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"Form2 show chart error");
                }


            }
        }

      /*  private void TAutoSend2(object Interval)
        {
            while (AutoSend1)
            {
                try
                {
                    if (AutoSend1 && this.IsHandleCreated)
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                           // Chart1();
                            Chart2();

                        }));
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    Thread.Sleep(20000);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Form2 show chart error");
                }


            }
        }*/
        /*  void ShowData()
          {
              using (SqlConnection cn = new SqlConnection())
              {
                  cn.ConnectionString = cnstr;
                  SqlDataAdapter daData = new SqlDataAdapter("SELECT * FROM Command1data ORDER BY 筆數 DESC ", cn);
                  DataSet ds = new DataSet();
                  daData.Fill(ds, "命令一");
                  dataGridView1.DataSource = ds.Tables["命令一"];


              }
          }*/
        private Series _series = new Series();


        private void Chart1()//命令一
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;

                DataSet ds = new DataSet();
                SqlDataAdapter Command1data1 = new SqlDataAdapter("SELECT TOP 1 筆數,數據1,數據2,數據3,數據4,數據5,數據6,數據7  FROM Command1data ORDER BY 筆數 DESC", cn);
                Command1data1.Fill(ds, "Command1data");

                DataTable dt = ds.Tables["Command1data"];
               C1data1 = dt.Rows[0]["數據1"].ToString();//Y
                C1data2 = dt.Rows[0]["數據2"].ToString();//Y
                 C1data3 = dt.Rows[0]["數據3"].ToString();//Y
                C1data4 = dt.Rows[0]["數據4"].ToString();//Y
                 C1data5 = dt.Rows[0]["數據5"].ToString();//Y
                 C1data6 = dt.Rows[0]["數據6"].ToString();//Y
                 C1data7 = dt.Rows[0]["數據7"].ToString();//Y*/
                 count = dt.Rows[0]["筆數"].ToString();//X
                
               

            }
            Series series1 = chart1.Series[0];
            Series series2 = chart1.Series[1];
            Series series3 = chart1.Series[2];
            Series series4 = chart1.Series[3];
            Series series5 = chart1.Series[4];
            Series series6 = chart1.Series[5];
            Series series7 = chart1.Series[6];
            series1.Points.AddXY(count, C1data1);//x ,y value
            series2.Points.AddXY(count, C1data2);//x ,y value
            series3.Points.AddXY(count, C1data3);//x ,y value
            series4.Points.AddXY(count, C1data4);//x ,y value
            series5.Points.AddXY(count, C1data5);//x ,y value
            series6.Points.AddXY(count, C1data6);//x ,y value
            series7.Points.AddXY(count, C1data7);//x ,y value

            ChartArea chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.Minimum = 0d;
            series1.BorderWidth = 4;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].CursorX.AutoScroll = true;

            chart1.ChartAreas[0].AxisX.ScaleView.Size = 5;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;//指滚动条位于图表区内还是图表区外
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;

            chart1.ChartAreas[0].AxisX.ScaleView.Position = series1.Points.Count - 5;

        }



        private void Chart2()//命令=二
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnstr;

                DataSet ds = new DataSet();
                SqlDataAdapter Command1data1 = new SqlDataAdapter("SELECT TOP 1 筆數,數據1,數據2,數據3,數據4,數據5,數據6,數據7  FROM Command2data ORDER BY 筆數 DESC", cn);
                Command1data1.Fill(ds, "Command2data");

                DataTable dt = ds.Tables["Command2data"];
                string C1data1 = dt.Rows[0]["數據1"].ToString();//Y
                string C1data2 = dt.Rows[0]["數據2"].ToString();//Y
                string C1data3 = dt.Rows[0]["數據3"].ToString();//Y
                string C1data4 = dt.Rows[0]["數據4"].ToString();//Y
                string C1data5 = dt.Rows[0]["數據5"].ToString();//Y
                string C1data6 = dt.Rows[0]["數據6"].ToString();//Y
                string C1data7 = dt.Rows[0]["數據7"].ToString();//Y*/
                string count = dt.Rows[0]["筆數"].ToString();//X

                Series series1 = chart2.Series[0];
                Series series2 = chart2.Series[1];
                Series series3 = chart2.Series[2];
                Series series4 = chart2.Series[3];
                Series series5 = chart2.Series[4];
                Series series6 = chart2.Series[5];
                Series series7 = chart2.Series[6];
                series1.Points.AddXY(count, C1data1);//x ,y value
                series2.Points.AddXY(count, C1data2);//x ,y value
                series3.Points.AddXY(count, C1data3);//x ,y value
                series4.Points.AddXY(count, C1data4);//x ,y value
                series5.Points.AddXY(count, C1data5);//x ,y value
                series6.Points.AddXY(count, C1data6);//x ,y value
                series7.Points.AddXY(count, C1data7);//x ,y value

                chart2.ChartAreas[0].AxisX.ScaleView.Position = series1.Points.Count - 10;
                chart2.ChartAreas[0].AxisX.ScaleView.Position = series2.Points.Count - 10;


            }

           
        }



        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
          AutoSend1 = false;
            chart1.Dispose();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (tabControl1.SelectedIndex == 1)
            {
                  if (this.IsHandleCreated)
                  {
                      if (AutoSend1 == false)
                      {
                          AutoSend1 = true;
                          Thread ThTestL2 = new Thread(new ParameterizedThreadStart(TAutoSend2));
                          ThTestL2.IsBackground = true;
                          ThTestL2.Start(10000);
                      }
                  }
              
            }*/
        }
    }
}
