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

namespace Gestion_Reservation_Chambre
{
    public partial class Receptionniste : Form
    {
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public Receptionniste()
        {
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
        }

        private void Receptionniste_Load(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("select*from RECEPTIONNISTE", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxCLIENT.Items.Add(dr[0].ToString());
            }
            dr.Dispose();
            cnx.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MENU mn = new MENU();
            mn.Show();
            this.Hide();
        }

        private void AjoutRec_Click(object sender, EventArgs e)
        {
            cnx.Open();
            String sql = "insert into RECEPTIONNISTE(IdRecep,NomRec,PrenomRec,PhoneRec,AdressRec,MatimRec) values('" + IDRec.Text + "','" + NomRec.Text + "','" + prenomRec.Text + "','" + phoneRec.Text + "','" + AddRec.Text + "','" + comboMatri.SelectedItem + "')";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Ajout reussi");
        }

        private void ListeRec_Click(object sender, EventArgs e)
        {
            LISTESRECEP cha = new LISTESRECEP();
            cha.Show();
            this.Hide();
        }

        private void comboBoxCLIENT_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("select*from RECEPTIONNISTE where IdRecep='" + comboBoxCLIENT.Text + "'", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            IDRec.Text = dr[0].ToString();
            NomRec.Text = dr[1].ToString();
            prenomRec.Text = dr[2].ToString();
            phoneRec.Text = dr[3].ToString();
            AddRec.Text = dr[4].ToString();
            comboMatri.SelectedItem = dr[5].ToString();
            cnx.Close();
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                string sql = "update RECEPTIONNISTE set IdRecep='" + IDRec.Text + "',NomRec='" + NomRec.Text + "',PrenomRec='" + prenomRec.Text + "',PhoneRec='" + phoneRec.Text + "',AdressRec='" + AddRec.Text + "',MatimRec='" + comboMatri.SelectedItem + "' where IdRecep='" + comboBoxCLIENT.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                IDRec.Text = "";
                NomRec.Text = "";
                prenomRec.Text = "";
                phoneRec.Text = "";
                AddRec.Text = "";
                MessageBox.Show("Modification reussite");
                cnx.Open();
                cmd = new SqlCommand("select*from RECEPTIONNISTE", cnx);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxCLIENT.Items.Add(dr[0].ToString());
                }
                dr.Dispose();
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                string sql = "delete from RECEPTIONNISTE where IdRecep='" + comboBoxCLIENT.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                IDRec.Text = "";
                NomRec.Text = "";
                prenomRec.Text = "";
                phoneRec.Text = "";
                AddRec.Text = "";
                comboMatri.Text = "";
                MessageBox.Show("Suppression reussite");
                // rechargement de la liste 
                comboBoxCLIENT.Items.Clear();
                cnx.Open();
                cmd = new SqlCommand("select*from RECEPTIONNISTE", cnx);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxCLIENT.Items.Add(dr[0].ToString());
                }
                dr.Dispose();
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
