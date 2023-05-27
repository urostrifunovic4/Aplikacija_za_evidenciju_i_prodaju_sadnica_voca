using BusinessLayer;
using DataAccessLayer.Models;
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
using System.Security.Cryptography;
using System.IO;

namespace PresentationLayer
{
    public partial class Kupac : Form
    {

        private readonly KupacBusiness kupacBusiness;


        public Kupac() 
        {
            this.kupacBusiness = new KupacBusiness();
            InitializeComponent();
            panelLeft.Height = buttonKupac.Height;
            panelLeft.Top = buttonKupac.Top;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxPass.PasswordChar = '●';
            textBoxUsername.Focus();

            textBoxUsername.Text = String.Empty;
            textBoxPass.Text = String.Empty;


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

            this.Hide();
            Admin a = new Admin();
            a.ShowDialog();
            this.Close();
        }

        private void buttonKupac_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonKupac.Height;
            panelLeft.Top = buttonKupac.Top;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            panelLeft.Height = buttonExit.Height;
            panelLeft.Top = buttonExit.Top;
            Thread.Sleep(800);
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // panelRight.Width = button2.Width;
           // panelRight.Left = button2.Right;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panelRight.Width = button1.Width;
           // panelRight.Left = button1.Right;

            this.Hide();
            KupacPrijava kp = new KupacPrijava();
            kp.ShowDialog();
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonReg_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(textBoxUsername.Text))
                errorProvider1.SetError(textBoxUsername, "Morate popuniti ovo polje!");
            else
                errorProvider1.SetError(textBoxUsername, String.Empty);

            //if (String.IsNullOrEmpty(textBoxPass.Text))
            //    errorProvider2.SetError(textBoxPass, "Morate popuniti ovo polje!");
           // else
             //   errorProvider2.SetError(textBoxPass, String.Empty);

            if (checkBox1.Checked==false)
                errorProvider3.SetError(checkBox1, "Morate prihvatiti podrazumevane uslove!");
            else
                errorProvider3.SetError(checkBox1, String.Empty);

            if (textBoxPass.Text.Length < 4)
                errorProvider4.SetError(textBoxPass, "Morate uneti najmanje 4 karaktera za lozinku!");
            else
                errorProvider4.SetError(textBoxPass, String.Empty);

           // if (textBoxPass.Text.Length < 4)
           //   MessageBox.Show("Morate uneti najmanje 4 karaktera za lozinku!");



            List<KupacKlasa> lista = this.kupacBusiness.GetAllKupac();

            KupacKlasa kupacc = new KupacKlasa();
            kupacc.korisnicko_ime = textBoxUsername.Text;
            //string loz = Convert.ToString(textBoxPass.Text);
            //string enk = Encrypt(loz);
            kupacc.lozinka = Encrypt3(textBoxPass.Text);
            //kupacc.lozinka = enk;
            

            KupacKlasa kuka = new KupacKlasa();

             foreach (KupacKlasa kup in lista)
                {
                    if (kup.korisnicko_ime.Equals(textBoxUsername.Text))
                  {
                      kuka = kup;
                      MessageBox.Show("Uneto korisničko ime postoji!");
                      break;
                  }
            }

            if (kuka.korisnicko_ime != textBoxUsername.Text && !String.IsNullOrEmpty(textBoxUsername.Text) && !String.IsNullOrEmpty(textBoxPass.Text) && textBoxPass.Text.Length>=4 && checkBox1.Checked==true)
            {

                this.kupacBusiness.InsertKupac(kupacc);
                MessageBox.Show("Uspešno ste registrovali nalog!");
                textBoxUsername.Text = "";
                textBoxPass.Text = "";
                checkBox1.Checked = false;
                textBoxUsername.Focus();
               // PrijavljenKupac pk = new PrijavljenKupac();
               // pk.textBoxBrojRacuna.Text = Convert.ToString(kuka.racun);
               // pk.textBoxStanje.Text = Convert.ToString(kuka.stanje);
                //break;
            }

           // if (String.IsNullOrEmpty(textBoxUsername.Text) || String.IsNullOrEmpty(textBoxPass.Text))
              //  return;


        }


        static string Encrypt(string value)
        {
            using(MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public static string Encrypt3(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBoxUsername_Validating(object sender, CancelEventArgs e)
        {
           /* if (String.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                e.Cancel = true;
                textBoxUsername.Focus();
                errorProvider1.SetError(textBoxUsername, "Morate popuniti ovo polje!");
            }
            if ( String.IsNullOrWhiteSpace(textBoxPass.Text))
            {
                e.Cancel = true;
                textBoxPass.Focus();
                errorProvider1.SetError(textBoxPass, "Morate popuniti ovo polje!");
            }
            else
            {
                e.Cancel = false;
                //errorProvider1.SetError(textBoxUsername, "");
            }*/
        }

        private void label5_Click(object sender, EventArgs e)
        {
            textBoxUsername.Clear();
            textBoxPass.Clear();
            checkBox1.Checked = false;
            textBoxUsername.Focus();
        }
    }
}

