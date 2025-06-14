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
    public partial class CHAMBRE : Form
    {
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public CHAMBRE()
        {
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            String sql = "insert into CHAMBRE(NumCha,Etage,TypeCha,PhoneCha,CodeCat,CodeHot) values('" + NumCha.Text + "','" + comboEtage.SelectedItem + "','" + TypeCha.Text + "','" + phoneCha.Text + "','" + CategorieCha.Text + "','" + CodeHot.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Ajout reussi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MENU mn = new MENU();
            mn.Show();
            this.Hide();
        }

        private void ListeChambre_Click(object sender, EventArgs e)
        {
            LISTECHAMBRE cha = new LISTECHAMBRE();
            cha.Show();
            this.Hide();
        }

        private void comboBoxCLIENT_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("select*from CHAMBRE where NumCha='" + comboBoxCHA.Text + "'", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            NumCha.Text = dr[0].ToString();
            comboEtage.Text = dr[1].ToString();
            TypeCha.Text = dr[2].ToString();
            phoneCha.Text = dr[3].ToString();
            CategorieCha.Text = dr[4].ToString();
            CodeHot.Text = dr[5].ToString();
            cnx.Close();
        }

        private void CHAMBRE_Load(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("select*from CHAMBRE", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxCHA.Items.Add(dr[0].ToString());
            }
            dr.Dispose();
            cnx.Close();
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                string sql = "update CHAMBRE set NumCha='" + NumCha.Text + "',Etage='" + comboEtage.Text + "',TypeCha='" + TypeCha.Text + "',PhoneCha='" + phoneCha.Text + "',CodeCat='" + CategorieCha.Text + "',CodeHot='" + CodeHot.Text + "' where NumCha='" + comboBoxCHA.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                NumCha.Text = "";
                comboEtage.Text = "";
                TypeCha.Text = "";
                phoneCha.Text = "";
                CategorieCha.Text = "";
                CodeHot.Text = "";

                MessageBox.Show("Modification reussite");
                cnx.Open();
                cmd = new SqlCommand("select*from CHAMBRE", cnx);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxCHA.Items.Add(dr[0].ToString());
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
                string sql = "delete from CHAMBRE where NumCha='" + comboBoxCHA.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                NumCha.Text = "";
                comboEtage.Text = "";
                TypeCha.Text = "";
                phoneCha.Text = "";
                CategorieCha.Text = "";
                CodeHot.Text = "";
                MessageBox.Show("Suppression reussite");
                // rechargement de la liste 
                comboBoxCHA.Items.Clear();
                cnx.Open();
                cmd = new SqlCommand("select*from CHAMBRE", cnx);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxCHA.Items.Add(dr[0].ToString());
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
