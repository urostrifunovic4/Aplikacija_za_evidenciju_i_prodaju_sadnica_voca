using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {

        private readonly KupacBusiness kupacBusiness;


        public Form1()
        {
            InitializeComponent();
            panelLeft.Height = buttonPocetna.Height;
            panelLeft.Top = buttonPocetna.Top;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonPocetna_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonPocetna.Height;
            panelLeft.Top = buttonPocetna.Top;
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonAdmin.Height;
            panelLeft.Top = buttonAdmin.Top;
            //Thread.Sleep(800);
            this.Hide();
            Admin a = new Admin();
            a.ShowDialog();
            this.Close(); 
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dobrodošli u aplikaciju koja je namenjena prodaji sadnica voća! Sastoji se iz 2 dela: za administratora i za kupca. Ukoliko ste administrator kliknite na karticu Admin i prijavite se kako biste otvorili Vaš panel. Ukoliko ste kupac kliknite na karticu Kupac. Ukoliko nemate nalog, možete ga kreirati. Nakon kreiranja naloga ulogujte se na sopstveni nalog i pogledajte našu ponudu. Uživajte!");
        }
    }
}
