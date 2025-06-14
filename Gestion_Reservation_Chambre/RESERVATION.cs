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
    public partial class RESERVATION : Form
    {
        SqlConnection cnx;
        public RESERVATION()
        {
            InitializeComponent();
            cnx = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Ronie\Downloads\Programs\C#\C#\Gestion_Reservation_Chambre\Gestion_Reservation_Chambre\HOTEL.mdf;Integrated Security=True");
        
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MENU mn = new MENU();
            mn.Show();
            this.Hide();
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            cnx.Open();
            String sql = "insert into RESERVER(IdCli,NumCha,Debut,Fin) values('" + numCLI.Text + "','" + NumCha.Text + "','" +this.dateDebut.Text+ "','" +this.fin.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Reserver");

        }

        private void Duree_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Duree_Enter(object sender, EventArgs e)
        {
            DateTime deb = dateDebut.Value.Date;
            DateTime end = fin.Value.Date;
            TimeSpan dur = end - deb;

            int days = dur.Days;
            if (days < 0) {
                MessageBox.Show("Error");
                numCLI.Text = "";
                NumCha.Text = "";
                dateDebut.Text = "";
                fin.Text="";
                Duree.Text = "";
            }
            Duree.Text = days.ToString();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("TICKET RESERVATION", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(400, 140));
            e.Graphics.DrawString("Client Numero : "+numCLI.Text, new Font("monospace", 9, FontStyle.Bold), Brushes.Black, new Point(100, 80));
            e.Graphics.DrawString("Chambre Numero : "+NumCha.Text, new Font("monospace", 9, FontStyle.Bold), Brushes.Black, new Point(100, 100));
            e.Graphics.DrawString("Debut Reservation : "+this.dateDebut.Text, new Font("monospace", 10, FontStyle.Bold), Brushes.Black, new Point(100, 140));
            e.Graphics.DrawString("Fin Reservation : "+this.fin.Text, new Font("monospace", 10, FontStyle.Bold), Brushes.Black, new Point(100, 170));
            e.Graphics.DrawString("Duree Reservation : "+Duree.Text, new Font("monospace", 10, FontStyle.Bold), Brushes.Black, new Point(100, 200));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------", new Font("monospace", 20, FontStyle.Bold), Brushes.Black, new Point(10, 250));

        }

        private void btnTiquet_Click(object sender, EventArgs e)
        {
            PrintDialog printdialog1 = new PrintDialog();

            printdialog1.Document = printDocument1;

            DialogResult res = printdialog1.ShowDialog();

            if(res == DialogResult.OK){
                printDocument1.Print();
            } 
        }

        private void numCLI_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void NumCha_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void RESERVATION_Load(object sender, EventArgs e)
        {

        }
    }
}
