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
    public partial class CLIENT : Form
    {
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public CLIENT()
        {
            
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CLIENT_Load(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("select*from CLIENTS", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxCLIENT.Items.Add(dr[0].ToString());
            }
            dr.Dispose();
            cnx.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AjoutCLI_Click(object sender, EventArgs e)
        {
            cnx.Open();
            String sql = "insert into CLIENTS(IdCli,Nom,Prenom,Phone,Adresse,CIN,Nationalite,Sexe) values('"+IDClient.Text+"','"+NomCli.Text+"','"+PrenomCli.Text+"','"+PhoneCli.Text+"','"+AdresseCli.Text+"','"+CINCLI.Text+"','"+Nationalite.Text+"','"+comboSexe.SelectedItem+"')";
            SqlCommand cmd = new SqlCommand(sql,cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Ajout reussi");
        }

        private void comboBoxSEXE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTOMENU_Click(object sender, EventArgs e)
        {
            MENU mn = new MENU();
            mn.Show();
            this.Hide();
        }

        private void BTNListe_Click(object sender, EventArgs e)
        {
            LISTECLIENT cli = new LISTECLIENT();
            cli.Show();
            this.Hide();
        }

        private void comboBoxCLIENT_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("select*from CLIENTS where IdCli='" + comboBoxCLIENT.Text + "'", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            IDClient.Text = dr[0].ToString();
            NomCli.Text = dr[1].ToString();
            PrenomCli.Text = dr[2].ToString();
            PhoneCli.Text = dr[3].ToString();
            AdresseCli.Text = dr[4].ToString();
            CINCLI.Text = dr[5].ToString();
            Nationalite.Text = dr[6].ToString();
            comboSexe.SelectedItem = dr[7].ToString();
            cnx.Close();
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                string sql = "update CLIENTS set IdCli='" + IDClient.Text + "',Nom='" + NomCli.Text + "',Prenom='" + PrenomCli.Text + "',Phone='" + PhoneCli.Text + "',Adresse='" + AdresseCli.Text + "',CIN='" + CINCLI.Text + "',Nationalite='" + Nationalite.Text + "',Sexe='" + comboSexe.SelectedItem + "' where IdCli='" + comboBoxCLIENT.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                IDClient.Text = "";
                NomCli.Text = "";
                PrenomCli.Text = "";
                CINCLI.Text = "";
                PhoneCli.Text = "";
                AdresseCli.Text = "";
                Nationalite.Text = "";
                comboSexe.Text = "";
                MessageBox.Show("Modification reussite");
                cnx.Open();
                cmd = new SqlCommand("select*from CLIENTS", cnx);
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
                string sql = "delete from CLIENTS where IdCli='" + comboBoxCLIENT.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                IDClient.Text = "";
                NomCli.Text = "";
                PrenomCli.Text = "";
                CINCLI.Text = "";
                PhoneCli.Text = "";
                AdresseCli.Text = "";
                Nationalite.Text = "";
                comboSexe.Text = "";
                MessageBox.Show("Suppression reussite");
                // rechargement de la liste 
                comboBoxCLIENT.Items.Clear();
                cnx.Open();
                cmd = new SqlCommand("select*from CLIENTS", cnx);
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

        private void IDClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void IDClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void NomCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void PrenomCli_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrenomCli_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void PhoneCli_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void AdresseCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void CINCLI_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Nationalite_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
