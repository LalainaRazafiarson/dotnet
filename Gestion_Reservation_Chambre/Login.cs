using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Reservation_Chambre
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void btnLOG_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Bosco" && txtPassword.Text == "1234")
            {
                MENU mn = new MENU();
                mn.Show();
                this.Hide();
            }
            else if (txtPassword.Text != "passroot"){
                MessageBox.Show("Mot de passe incorrect");
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            else if (txtUser.Text != "LGS MADA")
            {
                MessageBox.Show("Utilisateur incorrect");
                txtUser.Text = "";
                txtUser.Focus();
            }
            else { }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
