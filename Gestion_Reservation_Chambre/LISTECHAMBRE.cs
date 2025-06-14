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
    public partial class LISTECHAMBRE : Form
    {
        SqlConnection cnx;
        SqlDataReader dr;
        public LISTECHAMBRE()
        {
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
       
        }

        private void Afficher_Click(object sender, EventArgs e)
        {
            cnx.Open();
            String sql = "select*from CHAMBRE";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            dr = cmd.ExecuteReader();
            dataGridCHAMBRE.Columns.Clear();
            dataGridCHAMBRE.Rows.Clear();
            dataGridCHAMBRE.Columns.Add("Numero","NumCha");
            dataGridCHAMBRE.Columns.Add("Etage", "Etage");
            dataGridCHAMBRE.Columns.Add("Type", "TypeCha");
            dataGridCHAMBRE.Columns.Add("Phone", "PhoneCha");
            dataGridCHAMBRE.Columns.Add("Categorie", "CodeCat");
            dataGridCHAMBRE.Columns.Add("HOTEL", "CodeHot");
 
            int i = 0;
            while (dr.Read()) {
                dataGridCHAMBRE.Rows.Add();
                dataGridCHAMBRE.Rows[i].Cells[0].Value = dr["NumCha"];
                dataGridCHAMBRE.Rows[i].Cells[1].Value = dr["Etage"];
                dataGridCHAMBRE.Rows[i].Cells[2].Value = dr["TypeCha"];
                dataGridCHAMBRE.Rows[i].Cells[3].Value = dr["PhoneCha"];
                dataGridCHAMBRE.Rows[i].Cells[4].Value = dr["CodeCat"];
                dataGridCHAMBRE.Rows[i].Cells[5].Value = dr["CodeHot"];
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

        private void dataGridCHAMBRE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }
}
