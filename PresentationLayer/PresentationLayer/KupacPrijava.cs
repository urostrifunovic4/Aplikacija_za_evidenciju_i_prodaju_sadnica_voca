using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class KupacPrijava : Form
    {

        private readonly KupacBusiness kupacBusiness;


        public KupacPrijava()
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

            this.Hide();
            Kupac kupacForma = new Kupac();
            kupacForma.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // panelRight.Width = button1.Width;
            //panelRight.Left = button1.Right;
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

            if (String.IsNullOrEmpty(textBoxPass.Text))
                errorProvider2.SetError(textBoxPass, "Morate popuniti ovo polje!");
            else
                errorProvider2.SetError(textBoxPass, String.Empty);


            List<KupacKlasa> lista = this.kupacBusiness.GetAllKupac();
            KupacKlasa kupacc = new KupacKlasa();

            foreach (KupacKlasa ku in lista)
            {
                if (ku.korisnicko_ime.Equals(textBoxUsername.Text) && Decrypt3(ku.lozinka)==textBoxPass.Text) //ku.lozinka.Equals(textBoxPass.Text)
                {
                    kupacc = ku;
                    break;
                }
                
            }

            if(kupacc.korisnicko_ime==textBoxUsername.Text && Decrypt3(kupacc.lozinka)==textBoxPass.Text)
            {
                MessageBox.Show("Uspešna prijava!");
                
                this.Hide();
                PrijavljenKupac pku = new PrijavljenKupac();
                //int racun = kupacc.racun;
                //decimal stanje = kupacc.stanje;
                pku.textBoxBrojRacuna.Text = Convert.ToString(kupacc.racun);
                pku.textBoxStanje.Text = Convert.ToString(kupacc.stanje);
                //PrijavljenKupac pk = new PrijavljenKupac();
                pku.ShowDialog();
                this.Close();

            }
            else
            {
                textBoxUsername.Text = "";
                textBoxPass.Text = "";
                MessageBox.Show("Neuspešna prijava!");
                textBoxUsername.Focus();
                //break;
            }


            // KupacKlasa novi = kupacc;
            //PrijavljenKupac pk = new PrijavljenKupac();
            // pk.text

        }

      //  public void GetKupac(KupacKlasa kupac)
       // {
       //     kupac = novi;
      //  }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxUsername_Validating(object sender, CancelEventArgs e)
        {
           
        }

        static string Decrypt(string value)
        {
            using (TripleDESCryptoServiceProvider Tdecript = new TripleDESCryptoServiceProvider())
            {

                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] DataToDecrypt = Convert.FromBase64String(value);
                return utf8.GetString(DataToDecrypt);
            }
        }

    

        public static string Decrypt3(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return cipherText;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            textBoxUsername.Clear();
            textBoxPass.Clear();
            textBoxUsername.Focus();
        }
    }
}

