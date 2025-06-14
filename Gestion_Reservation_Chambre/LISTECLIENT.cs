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
    public partial class LISTECLIENT : Form
    {
        SqlConnection cnx;
        SqlDataReader dr;
        public LISTECLIENT()
        {
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
  
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MENU mn = new MENU();
            mn.Show();
            this.Hide();
        }

        private void dataGridCLI_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Afficher_Click(object sender, EventArgs e)
        {
            cnx.Open();
            String sql = "select*from CLIENTS";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            dr = cmd.ExecuteReader();
            dataGridCLI.Columns.Clear();
            dataGridCLI.Rows.Clear();
            dataGridCLI.Columns.Add("Id","IdCli");
            dataGridCLI.Columns.Add("Nom", "Nom");
            dataGridCLI.Columns.Add("Prenom", "Prenom");
            dataGridCLI.Columns.Add("Phone", "Phone");
            dataGridCLI.Columns.Add("Adresse", "Adresse");
            dataGridCLI.Columns.Add("CIN", "CIN");
            dataGridCLI.Columns.Add("Nationalite", "Nationalite");
            dataGridCLI.Columns.Add("Sexe", "Sexe");

            int i = 0;
            while (dr.Read()) {
                dataGridCLI.Rows.Add();
                dataGridCLI.Rows[i].Cells[0].Value = dr["IdCli"];
                dataGridCLI.Rows[i].Cells[1].Value = dr["Nom"];
                dataGridCLI.Rows[i].Cells[2].Value = dr["Prenom"];
                dataGridCLI.Rows[i].Cells[3].Value = dr["Phone"];
                dataGridCLI.Rows[i].Cells[4].Value = dr["Adresse"];
                dataGridCLI.Rows[i].Cells[5].Value = dr["CIN"];
                dataGridCLI.Rows[i].Cells[6].Value = dr["Nationalite"];
                dataGridCLI.Rows[i].Cells[7].Value = dr["Sexe"];
                i++;
            
            }
            dr.Dispose();
            cnx.Close();
            
        }
    }
}
