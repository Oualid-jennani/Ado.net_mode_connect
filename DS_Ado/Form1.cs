using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_Ado
{
    public partial class Form1 : Form
    {
        UserControl1 U1 = new UserControl1();
        UserControl2 U2 = new UserControl2();
        public Form1()
        {
            InitializeComponent();

            U2.TabStop = false;
            panel1.Controls.Add(U1);
            U2.Hide();
            U1.Show();
        }



        public void ShowTabCRUD()
        {
            U1.TabStop = false;
            panel1.Controls.Add(U2);
            U1.Hide();
            U2.Show();
        }
    }
}
