using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class AdminControl : Form
    {
        private readonly KupacBusiness kupacBusiness;
        private readonly VockaVrstaBusiness vockaVrstaBusiness;
        private readonly VockaBusiness vockaBusiness;
        private readonly UkupnoBusiness ukupnoBusiness;

        

        public AdminControl()
        {
            this.kupacBusiness = new KupacBusiness();
            this.vockaVrstaBusiness = new VockaVrstaBusiness();
            this.vockaBusiness = new VockaBusiness();
            this.ukupnoBusiness = new UkupnoBusiness();
            InitializeComponent();
            panelLeft.Height = buttonAdmin.Height;
            panelLeft.Top = buttonAdmin.Top;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Vocka_Vrsta> lista = this.vockaVrstaBusiness.GetAllVockaVrsta();
            dataGridView1.Rows.Clear();

            // con.Open();
            // cmd = new SqlCommand();

            //dataGridView1.DataSource = lista;

            

            foreach(Vocka_Vrsta vv in lista)
            {
                dataGridView1.Rows.Add(vv.id,vv.naziv,vv.broj_godina,vv.kolicina,vv.cena,vockaBusiness.GetNaziv(vv.id_vocke),vv.id_vocke); //+ "din."
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;


            List<Vocka> listaV = this.vockaBusiness.GetAllVocka();

            foreach(Vocka v in listaV)
            {
                dataGridView2.Rows.Add(v.id, v.naziv);
            }

            List<Ukupno> ukupno = this.ukupnoBusiness.GetAll();


            foreach(Ukupno ukup in ukupno)
            {
                textBoxUkupnoVoca.Text = Convert.ToString(ukup.kolicina);
                textBoxUkupnoCena.Text = Convert.ToString(ukup.cena);

            }

            // PrijavljenKupac pk = new PrijavljenKupac();
            //textBoxUkupnoVoca.Text = Convert.ToString(pk.UkupnoVoca);
            //textBoxUkupnoCena.Text = Convert.ToString(pk.UkupnoCena);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

           /* try
            {
                var selectedVoce = dataGridView1.SelectedRows[0].DataBoundItem as Vocka_Vrsta;
                textBoxNaziv.Text = selectedVoce.naziv;
                textBoxBrojGodina.Text = selectedVoce.broj_godina.ToString();
                textBoxKolicina.Text = selectedVoce.kolicina.ToString();
                textBoxCena.Text = selectedVoce.cena.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greška!");
            }*/
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBoxId.Text= row.Cells["Id"].Value.ToString();
                textBoxNaziv.Text = row.Cells["Naziv"].Value.ToString();
                textBoxBrojGodina.Text = row.Cells["BrojGodina"].Value.ToString();
                textBoxKolicina.Text = row.Cells["Kolicina"].Value.ToString();
                textBoxCena.Text = row.Cells["Cena"].Value.ToString();
                //textBoxIdVocke.Text = row.Cells["IdVocke"].Value.ToString();
                textBoxIdVocke.Text = row.Cells["NazivGlavne"].Value.ToString();


            }
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            //List<Vocka_Vrsta> lista = this.vockaVrstaBusiness.GetAllVockaVrsta();

            try
            {
                Vocka_Vrsta vo = new Vocka_Vrsta();
                vo.naziv = textBoxNaziv.Text;
                vo.broj_godina = Convert.ToInt32(textBoxBrojGodina.Text);
                vo.kolicina = Convert.ToInt32(textBoxKolicina.Text);
                vo.cena = Convert.ToDecimal(textBoxCena.Text);
                vo.id_vocke = Convert.ToInt32(textBoxIdVocke.Text);

                if (this.vockaVrstaBusiness.InsertVockaVrsta(vo))
                {
                    MessageBox.Show("Uspešan unos!");
                    List<Vocka_Vrsta> lista = this.vockaVrstaBusiness.GetAllVockaVrsta();

                    dataGridView1.Rows.Clear();

                    foreach (Vocka_Vrsta vv in lista)
                    {
                        //dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena, vockaBusiness.GetNaziv(vv.id_vocke)); //+ "din."
                        dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena, vockaBusiness.GetNaziv(vv.id_vocke), vv.id_vocke); //+ "din."

                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                }
                else
                {
                    MessageBox.Show("Neuspešan unos!");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Pogrešan format!");
            }
        }

        private void buttonIzmeni_Click(object sender, EventArgs e)
        {

            try
            {

                Vocka_Vrsta vo = new Vocka_Vrsta();
                vo.id = Convert.ToInt32(textBoxId.Text);
                vo.naziv = textBoxNaziv.Text;
                vo.broj_godina = Convert.ToInt32(textBoxBrojGodina.Text);
                vo.kolicina = Convert.ToInt32(textBoxKolicina.Text);
                vo.cena = Convert.ToDecimal(textBoxCena.Text);
                vo.id_vocke = Convert.ToInt32(textBoxIdVocke.Text);

                if (this.vockaVrstaBusiness.UpdateVockaVrsta2(vo))
                {
                    MessageBox.Show("Uspešna izmena!");
                    List<Vocka_Vrsta> lista = this.vockaVrstaBusiness.GetAllVockaVrsta();

                    dataGridView1.Rows.Clear();

                    foreach (Vocka_Vrsta vv in lista)
                    {
                        //dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena, vockaBusiness.GetNaziv(vv.id_vocke)); //+ "din."
                        dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena, vockaBusiness.GetNaziv(vv.id_vocke), vv.id_vocke); //+ "din."

                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                }
                else
                {
                    MessageBox.Show("Neuspešna izmena!");
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show("Pogrešan format!");
            }

        }


        private void RefreshTexts()
        {
            textBoxIdVocke.Text = "";
            textBoxId.Text = "";
            textBoxNaziv.Text = "";
            textBoxBrojGodina.Text = "";
            textBoxCena.Text = "";
            textBoxKolicina.Text = "";


        }

        private void buttonObrisi_Click(object sender, EventArgs e)
        {

            try
            {

                int id = Convert.ToInt32(textBoxId.Text);
                if (this.vockaVrstaBusiness.DeleteVockaVrsta(id))
                {

                    List<Vocka_Vrsta> lista = this.vockaVrstaBusiness.GetAllVockaVrsta();
                    MessageBox.Show("Uspešno brisanje!");
                    RefreshTexts();
                    dataGridView1.Rows.Clear();
                    foreach (Vocka_Vrsta vv in lista)
                    {
                        //dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena, vv.id_vocke); //+ "din."
                        dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena, vockaBusiness.GetNaziv(vv.id_vocke), vv.id_vocke); //+ "din."

                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[6].Visible = false;

                }
                else
                    MessageBox.Show("Neuspešno brisanje!");

            }
            catch (Exception exe)
            {
                MessageBox.Show("Pogrešan format!");
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                textBoxId2.Text = row.Cells["IdVocka"].Value.ToString();
                textBoxNaziv2.Text = row.Cells["NazivVocka"].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId2.Text);
           
            if (this.vockaBusiness.DeleteVockaVrsta(id))
            {

                List<Vocka> lista = this.vockaBusiness.GetAllVocka();
                MessageBox.Show("Uspešno brisanje!");
                textBoxId2.Text = "";
                textBoxNaziv2.Text = "";
                dataGridView2.Rows.Clear();
                foreach (Vocka vv in lista)
                {
                    dataGridView2.Rows.Add(vv.id, vv.naziv); //+ "din."
                }
                //dataGridView2.Columns[0].Visible = false;
            }
            else
                MessageBox.Show("Neuspešno brisanje!");
            }
            catch (Exception exe)
            {
                MessageBox.Show("Pogrešan format!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Vocka vo = new Vocka();
                vo.naziv = textBoxNaziv2.Text;

                if (this.vockaBusiness.InsertVockaVrsta(vo))
                {
                    MessageBox.Show("Uspešan unos!");
                    List<Vocka> lista = this.vockaBusiness.GetAllVocka();

                    dataGridView2.Rows.Clear();

                    foreach (Vocka vv in lista)
                    {
                        dataGridView2.Rows.Add(vv.id, vv.naziv); //+ "din."
                    }
                }
                else
                {
                    MessageBox.Show("Neuspešan unos!");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show("Pogrešan format!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                Vocka vo = new Vocka();
                vo.id = Convert.ToInt32(textBoxId2.Text);
                vo.naziv = textBoxNaziv2.Text;


                if (this.vockaBusiness.UpdateVockaVrsta(vo))
                {
                    MessageBox.Show("Uspešna izmena!");
                    List<Vocka> lista = this.vockaBusiness.GetAllVocka();

                    dataGridView2.Rows.Clear();

                    foreach (Vocka vv in lista)
                    {
                        dataGridView2.Rows.Add(vv.id, vv.naziv); //+ "din."
                    }
                }
                else
                {
                    MessageBox.Show("Neuspešna izmena!");
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
                if (v.naziv == voce)
                {
                    int id = v.id;
                    foreach (Vocka_Vrsta vv in list)
                    {
                        if (vv.id_vocke == id)
                        {
                            dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena, vockaBusiness.GetNaziv(vv.id_vocke),vv.id_vocke);
                            dataGridView1.Columns[0].Visible = false;
                            dataGridView1.Columns[6].Visible = false;


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
                    dataGridView1.Rows.Add(vv.id, vv.naziv, vv.broj_godina, vv.kolicina, vv.cena, vockaBusiness.GetNaziv(vv.id_vocke),vv.id_vocke);
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    //break;

                }

            }
        }



        /*  private void showData()
          {
              adpt = new SqlDataAdapter("SELECT * FROM Vocka_Vrsta",con);
              dt = new DataTable();
              adpt.Fill(dt);
              dataGridView1.DataSource = dt;
          }*/




    }
}
