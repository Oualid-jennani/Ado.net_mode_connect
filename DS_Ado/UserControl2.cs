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

namespace DS_Ado
{
    public partial class UserControl2 : UserControl
    {
        SqlConnection cn;
        public UserControl2()
        {
            InitializeComponent();
            cn = new SqlConnection(@"Server = .\SQLEXPRESS; DataBase = DS_Ado; Integrated Security = true");
            Load_Data();
        }

        void Load_Data()
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from TableLycee", cn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }





        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (txtNom.Text.Trim() != "" || txtNbrPlaces.Text.Trim() != "")
            {
                try
                {
                    cn.Open();
                    string rqt = "insert into TableLycee values(@nom,@nbrplaces)";

                    SqlParameter p1 = new SqlParameter("@nom", txtNom.Text);
                    SqlParameter p2 = new SqlParameter("@nbrplaces", int.Parse(txtNbrPlaces.Text));

                    SqlCommand com = new SqlCommand(rqt, cn);
                    com.Parameters.Add(p1);
                    com.Parameters.Add(p2);
                    com.ExecuteNonQuery();
                    cn.Close();
                    Load_Data();

                }
                catch (Exception ve)
                {
                    MessageBox.Show(ve.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                MessageBox.Show("incorecte !!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (txtNom.Text.Trim() != "" || txtNbrPlaces.Text.Trim() != "")
            {
                try
                {
                    cn.Open();

                    int id = int.Parse(txtId.Text.Trim());
                    string rqt = "update TableLycee set nom = @nom, nbrplaces = @nbrplaces where id = " + id + "";

                    SqlParameter p1 = new SqlParameter("@nom", txtNom.Text);
                    SqlParameter p2 = new SqlParameter("@nbrplaces", int.Parse(txtNbrPlaces.Text));

                    SqlCommand com = new SqlCommand(rqt, cn);
                    com.Parameters.Add(p1);
                    com.Parameters.Add(p2);
                    com.ExecuteNonQuery();
                    cn.Close();

                    Load_Data();

                }
                catch (Exception ve)
                {
                    MessageBox.Show(ve.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                MessageBox.Show("incorecte !!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                DialogResult Rez = MessageBox.Show("Delete Confermation .... ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Rez == DialogResult.Yes)
                {

                    try
                    {

                        cn.Open();
                        SqlCommand com = new SqlCommand("delete from TableLycee where id = " + id + "", cn);

                        com.ExecuteReader();

                        cn.Close();

                        Load_Data();
                    }
                    catch (Exception ve)
                    {
                        MessageBox.Show(ve.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }

                }

            }
        }

        private void btnLister_Click(object sender, EventArgs e)
        {
            Program.f.Close();
        }



        int i = -1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i = 0;
                dataGridView1.Rows[i].Selected = true;
                ChangeNavigation();
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i--;
            dataGridView1.Rows[i].Selected = true;
            ChangeNavigation();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (i < dataGridView1.Rows.Count - 1)
            {
                i++;
                dataGridView1.Rows[i].Selected = true;
                ChangeNavigation();
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i = dataGridView1.Rows.Count - 1;
            dataGridView1.Rows[i].Selected = true;
            ChangeNavigation();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ChangeNavigation();
        }


        public void ChangeNavigation()
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNom.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtNbrPlaces.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }
    }
}
