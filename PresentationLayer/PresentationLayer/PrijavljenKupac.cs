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
    public partial class PrijavljenKupac : Form
    {

        private readonly KupacBusiness kupacBusiness;
        private readonly VockaVrstaBusiness vockaVrstaBusiness;
        private readonly VockaBusiness vockaBusiness;
        private readonly UkupnoBusiness ukupnoBusiness;
        static readonly string textFile = "C:\\demo\\demo.txt";
        string text = File.ReadAllText(textFile);


        public int Variable { get; set; }
        public decimal Variable2  { get; set; }

        public int UkupnoVoca;
        public decimal UkupnoCena;

       // List<int> intidzeri;


        public PrijavljenKupac()
        {
            this.kupacBusiness = new KupacBusiness();
            this.vockaVrstaBusiness = new VockaVrstaBusiness();
            this.vockaBusiness = new VockaBusiness();
            this.ukupnoBusiness = new UkupnoBusiness();
            InitializeComponent();
            panelLeft.Height = buttonKupac.Height;
            panelLeft.Top = buttonKupac.Top;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Vocka_Vrsta> lista = this.vockaVrstaBusiness.GetAllVockaVrsta();
            dataGridView1.Rows.Clear();


            foreach (Vocka_Vrsta vv in lista)
            {
                dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena); //+ "din."  , vv.id_vocke
            }
            dataGridView1.Columns[0].Visible = false;

            Random rd = new Random();
            decimal rand_num = rd.Next(100, 10000);

            // textBoxStanje.Text = Convert.ToString(rand_num);
            // textBoxStanje.Text = Convert.ToString("1000.00");

            //KupacPrijava kp = new KupacPrijava();


            //  List<KupacKlasa> listaKupaca = this.kupacBusiness.GetAllKupac();

            // foreach(KupacKlasa kk in listaKupaca)

            //textBoxStanje.Text=Convert

            //Kupac kupac = new Kupac();
            //  kupac.buttonReg_Click(sender, e).
            if (String.IsNullOrEmpty(textBoxRacun.Text))
                buttonKupi.Enabled = false;
            else
                buttonKupi.Enabled = true;

            //List<int> broj;
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxId.Text = row.Cells["Id"].Value.ToString();
                textBoxNaziv.Text = row.Cells["Naziv"].Value.ToString();
                textBoxBrojGodina.Text = row.Cells["BrojGodina"].Value.ToString();
                textBoxKolicina.Text = row.Cells["Kolicina"].Value.ToString();
                int kolicina = Convert.ToInt32(textBoxKolicina.Text);
                textBoxCena.Text = row.Cells["Cena"].Value.ToString();
                decimal cena = Convert.ToDecimal(textBoxCena.Text);

                //  textBoxIdVocke.Text = row.Cells["IdVocke"].Value.ToString();
               // textBoxRacun.Text = Convert.ToString(kolicina * cena);

            }
        }

        private void buttonKupi_Click(object sender, EventArgs e)
        {
            

           // TextWriter txt = new StreamWriter("C:\\demo\\demo.txt");


           

            try
            {

                int kolicina2 = Convert.ToInt32(textBoxKolicina.Text);
                int id2 = Convert.ToInt32(textBoxId.Text);

                decimal cena2 = Convert.ToDecimal(textBoxStanje.Text);
                decimal cena3 = Convert.ToDecimal(textBoxRacun.Text);

                List<Vocka_Vrsta> lista = this.vockaVrstaBusiness.GetAllVockaVrsta();
                List<KupacKlasa> listaKupaca = this.kupacBusiness.GetAllKupac();
                List<Ukupno> ukupno = this.ukupnoBusiness.GetAll();

                if (cena3 > cena2)
                {
                    MessageBox.Show("Nemate dovoljno novca!");

                }
                else
                {
                   // DialogResult dialogResult = MessageBox.Show("Da li želite da potvrdite kupovinu?", MessageBoxButtons.YesNo);
                   // if (dialogResult == DialogResult.Yes)
                   // {
                        foreach (Vocka_Vrsta vv in lista)
                    {

                        if (vv.id == id2 && vv.kolicina >= kolicina2)
                        {
                            dataGridView1.Rows.Clear();
                            int nova_kolicina = vv.kolicina - kolicina2;
                            vv.kolicina = nova_kolicina;
                            // brojac = brojac + kolicina2;
                            // broj.Add()

                            //txt.Write(kolicina2+brojPotreban);
                           // txt.Close();
                            //Variable += kolicina2;
                            //Variable++;

                            dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena); //+ "din."
                            foreach (KupacKlasa kk in listaKupaca)
                                if (kk.racun == Convert.ToInt32(textBoxBrojRacuna.Text))
                                {
                                    decimal novo_stanje = cena2 - cena3;
                                    kk.stanje = novo_stanje;

                                    //Variable2 += cena3;


                                    this.kupacBusiness.UpdateKupac(kk);
                                    //break;
                                }

                            textBoxStanje.Text = Convert.ToString(cena2 - cena3);

                            this.vockaVrstaBusiness.UpdateVockaVrsta(vv);
                            textBoxRacun.Text = Convert.ToString(kolicina2 * vv.cena);
                            /* for (int i = 0; i < ukupno.Count; i++)
                             {
                                 this.ukupnoBusiness.Update();
                                 ukupno[0].kolicina = kolicina2;
                                 ukupno[0].cena = cena3;

                             }*/
                            int kolicina_ukupno=0;
                            decimal cena_ukupno = 0;
                           foreach(Ukupno uk in ukupno)
                            {
                                kolicina_ukupno += uk.kolicina;
                                cena_ukupno += uk.cena;
                            }
                            Ukupno u = new Ukupno();
                            u.kolicina = kolicina_ukupno + kolicina2;
                            u.cena = cena_ukupno + cena3;
                            this.ukupnoBusiness.Update(u);
                            MessageBox.Show("Uspešna kupovina! Čestitamo! Hvala Vam!");




                        }

                            //  Vocka_Vrsta novaV = vv;


                    

                    }
                    

                    //OVO DOLE DAL JE DOBRO TREBA DA UPISE U TABELU
                    /*   foreach (Ukupno u in ukupno)
                       {
                           // if (u.id == 1)
                           // {
                           u.kolicina += kolicina2;
                           u.cena += cena3;
                           //  }
                           //  else
                           //  {
                           //      MessageBox.Show("Nista!");
                           // }
                       }
                       for(int i = 0; i < ukupno.Count; i++)
                       {
                           ukupno[0].kolicina += kolicina2;
                           ukupno[0].cena += cena3;

                       }*/


                }

            }
            catch (Exception exe)
            {
                MessageBox.Show("Pogrešan format!");
            }

            // UkupnoVoca = Variable;
            // UkupnoVoca = kolicina2;
            // UkupnoCena = Variable2;

        }

        
       

        private void buttonRacun_Click(object sender, EventArgs e)
        {
            //int kolicina = Convert.ToInt32(textBoxKolicina.Text);
            // decimal cena = Convert.ToDecimal(textBoxCena.Text);
            //textBoxRacun.Text = Convert.ToString(kolicina * cena);

            try
            {
                decimal iznosUzet = Convert.ToDecimal(textBoxIznos.Text);
                DialogResult dialogResult = MessageBox.Show("Upravo se izvršava uplata sledećeg iznosa: " + iznosUzet + " din. na račun broj: " + textBoxBrojRacuna.Text + "\nDa li ste sigurni?", "Potvrda uplate", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    List<KupacKlasa> lista = this.kupacBusiness.GetAllKupac();
                    foreach (KupacKlasa kk in lista)
                        if (kk.racun == Convert.ToInt32(textBoxBrojRacuna.Text))
                        {
                            MessageBox.Show("Akcija je uspešna!");

                            decimal iznos = Convert.ToDecimal(textBoxIznos.Text);

                            decimal novo_stanje = kk.stanje + iznos;
                            kk.stanje = novo_stanje;
                            this.kupacBusiness.UpdateKupac(kk);
                            textBoxStanje.Text = Convert.ToString(kk.stanje);
                            textBoxIznos.Text = "";
                        }

                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Akcija je prekinuta!");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Pogrešan format!");
            }


            /*  List<KupacKlasa> lista = this.kupacBusiness.GetAllKupac();
              foreach(KupacKlasa kk in lista)
                  if(kk.racun == Convert.ToInt32(textBoxBrojRacuna.Text))
                  {
                      decimal iznos = Convert.ToDecimal(textBoxIznos.Text);
                      decimal novo_stanje = kk.stanje+iznos;
                      kk.stanje = novo_stanje;
                      this.kupacBusiness.UpdateKupac(kk);
                      textBoxStanje.Text = Convert.ToString(kk.stanje);
                  }*/

        }

        private void textBoxRacun_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(textBoxKolicina.Text) || String.IsNullOrEmpty(textBoxCena.Text))
                {

                }
                else
                {
                    int kolicina = Convert.ToInt32(textBoxKolicina.Text);
                    decimal cena = Convert.ToDecimal(textBoxCena.Text);

                    textBoxRacun.Text = Convert.ToString(kolicina * cena);
                    buttonKupi.Enabled = true;
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Pogrešan format!");
            }
        }

        private void buttonTrazi_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string voce = Convert.ToString(comboBox1.SelectedItem);
           // MessageBox.Show(voce);
            List<Vocka> lista = this.vockaBusiness.GetAllVocka();
            List<Vocka_Vrsta> list = this.vockaVrstaBusiness.GetAllVockaVrsta();
            foreach (Vocka v in lista)
            {
                if (v.naziv==voce)
                {
                    int id = v.id;
                    foreach (Vocka_Vrsta vv in list)
                    {
                        if (vv.id_vocke == id)
                        {
                            dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena);
                            dataGridView1.Columns[0].Visible = false;

                        }
                        //else
                        //{
                           // dataGridView1.Rows.Clear();

                       // }
                    }

                }

                // dataGridView1.Rows.Clear();

            }


            if (voce.Equals("Sve"))
            {

                dataGridView1.Rows.Clear();
                //int id = v.id;
                foreach (Vocka_Vrsta vv in list)
                //if(vv.id_kupca!=id)
                {
                    //dataGridView1.Rows.Clear();
                    dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena);
                     //break;

                }

            }





        }

        private void buttonKupi_Enter(object sender, EventArgs e)
        {
           // buttonKupi.BackColor = Color.Red;
           // buttonKupi.ForeColor = Color.White;
        }

        private void buttonKupi_Leave(object sender, EventArgs e)
        {
            //buttonKupi.BackColor = Color.White;
            //buttonKupi.ForeColor = Color.Red;
        }

        private void buttonKupi_MouseHover(object sender, EventArgs e)
        {
            buttonKupi.BackColor = Color.Red;
            buttonKupi.ForeColor = Color.White;
        }

        private void buttonKupi_MouseLeave(object sender, EventArgs e)
        {
            buttonKupi.BackColor = Color.White;
            buttonKupi.ForeColor = Color.Red;
        }

        private void buttonUplata_MouseEnter(object sender, EventArgs e)
        {
            buttonUplata.BackColor = Color.White;
            //buttonUplata.ForeColor = Color.White;
        }

        private void buttonUplata_MouseHover(object sender, EventArgs e)
        {
            buttonUplata.BackColor = Color.Red;
            buttonUplata.ForeColor = Color.White;
        }

        private void buttonUplata_MouseLeave(object sender, EventArgs e)
        {
            buttonUplata.BackColor = Color.White;
            buttonUplata.ForeColor = Color.Red;
        }

        private void buttonTrazi_MouseHover(object sender, EventArgs e)
        {
            buttonTrazi.BackColor = Color.Red;
            buttonTrazi.ForeColor = Color.White;
        }

        private void buttonTrazi_MouseLeave(object sender, EventArgs e)
        {
            buttonTrazi.BackColor = Color.White;
            buttonTrazi.ForeColor = Color.Red;
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pažljivo pročitati uputstvo!\nKlikom na bilo koje polje, biće prikazane sve potrebne informacije o željenoj sadnici voća. Potrebno je uneti (promeniti) željenu količinu, a nakon toga kliknuti na tekst ,,Vaš račun je''. Time će biti popunjeno polje pored i videćete iznos Vašeg računa. Nakon toga biće omogućeno dugme Kupi za kupovinu. Ukoliko nemate dovoljno novca na svom računu, možete uplatiti novac unosom željene cifre, a zatim kliknuti na dugme Uplati novac. Izborom odgovarajuće vrste voća iz padajućeg menija i klikom na dugme Traži, biće prikazana samo izabrana vrsta voća.");
        }
    }

      

     

    





}

