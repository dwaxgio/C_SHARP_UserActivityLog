using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Net;

namespace UserActivityLog
{
    public partial class FrmActivity : Form
    {
        public FrmActivity()
        {
            InitializeComponent();
        }

        // Método que captura actividad cuando usuario clickea sobre botón
        private void button2_Click(object sender, EventArgs e)
        {
            string action = "Invoice Issued";
            Main code = new Main();
            code.Excecute(@"INSERT INTO User_Activity_Log VALUES ('" + Form1.username + "','" + Form1.EmpNo + "','" + DateTime.Now + "','" + action + "','" + Form1.CIP + "')");
        }

        // Método que captura actividad cuando usuario clickea sobre botón
        private void button1_Click(object sender, EventArgs e)
        {
            string action = "Exit Button Click";
            Main code = new Main();
            code.Excecute(@"INSERT INTO User_Activity_Log VALUES ('" + Form1.username + "','" + Form1.EmpNo + "','" + DateTime.Now + "','" + action + "','" + Form1.CIP + "')");
            Application.Exit();
        }
    }
}
