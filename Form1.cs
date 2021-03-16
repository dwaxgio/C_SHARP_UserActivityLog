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
using System.Data;
using System.Net;

namespace UserActivityLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string CIP = "prueba";
        public static string EmpNo = "1";
        public static string username = "1";

        SqlConnection connection = Main.GetConnection();

        private void getIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    CIP = ip.ToString();
                }
            }
            lblCP.Text = CIP;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getIP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtusername.Text == ""))
            {
                MessageBox.Show("Please enter your username");
            }
            else if ((txtpassword.Text == ""))
            {
                MessageBox.Show("Please enter your password");
            }
            else
            {
                string Login = "login";
                Main code = new Main();
                string SqlEmpNo = "SELECT EmployeeNo FROM Login WHERE Username = '" + Convert.ToString(txtusername.Text) + "' AND Password = '" + Convert.ToString(txtpassword.Text) + "'";
                EmpNo = code.Converter_string(SqlEmpNo).ToString();
                if (EmpNo != "")
                {
                    string SqlLoginName = "SELECT Username FROM Login WHERE EmployeeNo = '" + Convert.ToString(EmpNo) + "'";
                    username = code.Converter_string(SqlLoginName).ToString();
                    //code.Excecute(@"INSERT INTO User_Activity_Log VALUES ('" + Convert.ToString(txtusername.Text) + "','" + EmpNo + "','" + DateTime.Now + "','" + Login + "','" + CIP + "')");
                    code.Excecute(@"INSERT INTO User_Activity_Log VALUES ('" + Convert.ToString(txtusername.Text) + "','" + EmpNo + "','" + DateTime.Now + "','" + Login + "','" + CIP + "')");
                    //code.Excecute(@"INSERT INTO dbo.User_Activity_Log VALUES ('','','','',''");

                    FrmActivity frmmain = new FrmActivity();
                    frmmain.WindowState = FormWindowState.Maximized;
                    this.Hide();
                    frmmain.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                    txtpassword.Text = "";
                }
            }
        }
    }
}
