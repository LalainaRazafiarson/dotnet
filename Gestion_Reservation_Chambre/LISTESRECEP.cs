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
    public partial class LISTESRECEP : Form
    {
        SqlConnection cnx;
        SqlDataReader dr;
        public LISTESRECEP()
        {
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
        }

        private void Afficher_Click(object sender, EventArgs e)
        {
            cnx.Open();
            String sql = "select*from receptionniste";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            dr = cmd.ExecuteReader();
            dataGridREC.Columns.Clear();
            dataGridREC.Rows.Clear();
            dataGridREC.Columns.Add("Id","IdRecep");
            dataGridREC.Columns.Add("Nom", "NomRec");
            dataGridREC.Columns.Add("Prenom", "PrenomRec");
            dataGridREC.Columns.Add("Phone", "PhoneRec");
            dataGridREC.Columns.Add("Adresse", "AdressRec");
            dataGridREC.Columns.Add("Situation", "MatimRec");
 
            int i = 0;
            while (dr.Read()) {
                dataGridREC.Rows.Add();
                dataGridREC.Rows[i].Cells[0].Value = dr["IdRecep"];
                dataGridREC.Rows[i].Cells[1].Value = dr["NomRec"];
                dataGridREC.Rows[i].Cells[2].Value = dr["PrenomRec"];
                dataGridREC.Rows[i].Cells[3].Value = dr["PhoneRec"];
                dataGridREC.Rows[i].Cells[4].Value = dr["AdressRec"];
                dataGridREC.Rows[i].Cells[5].Value = dr["MatimRec"];
                i++;
            
            }
            dr.Dispose();
            cnx.Close();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MENU mn = new MENU();
            mn.Show();
            this.Hide();
        }

        private void dataGridREC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

