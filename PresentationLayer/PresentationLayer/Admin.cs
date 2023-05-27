using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{



    public partial class Admin : Form
    {
        private readonly KupacBusiness kupacBusiness;



        public Admin()
        {
            InitializeComponent();
            panelLeft.Height = buttonAdmin.Height;
            panelLeft.Top = buttonAdmin.Top;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
            textBoxPassword.PasswordChar = '●';
            textBoxUsername.MaxLength = 12;
            textBoxPassword.MaxLength = 12;

        }

        private void buttonPocetna_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonPocetna.Height;
            panelLeft.Top = buttonPocetna.Top;

            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonAdmin.Height;
            panelLeft.Top = buttonAdmin.Top;
        }

        private void buttonKupac_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonKupac.Height;
            panelLeft.Top = buttonKupac.Top;

            this.Hide();
            Kupac k = new Kupac();
            k.ShowDialog();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonExit.Height;
            panelLeft.Top = buttonExit.Top;
            Thread.Sleep(800);
            this.Hide();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string pass = textBoxPassword.Text;


            if(String.IsNullOrEmpty(textBoxUsername.Text) || String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Morate popuniti sva polja!");
            }
            else if(username.Equals("admin") && pass.Equals("admin"))
            {
                this.Hide();
                AdminControl ac = new AdminControl();
                ac.ShowDialog();
                this.Close();     
            }
            else { 
            
                MessageBox.Show("Pogrešno korisničko ime ili lozinka!");
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                textBoxUsername.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxUsername.Focus();

        }
    }
}
