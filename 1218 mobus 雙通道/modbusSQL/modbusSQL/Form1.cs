using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Data.SqlClient;
namespace modbusSQL
{
    public partial class Form1 : Form//溫度 SHT 11
    {
        SerialPort myserialPort = new SerialPort();
        int h = 0;
        int i = 0;
        int index = 0;
        public static int C1add,C2add;
        public static  bool AutoSend = false;
        string cnstr = @"Data Source=(localDB)\MSSQLLocalDB;" +
                "AttachDbFilename=|DataDirectory|getdata.mdf;" +
                "Integrated Security =True";
        string command1,C1Operation, C1unitdata,C1Operation2, C1unitdata2, C1Operation3, C1unitdata3, C1Operation4, C1unitdata4, C1Operation5, C1unitdata5, C1Operation6, C1unitdata6, C1Operation7, C1unitdata7;//命令一的參數變數
       

        private void 歷史紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history c1 = new history();
            c1.MdiParent = this;
            c1.Show();
        }

        int C1dataf1, C1datae1,C1data1add,C1dataf2, C1datae2, C1data2add, C1dataf3, C1datae3, C1data3add, C1dataf4, C1datae4, C1data4add, C1dataf5, C1datae5, C1data5add, C1dataf6, C1datae6, C1data6add, C1dataf7, C1datae7,C1data7add;
        string data2,data5,data7,data9,data11,data13,data15;

        string command2, C2Operation, C2unitdata, C2Operation2, C2unitdata2, C2Operation3, C2unitdata3, C2Operation4, C2unitdata4, C2Operation5, C2unitdata5, C2Operation6, C2unitdata6, C2Operation7, C2unitdata7;//命令二的參數變數
        int C2dataf1, C2datae1, C2data1add, C2dataf2, C2datae2, C2data2add, C2dataf3, C2datae3, C2data3add, C2dataf4, C2datae4, C2data4add, C2dataf5, C2datae5, C2data5add, C2dataf6, C2datae6, C2data6add, C2dataf7, C2datae7, C2data7add;
        string C2data2, C2data5, C2data7, C2data9, C2data11, C2data13, C2data15;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comport.Items.AddRange(ports);
           // comport.SelectedIndex = 0;
            combaudrate.SelectedIndex = 0;

        }


        private void TAutoSend(object Interval)
        {
            while (AutoSend)
            {
                try
                {
                    if (AutoSend)
                    {
                        // this.Invoke(new MethodInvoker(delegate
                        //  {
                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            try
                            {
                                using (SqlConnection cn = new SqlConnection())//取得C1參數
                                {
                                    cn.ConnectionString = cnstr;
                                    cn.Open();

                                    DataSet ds = new DataSet();
                                    SqlDataAdapter Command1data = new SqlDataAdapter("SELECT * FROM 命令一", cn);
                                    Command1data.Fill(ds, "命令一");
                                    DataTable dt = ds.Tables["命令一"];
                                    C1add = int.Parse(dt.Rows[0]["命令參與"].ToString());


                                    command1 = dt.Rows[0]["命令"].ToString();

                                    string C1dataf1a = dt.Rows[0]["數據1開始"].ToString();
                                    if (C1dataf1a != "") { C1dataf1 = int.Parse(dt.Rows[0]["數據1開始"].ToString()); } else { C1data1add = 0; }//判斷是否為空值
                                    if (C1dataf1a == "") { C1data1add = 1; }//是空值
                                    string C1datae1a = dt.Rows[0]["數據1結束"].ToString();
                                    if (C1datae1a != "") { C1datae1 = int.Parse(dt.Rows[0]["數據1結束"].ToString()); } else { C1data1add = 0; }
                                    if (C1datae1a == "") { C1data1add = 1; }//是空值         
                                    C1Operation = dt.Rows[0]["數據1運算"].ToString();
                                    C1unitdata = dt.Rows[0]["數據1單位"].ToString();


                                    string C1dataf2a = dt.Rows[0]["數據2開始"].ToString();
                                    if (C1dataf2a != "") { C1dataf2 = int.Parse(dt.Rows[0]["數據2開始"].ToString()); } else { C1data2add = 0; }//判斷是否為空值
                                    if (C1dataf2a == "") { C1data2add = 1; }//是空值
                                    string C1datae2a = dt.Rows[0]["數據2結束"].ToString();
                                    if (C1datae2a != "") { C1datae2 = int.Parse(dt.Rows[0]["數據2結束"].ToString()); } else { C1data2add = 0; }
                                    if (C1datae2a == "") { C1data2add = 1; }//是空值
                                    C1Operation2 = dt.Rows[0]["數據2運算"].ToString();
                                    C1unitdata2 = dt.Rows[0]["數據2單位"].ToString();


                                    string C1dataf3a = dt.Rows[0]["數據3開始"].ToString();
                                    if (C1dataf3a != "") { C1dataf3 = int.Parse(dt.Rows[0]["數據3開始"].ToString()); } else { C1data3add = 0; }//判斷是否為空值
                                    if (C1dataf3a == "") { C1data3add = 1; }//是空值
                                    string C1datae3a = dt.Rows[0]["數據3結束"].ToString();
                                    if (C1datae3a != "") { C1datae3 = int.Parse(dt.Rows[0]["數據3結束"].ToString()); } else { C1data3add = 0; }
                                    if (C1datae3a == "") { C1data3add = 1; }//是空值
                                    C1Operation3 = dt.Rows[0]["數據3運算"].ToString();
                                    C1unitdata3 = dt.Rows[0]["數據3單位"].ToString();

                                    string C1dataf4a = dt.Rows[0]["數據4開始"].ToString();
                                    if (C1dataf4a != "") { C1dataf4 = int.Parse(dt.Rows[0]["數據4開始"].ToString()); } else { C1data4add = 0; }//判斷是否為空值
                                    if (C1dataf4a == "") { C1data4add = 1; }//是空值
                                    string C1datae4a = dt.Rows[0]["數據4結束"].ToString();
                                    if (C1datae4a != "") { C1datae4 = int.Parse(dt.Rows[0]["數據4結束"].ToString()); } else { C1data4add = 0; }
                                    if (C1datae4a == "") { C1data4add = 1; }//是空值
                                    C1Operation4 = dt.Rows[0]["數據4運算"].ToString();
                                    C1unitdata4 = dt.Rows[0]["數據4單位"].ToString();

                                    string C1dataf5a = dt.Rows[0]["數據5開始"].ToString();
                                    if (C1dataf5a != "") { C1dataf5 = int.Parse(dt.Rows[0]["數據5開始"].ToString()); } else { C1data5add = 0; }//判斷是否為空值
                                    if (C1dataf5a == "") { C1data5add = 1; }//是空值
                                    string C1datae5a = dt.Rows[0]["數據5結束"].ToString();
                                    if (C1datae5a != "") { C1datae5 = int.Parse(dt.Rows[0]["數據5結束"].ToString()); } else { C1data5add = 0; }
                                    if (C1datae5a == "") { C1data5add = 1; }//是空值
                                    C1Operation5 = dt.Rows[0]["數據5運算"].ToString();
                                    C1unitdata5 = dt.Rows[0]["數據5單位"].ToString();

                                    string C1dataf6a = dt.Rows[0]["數據6開始"].ToString();
                                    if (C1dataf6a != "") { C1dataf6 = int.Parse(dt.Rows[0]["數據6開始"].ToString()); } else { C1data6add = 0; }//判斷是否為空值
                                    if (C1dataf6a == "") { C1data6add = 1; }//是空值
                                    string C1datae6a = dt.Rows[0]["數據6結束"].ToString();
                                    if (C1datae6a != "") { C1datae6 = int.Parse(dt.Rows[0]["數據6結束"].ToString()); } else { C1data6add = 0; }
                                    if (C1datae6a == "") { C1data6add = 1; }//是空值
                                    C1Operation6 = dt.Rows[0]["數據6運算"].ToString();
                                    C1unitdata6 = dt.Rows[0]["數據6單位"].ToString();

                                    string C1dataf7a = dt.Rows[0]["數據7開始"].ToString();
                                    if (C1dataf7a != "") { C1dataf7 = int.Parse(dt.Rows[0]["數據7開始"].ToString()); } else { C1data7add = 0; }//判斷是否為空值
                                    if (C1dataf7a == "") { C1data7add = 1; }//是空值
                                    string C1datae7a = dt.Rows[0]["數據7結束"].ToString();
                                    if (C1datae7a != "") { C1datae7 = int.Parse(dt.Rows[0]["數據7結束"].ToString()); }
                                    if (C1datae7a == "") { C1data7add = 1; }//是空值
                                    C1Operation7 = dt.Rows[0]["數據7運算"].ToString();
                                    C1unitdata7 = dt.Rows[0]["數據7單位"].ToString();




                                  //  command.Text = command1;
                                    cn.Close();
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers();
                                }
                                Console.WriteLine("sql1 OK");
                                using (SqlConnection cn = new SqlConnection())//取得C2參數
                                {
                                    cn.ConnectionString = cnstr;
                                    cn.Open();

                                    DataSet ds = new DataSet();
                                    SqlDataAdapter Command1data = new SqlDataAdapter("SELECT * FROM 命令二", cn);
                                    Command1data.Fill(ds, "命令二");
                                    DataTable dt = ds.Tables["命令二"];
                                    C2add = int.Parse(dt.Rows[0]["命令參與"].ToString());


                                    command2 = dt.Rows[0]["命令"].ToString();

                                    string C2dataf1a = dt.Rows[0]["數據1開始"].ToString();
                                    if (C2dataf1a != "") { C2dataf1 = int.Parse(dt.Rows[0]["數據1開始"].ToString()); } else { C2data1add = 0; }//判斷是否為空值
                                    if (C2dataf1a == "") { C2data1add = 1; }//是空值
                                    string C2datae1a = dt.Rows[0]["數據1結束"].ToString();
                                    if (C2datae1a != "") { C2datae1 = int.Parse(dt.Rows[0]["數據1結束"].ToString()); } else { C2data1add = 0; }
                                    if (C2datae1a == "") { C2data1add = 1; }//是空值         
                                    C2Operation = dt.Rows[0]["數據1運算"].ToString();
                                    C2unitdata = dt.Rows[0]["數據1單位"].ToString();


                                    string C2dataf2a = dt.Rows[0]["數據2開始"].ToString();
                                    if (C2dataf2a != "") { C2dataf2 = int.Parse(dt.Rows[0]["數據2開始"].ToString()); } else { C2data2add = 0; }//判斷是否為空值
                                    if (C2dataf2a == "") { C2data2add = 1; }//是空值
                                    string C2datae2a = dt.Rows[0]["數據2結束"].ToString();
                                    if (C2datae2a != "") { C2datae2 = int.Parse(dt.Rows[0]["數據2結束"].ToString()); } else { C2data2add = 0; }
                                    if (C2datae2a == "") { C2data2add = 1; }//是空值
                                    C2Operation2 = dt.Rows[0]["數據2運算"].ToString();
                                    C2unitdata2 = dt.Rows[0]["數據2單位"].ToString();


                                    string C2dataf3a = dt.Rows[0]["數據3開始"].ToString();
                                    if (C2dataf3a != "") { C2dataf3 = int.Parse(dt.Rows[0]["數據3開始"].ToString()); } else { C2data3add = 0; }//判斷是否為空值
                                    if (C2dataf3a == "") { C2data3add = 1; }//是空值
                                    string C2datae3a = dt.Rows[0]["數據3結束"].ToString();
                                    if (C2datae3a != "") { C2datae3 = int.Parse(dt.Rows[0]["數據3結束"].ToString()); } else { C2data3add = 0; }
                                    if (C2datae3a == "") { C2data3add = 1; }//是空值
                                    C2Operation3 = dt.Rows[0]["數據3運算"].ToString();
                                    C2unitdata3 = dt.Rows[0]["數據3單位"].ToString();

                                    string C2dataf4a = dt.Rows[0]["數據4開始"].ToString();
                                    if (C2dataf4a != "") { C2dataf4 = int.Parse(dt.Rows[0]["數據4開始"].ToString()); } else { C2data4add = 0; }//判斷是否為空值
                                    if (C2dataf4a == "") { C2data4add = 1; }//是空值
                                    string C2datae4a = dt.Rows[0]["數據4結束"].ToString();
                                    if (C2datae4a != "") { C2datae4 = int.Parse(dt.Rows[0]["數據4結束"].ToString()); } else { C2data4add = 0; }
                                    if (C2datae4a == "") { C2data4add = 1; }//是空值
                                    C2Operation4 = dt.Rows[0]["數據4運算"].ToString();
                                    C2unitdata4 = dt.Rows[0]["數據4單位"].ToString();

                                    string C2dataf5a = dt.Rows[0]["數據5開始"].ToString();
                                    if (C2dataf5a != "") { C2dataf5 = int.Parse(dt.Rows[0]["數據5開始"].ToString()); } else { C2data5add = 0; }//判斷是否為空值
                                    if (C2dataf5a == "") { C2data5add = 1; }//是空值
                                    string C2datae5a = dt.Rows[0]["數據5結束"].ToString();
                                    if (C2datae5a != "") { C2datae5 = int.Parse(dt.Rows[0]["數據5結束"].ToString()); } else { C2data5add = 0; }
                                    if (C2datae5a == "") { C2data5add = 1; }//是空值
                                    C2Operation5 = dt.Rows[0]["數據5運算"].ToString();
                                    C2unitdata5 = dt.Rows[0]["數據5單位"].ToString();

                                    string C2dataf6a = dt.Rows[0]["數據6開始"].ToString();
                                    if (C2dataf6a != "") { C2dataf6 = int.Parse(dt.Rows[0]["數據6開始"].ToString()); } else { C2data6add = 0; }//判斷是否為空值
                                    if (C2dataf6a == "") { C2data6add = 1; }//是空值
                                    string C2datae6a = dt.Rows[0]["數據6結束"].ToString();
                                    if (C2datae6a != "") { C2datae6 = int.Parse(dt.Rows[0]["數據6結束"].ToString()); } else { C2data6add = 0; }
                                    if (C2datae6a == "") { C1data6add = 1; }//是空值
                                    C2Operation6 = dt.Rows[0]["數據6運算"].ToString();
                                    C2unitdata6 = dt.Rows[0]["數據6單位"].ToString();

                                    string C2dataf7a = dt.Rows[0]["數據7開始"].ToString();
                                    if (C2dataf7a != "") { C2dataf7 = int.Parse(dt.Rows[0]["數據7開始"].ToString()); } else { C2data7add = 0; }//判斷是否為空值
                                    if (C2dataf7a == "") { C2data7add = 1; }//是空值
                                    string C2datae7a = dt.Rows[0]["數據7結束"].ToString();
                                    if (C2datae7a != "") { C2datae7 = int.Parse(dt.Rows[0]["數據7結束"].ToString()); }
                                    if (C2datae7a == "") { C2data7add = 1; }//是空值
                                    C2Operation7 = dt.Rows[0]["數據7運算"].ToString();
                                    C2unitdata7 = dt.Rows[0]["數據7單位"].ToString();




                                    //command.Text = command1;
                                    cn.Close();
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers();
                                }
                                 h = C1add + C2add;

                                Console.WriteLine("sql2 OK");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            
                            

                           
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }));

                        Thread.Sleep(1);

                        for (i = 0; i < h; i++)
                        {
                            if (AutoSend)
                            {
                                if (i == 0&&C1add==1)
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        string[] HexStr = command1.Trim().Split(' ');
                                        byte[] data1 = new byte[4];
                                       data1 = new byte[HexStr.Length];
                                       for (int i = 0; i < HexStr.Length; i++)
                                    {
                                        data1[i] = (byte)(Convert.ToInt32(HexStr[i], 16));
                                    }
                                    myserialPort.Write(data1, 0, data1.Length);
                                    command.Text = command1;
                                        Console.WriteLine("command1");
                                    }));
                                }
                               if (i == 1&&C2add==1)
                                {
                                    this.Invoke(new MethodInvoker(delegate
                                    {
                                        string[] HexStr = command2.Trim().Split(' ');
                                    byte[] data2 = new byte[4];
                                    data2 = new byte[HexStr.Length];
                                    for (int i = 0; i < HexStr.Length; i++)
                                    {
                                        data2[i] = (byte)(Convert.ToInt32(HexStr[i], 16));
                                    }
                                    myserialPort.Write(data2, 0, data2.Length);
                                    command.Text = command2;
                                        Console.WriteLine("command2");
                                    }));
                                }
                               
                      
                            }
                            Thread.Sleep(5000);
                          
                        }
                        //Thread.ResetAbort();
                    }
                    else
                    {

                        break;
                    }
                }
                catch
                {

                }
            }




        }

        private void 命令設置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            command c = new command();
            c.MdiParent = this;
            c.Show();
        }

        private void 圖表設置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 c1 = new Form2();
            c1.MdiParent = this;
            c1.Show();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)//start
        {
          
            GC.Collect();
            GC.WaitForPendingFinalizers();
            toolStripButton3.Enabled = false;
            myserialPort = new SerialPort();
            myserialPort.BaudRate = int.Parse(combaudrate.Text);
            myserialPort.PortName = comport.Text;
            myserialPort.Parity = Parity.None;
            myserialPort.DataBits = 8;
            myserialPort.StopBits = StopBits.One;
            myserialPort.Open();

            myserialPort.DataReceived += new SerialDataReceivedEventHandler(myserialPort_DataReceived);
            try
            {
                if (AutoSend == false)
                {
                    AutoSend = true;
                    Thread ThTestL = new Thread(new ParameterizedThreadStart(TAutoSend));
                    ThTestL.IsBackground = true;
                    ThTestL.Start(20000);
                    Console.WriteLine(ThTestL.ThreadState);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Thread error");
                    
            }
            }
        private void myserialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            byte[] data = new byte[myserialPort.BytesToRead];
            myserialPort.Read(data, 0, data.Length);//读取数据
            try
            {
                if (data.Length > 0 )
                {
                  if (i==0 && C1add == 1)
                  { 
                        StringBuilder hexstring1 = new StringBuilder();//數據1
                    if (C1data1add == 0)//不為空值的狀態
                    {
                        for (int i = C1dataf1; i < C1datae1 + 1; i++)
                        {
                            hexstring1.AppendFormat("{0:x2}", data[i]);

                        }
                    }
                    else { data2 = null; }
                   
                        StringBuilder hexstring2 = new StringBuilder();//數據2
                        if (C1data2add == 0)//不為空值的狀態
                        {

                            for (int i = C1dataf2; i < C1datae2 + 1; i++)
                            {
                                hexstring2.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { data5 = null; }

                        StringBuilder hexstring3 = new StringBuilder();//數據3
                        if (C1data3add == 0)//不為空值的狀態
                        {
                            for (int i = C1dataf3; i < C1datae3 + 1; i++)
                            {
                                hexstring3.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { data7 = null; }


                        StringBuilder hexstring4 = new StringBuilder();//數據4
                        if (C1data4add == 0)//不為空值的狀態
                        {
                            for (int i = C1dataf4; i < C1datae4 + 1; i++)
                            {
                                hexstring4.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { data9 = null; }

                        StringBuilder hexstring5 = new StringBuilder();//數據5

                        if (C1data5add == 0)//不為空值的狀態
                        {
                            for (int i = C1dataf5; i < C1datae5 + 1; i++)
                            {
                                hexstring5.AppendFormat("{0:x2}", data[i]);
                            }
                        }
                        else { data11 = null; }

                        StringBuilder hexstring6 = new StringBuilder();//數據6
                        if (C1data6add == 0)//不為空值的狀態
                        {
                            for (int i = C1dataf6; i < C1datae6 + 1; i++)
                            {
                                hexstring6.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { data13 = null; }

                        StringBuilder hexstring7 = new StringBuilder();//數據7
                        if (C1data7add == 0)//不為空值的狀態
                        {
                            for (int i = C1dataf7; i < C1datae7 + 1; i++)
                            {
                                hexstring7.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { data15 =null; }

                        AddContent(hexstring1.ToString(), hexstring2.ToString(), hexstring3.ToString(), hexstring4.ToString(), hexstring5.ToString(), hexstring6.ToString(), hexstring7.ToString());
                  }

                    if (i == 1 && C2add == 1)//C2
                    {
                        StringBuilder hexstring1 = new StringBuilder();//數據1
                        if (C2data1add == 0)//不為空值的狀態
                        {
                            for (int i = C2dataf1; i < C2datae1 + 1; i++)
                            {
                                hexstring1.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { C2data2 =" "; }

                        StringBuilder hexstring2 = new StringBuilder();//數據2
                        if (C2data2add == 0)//不為空值的狀態
                        {

                            for (int i = C2dataf2; i < C2datae2 + 1; i++)
                            {
                                hexstring2.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { C2data5 =null; }

                        StringBuilder hexstring3 = new StringBuilder();//數據3
                        if (C2data3add == 0)//不為空值的狀態
                        {
                            for (int i = C2dataf3; i < C2datae3 + 1; i++)
                            {
                                hexstring3.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { C2data7 =null; }


                        StringBuilder hexstring4 = new StringBuilder();//數據4
                        if (C2data4add == 0)//不為空值的狀態
                        {
                            for (int i = C2dataf4; i < C2datae4 + 1; i++)
                            {
                                hexstring4.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { C2data9 =null; }

                        StringBuilder hexstring5 = new StringBuilder();//數據5

                        if (C2data5add == 0)//不為空值的狀態
                        {
                            for (int i = C2dataf5; i < C2datae5 + 1; i++)
                            {
                                hexstring5.AppendFormat("{0:x2}", data[i]);
                            }
                        }
                        else { C2data11 =null; }

                        StringBuilder hexstring6 = new StringBuilder();//數據6
                        if (C2data6add == 0)//不為空值的狀態
                        {
                            for (int i = C2dataf6; i < C2datae6 + 1; i++)
                            {
                                hexstring6.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { C2data13 =null; }

                        StringBuilder hexstring7 = new StringBuilder();//數據7
                        if (C2data7add == 0)//不為空值的狀態
                        {
                            for (int i = C2dataf7; i < C2datae7 + 1; i++)
                            {
                                hexstring7.AppendFormat("{0:x2}", data[i]);

                            }
                        }
                        else { C2data15 =null; }

                        AddContent1(hexstring1.ToString(), hexstring2.ToString(), hexstring3.ToString(), hexstring4.ToString(), hexstring5.ToString(), hexstring6.ToString(), hexstring7.ToString());
                    }
                    Console.WriteLine("data catch OK");
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"myserial DataRece error");
            }

        }

        private void AddContent(string hexstring1, string hexstring2, string hexstring3, string hexstring4, string hexstring5, string hexstring6, string hexstring7)
        {
            if (i == 0 && C1add == 1)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                 if (hexstring1.Length > 2)
                 {


                     if (C1Operation == "x1")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         data2 = data1.ToString();
                     }
                     else if (C1Operation == "x10")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 10;
                         data2 = data1.ToString();
                     }
                     else if (C1Operation == "x100")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 100;
                         data2 = data1.ToString();
                     }
                     else if (C1Operation == "x1000")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 1000;
                         data2 = data1.ToString();
                     }
                     else if (C1Operation == "x10000")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 10000;
                         data2 = data1.ToString();
                     }
                     else if (C1Operation == "/10")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         data2 = data1.ToString();
                     }
                     else if (C1Operation == "/100")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         data2 = data1.ToString("f2");
                     }
                     else if (C1Operation == "/1000")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) / 1000.000;
                         data2 = data1.ToString("f3");
                     }
                     else if (C1Operation == "/10000")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) / 10000.0000;
                         data2 = data1.ToString("f4");
                     }
                     else { }
                 }
                 if (hexstring2.Length > 2)
                 {
                     if (C1Operation2 == "x1")
                     {
                         string data = hexstring2;//數據2
                                                  // if (data != "")
                                                  // {
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         data5 = data1.ToString();
                         // }
                     }
                     else if (C1Operation2 == "x10")
                     {
                         string data = hexstring2;//數據2
                         double data1 = Convert.ToInt32(data, 16) * 10;
                         data5 = data1.ToString();
                     }
                     else if (C1Operation2 == "x100")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) * 100;
                         data5 = data2.ToString();
                     }
                     else if (C1Operation2 == "x1000")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) * 1000;
                         data5 = data2.ToString();
                     }
                     else if (C1Operation2 == "x10000")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) * 10000;
                         data5 = data2.ToString();
                     }
                     else if (C1Operation2 == "/10")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) / 10.0;
                         data5 = data2.ToString("f1");
                     }
                     else if (C1Operation2 == "/100")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) / 100.00;
                         data5 = data2.ToString("f2");
                     }
                     else if (C1Operation2 == "/1000")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) / 1000.000;
                         data5 = data2.ToString("f3");
                     }
                     else if (C1Operation2 == "/10000")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) * 10000.0000;
                         data5 = data2.ToString("f4");
                     }
                     else { }
                 }

                 if (hexstring3.Length > 2)
                 {
                     if (C1Operation3 == "/10")
                     {
                         string data = hexstring3;//數據3
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         data7 = data1.ToString();
                     }
                     else if (C1Operation3 == "/100")
                     {
                         string data = hexstring3;//數據3
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         data7 = data1.ToString();
                     }
                     else if (C1Operation3 == "x1")
                     {
                         string data = hexstring3;//數據3
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         data7 = data1.ToString();
                     }
                     else { }
                 }
                 if (hexstring4.Length > 2)
                 {
                     if (C1Operation4 == "/10")
                     {
                         string data = hexstring4;//數據4
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         data9 = data1.ToString();
                     }
                     else if (C1Operation4 == "/100")
                     {
                         string data = hexstring4;//數據4
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         data9 = data1.ToString();
                     }
                     else if (C1Operation4 == "x1")
                     {
                         string data = hexstring4;//數據4
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         data9 = data1.ToString();
                     }
                     else { }
                 }

                 if (hexstring5.Length > 2)
                 {
                     if (C1Operation5 == "/10")
                     {
                         string data = hexstring5;//數據5
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         data11 = data1.ToString();
                     }
                     else if (C1Operation5 == "/100")
                     {
                         string data = hexstring5;//數據5
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         data11 = data1.ToString();
                     }
                     else if (C1Operation5 == "x1")
                     {
                         string data = hexstring5;//數據5
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         data11 = data1.ToString();
                     }
                     else { }
                 }
                 if (hexstring6.Length > 2)
                 {
                     if (C1Operation6 == "/10")
                     {
                         string data = hexstring6;//數據6
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         data13 = data1.ToString();
                     }
                     else if (C1Operation6 == "/100")
                     {
                         string data = hexstring6;//數據6
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         data13 = data1.ToString();
                     }
                     else if (C1Operation6 == "x1")
                     {
                         string data = hexstring6;//數據6
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         data13 = data1.ToString();
                     }
                     else { }
                 }
                 if (hexstring7.Length > 2)
                 {
                     if (C1Operation7 == "/10")
                     {
                         string data = hexstring7;//數據7
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         data15 = data1.ToString();
                     }
                     else if (C1Operation7 == "/100")
                     {
                         string data = hexstring7;//數據7
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         data15 = data1.ToString();
                     }
                     else if (C1Operation7 == "x1")
                     {
                         string data = hexstring7;//數據7
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         data15 = data1.ToString();
                     }
                     else { }

                 }

                    DateTime C1time = DateTime.Now;
                    String c1time = C1time.ToString("yyyy-MM-dd HH:mm:ss");
                    this.BeginInvoke(new EventHandler(delegate
                   {
                       try
                       {
                           using (SqlConnection cn1 = new SqlConnection())
                           {
                               cn1.ConnectionString = cnstr;
                               cn1.Open();
                               string sqlstr = "INSERT INTO Command1data(數據1,數據2,數據3,數據4,數據5,數據6,數據7,時間)" + "VALUES(@C1data1,@C1data2,@C1data3,@C1data4,@C1data5,@C1data6,@C1data7,@C1time)";//傳資料進SQL
                              SqlCommand cmd = new SqlCommand(sqlstr, cn1);

                               cmd.Parameters.Add(new SqlParameter("@C1data1", SqlDbType.NVarChar));
                               cmd.Parameters.Add(new SqlParameter("@C1data2", SqlDbType.NVarChar));
                               cmd.Parameters.Add(new SqlParameter("@C1data3", SqlDbType.NVarChar));
                               cmd.Parameters.Add(new SqlParameter("@C1data4", SqlDbType.NVarChar));
                               cmd.Parameters.Add(new SqlParameter("@C1data5", SqlDbType.NVarChar));
                               cmd.Parameters.Add(new SqlParameter("@C1data6", SqlDbType.NVarChar));
                               cmd.Parameters.Add(new SqlParameter("@C1data7", SqlDbType.NVarChar));
                               cmd.Parameters.Add(new SqlParameter("@C1time", SqlDbType.NVarChar));

                               if (data2 == null)
                               { cmd.Parameters["@C1data1"].Value = DBNull.Value; }
                               else { cmd.Parameters["@C1data1"].Value = data2; }

                               if (data5 == null)
                               { cmd.Parameters["@C1data2"].Value = DBNull.Value; }
                               else { cmd.Parameters["@C1data2"].Value = data5; }

                               if (data7 == null)
                               { cmd.Parameters["@C1data3"].Value = DBNull.Value; }
                               else { cmd.Parameters["@C1data3"].Value = data7; }

                               if (data9 == null)
                               { cmd.Parameters["@C1data4"].Value = DBNull.Value; }
                               else { cmd.Parameters["@C1data4"].Value = data9; }

                               if (data11 == null)
                               { cmd.Parameters["@C1data5"].Value = DBNull.Value; }
                               else { cmd.Parameters["@C1data5"].Value = data11; }

                               if (data13 == null)
                               { cmd.Parameters["@C1data6"].Value = DBNull.Value; }
                               else { cmd.Parameters["@C1data6"].Value = data13; }

                               if (data15 == null)
                               { cmd.Parameters["@C1data7"].Value = DBNull.Value; }
                               else { cmd.Parameters["@C1data7"].Value = data15; }
                               cmd.Parameters["@C1time"].Value = c1time;
                               cmd.ExecuteNonQuery();
                           }
                       }
                       catch (Exception ex)
                       {
                           MessageBox.Show(ex.Message);
                       }

                   }));
                    Console.WriteLine("C1 conver OK");
                    Console.Write("\r\n");
                    // index++;
                    GC.Collect();
                   GC.WaitForPendingFinalizers();
                 }));
            }
        }
        private void AddContent1(string hexstring1, string hexstring2, string hexstring3, string hexstring4, string hexstring5, string hexstring6, string hexstring7)
        {
            if (i== 1 && C2add == 1)//C2
            {
                this.BeginInvoke(new MethodInvoker(delegate
             {
                 if (hexstring1.Length > 2)
                 {


                     if (C2Operation == "x1")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         C2data2 = data1.ToString();
                     }
                     else if (C2Operation == "x10")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 10;
                         C2data2 = data1.ToString();
                     }
                     else if (C2Operation == "x100")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 100;
                         C2data2 = data1.ToString();
                     }
                     else if (C2Operation == "x1000")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 1000;
                         C2data2 = data1.ToString();
                     }
                     else if (C2Operation == "x10000")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) * 10000;
                         C2data2 = data1.ToString();
                     }
                     else if (C2Operation == "/10")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         C2data2 = data1.ToString();
                     }
                     else if (C2Operation == "/100")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         C2data2 = data1.ToString("f2");
                     }
                     else if (C2Operation == "/1000")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) / 1000.000;
                         C2data2 = data1.ToString("f3");
                     }
                     else if (C2Operation == "/10000")
                     {
                         string data = hexstring1;//數據1
                         double data1 = Convert.ToInt32(data, 16) / 10000.0000;
                         C2data2 = data1.ToString("f4");
                     }
                     else { }
                 }
                 if (hexstring2.Length > 2)
                 {
                     if (C2Operation2 == "x1")
                     {
                         string data = hexstring2;//數據2                                              
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         C2data5 = data1.ToString();
                     }
                     else if (C2Operation2 == "x10")
                     {
                         string data = hexstring2;//數據2
                         double data1 = Convert.ToInt32(data, 16) * 10;
                         C2data5 = data1.ToString();
                     }
                     else if (C2Operation2 == "x100")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) * 100;
                         C2data5 = data2.ToString();
                     }
                     else if (C2Operation2 == "x1000")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) * 1000;
                         C2data5 = data2.ToString();
                     }
                     else if (C2Operation2 == "x10000")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) * 10000;
                         C2data5 = data2.ToString();
                     }
                     else if (C2Operation2 == "/10")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) / 10.0;
                         C2data5 = data2.ToString("f1");
                     }
                     else if (C2Operation2 == "/100")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) / 100.00;
                         C2data5 = data2.ToString("f2");
                     }
                     else if (C2Operation2 == "/1000")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) / 1000.000;
                         C2data5 = data2.ToString("f3");
                     }
                     else if (C2Operation2 == "/10000")
                     {
                         string data = hexstring2;//數據2
                         double data2 = Convert.ToInt32(data, 16) * 10000.0000;
                         C2data5 = data2.ToString("f4");
                     }
                     else { }
                 }

                 if (hexstring3.Length > 2)
                 {
                     if (C2Operation3 == "/10")
                     {
                         string data = hexstring3;//數據3
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         C2data7 = data1.ToString();
                     }
                     else if (C2Operation3 == "/100")
                     {
                         string data = hexstring3;//數據3
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         C2data7 = data1.ToString();
                     }
                     else if (C2Operation3 == "x1")
                     {
                         string data = hexstring3;//數據3
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         C2data7 = data1.ToString();
                     }
                     else { }
                 }
                 if (hexstring4.Length > 2)
                 {
                     if (C2Operation4 == "/10")
                     {
                         string data = hexstring4;//數據4
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         C2data9 = data1.ToString();
                     }
                     else if (C2Operation4 == "/100")
                     {
                         string data = hexstring4;//數據4
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         C2data9 = data1.ToString();
                     }
                     else if (C2Operation4 == "x1")
                     {
                         string data = hexstring4;//數據4
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         C2data9 = data1.ToString();
                     }
                     else { }
                 }

                 if (hexstring5.Length > 2)
                 {
                     if (C2Operation5 == "/10")
                     {
                         string data = hexstring5;//數據5
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         C2data11 = data1.ToString();
                     }
                     else if (C2Operation5 == "/100")
                     {
                         string data = hexstring5;//數據5
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         C2data11 = data1.ToString();
                     }
                     else if (C2Operation5 == "x1")
                     {
                         string data = hexstring5;//數據5
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         C2data11 = data1.ToString();
                     }
                     else { }
                 }
                 if (hexstring6.Length > 2)
                 {
                     if (C2Operation6 == "/10")
                     {
                         string data = hexstring6;//數據6
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         C2data13 = data1.ToString();
                     }
                     else if (C2Operation6 == "/100")
                     {
                         string data = hexstring6;//數據6
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         C2data13 = data1.ToString();
                     }
                     else if (C2Operation6 == "x1")
                     {
                         string data = hexstring6;//數據6
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         C2data13 = data1.ToString();
                     }
                     else { }
                 }
                 if (hexstring7.Length > 2)
                 {
                     if (C2Operation7 == "/10")
                     {
                         string data = hexstring7;//數據7
                         double data1 = Convert.ToInt32(data, 16) / 10.0;
                         C2data15 = data1.ToString();
                     }
                     else if (C2Operation7 == "/100")
                     {
                         string data = hexstring7;//數據7
                         double data1 = Convert.ToInt32(data, 16) / 100.00;
                         C2data15 = data1.ToString();
                     }
                     else if (C2Operation7 == "x1")
                     {
                         string data = hexstring7;//數據7
                         double data1 = Convert.ToInt32(data, 16) * 1;
                         C2data15 = data1.ToString();
                     }
                     else { }

                 }


               this.BeginInvoke(new EventHandler(delegate
                {
                 try
                 {
                     using (SqlConnection cn1 = new SqlConnection())
                     {
                         cn1.ConnectionString = cnstr;
                         cn1.Open();
                         string sqlstr = "INSERT INTO Command2data(數據1,數據2,數據3,數據4,數據5,數據6,數據7)" + "VALUES(@C2data1,@C2data2,@C2data3,@C2data4,@C2data5,@C2data6,@C2data7)";//傳資料進SQL

                         SqlCommand cmd1 = new SqlCommand(sqlstr, cn1);

                         cmd1.Parameters.Add(new SqlParameter("@C2data1", SqlDbType.NVarChar));
                        cmd1.Parameters.Add(new SqlParameter("@C2data2", SqlDbType.NVarChar));
                         cmd1.Parameters.Add(new SqlParameter("@C2data3", SqlDbType.NVarChar));
                         cmd1.Parameters.Add(new SqlParameter("@C2data4", SqlDbType.NVarChar));
                        cmd1.Parameters.Add(new SqlParameter("@C2data5", SqlDbType.NVarChar));
                         cmd1.Parameters.Add(new SqlParameter("@C2data6", SqlDbType.NVarChar));
                        cmd1.Parameters.Add(new SqlParameter("@C2data7", SqlDbType.NVarChar));

                      
                        
                            if (C2data2 == null)
                            { cmd1.Parameters["@C2data1"].Value = DBNull.Value; }
                            else { cmd1.Parameters["@C2data1"].Value = C2data2; }

                            if (C2data5 == null)
                            { cmd1.Parameters["@C2data2"].Value = DBNull.Value; }
                            else { cmd1.Parameters["@C2data2"].Value = C2data5; }

                            if (C2data7 == null)
                            { cmd1.Parameters["@C2data3"].Value = DBNull.Value; }
                            else { cmd1.Parameters["@C2data3"].Value = C2data7; }

                            if (C2data9 == null)
                            { cmd1.Parameters["@C2data4"].Value = DBNull.Value; }
                            else { cmd1.Parameters["@C2data4"].Value = C2data9; }

                            if (C2data11 == null)
                            { cmd1.Parameters["@C2data5"].Value = DBNull.Value; }
                            else { cmd1.Parameters["@C2data5"].Value = C2data11; }

                            if (C2data13 == null)
                            { cmd1.Parameters["@C2data6"].Value ="0"; }
                            else { cmd1.Parameters["@C2data6"].Value = C2data13; }

                            if (C2data15 == null)
                            { cmd1.Parameters["@C2data7"].Value = DBNull.Value; }
                            else { cmd1.Parameters["@C2data7"].Value = C2data15; }
                           
                         cmd1.ExecuteNonQuery();
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }

                 }));
                 Console.WriteLine("sql2 OK");
                 Console.Write("\r\n");
                 //  index++;
                 GC.Collect();
                 GC.WaitForPendingFinalizers();
             }));
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (myserialPort.IsOpen)
            {
                AutoSend = false;
                Form1.AutoSend = false;
                myserialPort.Close();
            }
            C1data1add = 0;
            C1data2add =0;
            C1data3add = 0;
            C1data4add = 0;
            C1data5add = 0;
            C1data6add = 0;
            C1data7add = 0;

            C2data1add = 0;
            C2data2add = 0;
            C2data3add = 0;
            C2data4add = 0;
            C2data5add = 0;
            C2data6add = 0;
            C2data7add = 0;
            Application.DoEvents();
            toolStripButton3.Enabled = true;
        }
    }
}
