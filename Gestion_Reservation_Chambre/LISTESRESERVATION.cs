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
    public partial class LISTESRESERVATION : Form
    {
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataReader dr;
        public LISTESRESERVATION()
        {
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
        
        }

        private void afficher_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("select*from RESERVER", cnx);
            dr = cmd.ExecuteReader();
            dataGridViewRES.Columns.Clear();
            dataGridViewRES.Rows.Clear();
            dataGridViewRES.Columns.Add("IdCli", "IdCli");
            dataGridViewRES.Columns.Add("NumCha", "NumCha");
            dataGridViewRES.Columns.Add("Debut ", "Debut");
            dataGridViewRES.Columns.Add("Fin", "Fin");

            int i = 0;
            while (dr.Read())
            {
                dataGridViewRES.Rows.Add();
                dataGridViewRES.Rows[i].Cells[0].Value = dr["IdCli"];
                dataGridViewRES.Rows[i].Cells[1].Value = dr["NumCha"];
                dataGridViewRES.Rows[i].Cells[2].Value = dr["Debut"];
                dataGridViewRES.Rows[i].Cells[3].Value = dr["Fin"];
                i = i + 1;
            }
            dr.Dispose();
            cnx.Close();
        }

        private void affDia_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                cmd = new SqlCommand("select*from Clients", cnx);
                dr = cmd.ExecuteReader();
                this.chartRes.Series.Clear();
                this.chartRes.Series.Add("Serie 1");
                while (dr.Read())
                {
                    this.chartRes.Series["Serie 1"].Points.AddXY(dr[1].ToString(), dr[3].ToString());
                }
                dr.Dispose();
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MENU mn = new MENU();
            mn.Show();
            this.Hide();
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("delete from RESERVER where NumCha = ", cnx);
            dr = cmd.ExecuteReader();
            cnx.Close();
            MessageBox.Show("Reservation annuler");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
