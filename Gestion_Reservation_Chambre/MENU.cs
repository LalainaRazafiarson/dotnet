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
    public partial class MENU : Form
    {
        SqlConnection cnx;
        SqlDataReader dr;
        SqlCommand cmd;
        public MENU()
        {
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
        
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) // JOUT CLIENT
        {
            CLIENT cl = new CLIENT();
            cl.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            LISTESRESERVATION res = new LISTESRESERVATION();
            res.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receptionniste rcp = new Receptionniste();
            rcp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CHAMBRE ch = new CHAMBRE();
            ch.Show();
            this.Hide();
        }

        private void Reservation_Click(object sender, EventArgs e)
        {
            RESERVATION rsv = new RESERVATION();
            rsv.Show();
            this.Hide();
        }

        private void ListeClient_Click(object sender, EventArgs e)
        {
            LISTECLIENT cli = new LISTECLIENT();
            cli.Show();
            this.Hide();
        }

        private void recepListe_Click(object sender, EventArgs e)
        {
            LISTESRECEP lstR = new LISTESRECEP();
            lstR.Show();
            this.Hide();
        }

        private void ListeChambre_Click(object sender, EventArgs e)
        {
            LISTECHAMBRE cha = new LISTECHAMBRE();
            cha.Show();
            this.Hide();
        }

        private void MENU_Load(object sender, EventArgs e)
        {
            cnx.Open();
            String sql = "select count(IdCli) from RESERVER";
            cmd = new SqlCommand(sql, cnx);

            Int32 compte = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            cnx.Close();

            Encours.Text = compte.ToString();


            try
            {
                cnx.Open();
                cmd = new SqlCommand("select*from CLIENTS", cnx);
                dr = cmd.ExecuteReader();
                this.EtatReservation.Series.Clear();
                this.EtatReservation.Series.Add("Serie 1");
                while (dr.Read())
                {
                    this.EtatReservation.Series["Serie 1"].Points.AddXY(dr[1].ToString(), dr[3].ToString());
                }
                dr.Dispose();
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
