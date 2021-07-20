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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void btn_conex_Click(object sender, EventArgs e)
        {
            if (tb_nom.Text.Trim() != "" || tb_pass.Text.Trim() != "")
            {
                if (tb_nom.Text.Trim() == tb_pass.Text.Trim())
                {
                    Program.f.ShowTabCRUD();
                }
                else
                {
                    MessageBox.Show("Pas De Baqe Donnees", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("le nom de utilisateur ou le mote de passe incorecte !!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
