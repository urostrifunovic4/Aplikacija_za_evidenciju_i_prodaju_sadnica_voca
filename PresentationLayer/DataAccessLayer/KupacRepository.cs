using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;


namespace DataAccessLayer
{
    public class KupacRepository
    {
        



        public List<KupacKlasa> GetAllKupac()
        {
            List<KupacKlasa> results = new List<KupacKlasa>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Kupac";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    KupacKlasa k = new KupacKlasa();
                    k.id = sqlDataReader.GetInt32(0);
                    k.korisnicko_ime = sqlDataReader.GetString(1);
                    k.lozinka = sqlDataReader.GetString(2);
                    k.racun = sqlDataReader.GetInt32(3);
                    k.stanje = sqlDataReader.GetDecimal(4);
                   
                    results.Add(k);
                }
            }

            return results;
        }




        public int InsertKupac(KupacKlasa k)
        {
            Random rd = new Random();
            int rand_num = rd.Next(100000, 1000000);
            decimal rand_num2 = rd.Next(1000);


            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO Kupac VALUES ('{0}', '{1}', {2}, {3})", k.korisnicko_ime, k.lozinka,rand_num,0); //rand_num2
                // "INSERT INTO Kupac VALUES ("+k.korisnicko_ime+", "+k.lozinka+")";

                sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();
            }

        }

        public int UpdateKupac(KupacKlasa k)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Kupac SET korisnicko_ime='{0}', lozinka='{1}', racun={2}, stanje={3} WHERE id={4}", k.korisnicko_ime,k.lozinka,k.racun,k.stanje,k.id);
                // sqlCommand.CommandText = string.Format("UPDATE Vocka_Vrsta SET  broj_godina={0} WHERE id={1}", v.broj_godina, v.id);

                //sqlCommand.CommandText = "UPDATE Vocka_Vrsta SET naziv="+v.naziv+", broj_godina="+v.broj_godina+", kolicina="+v.kolicina+", cena="+v.cena+" FROM Vocka_Vrsta JOIN Vocka ON Vocka_Vrsta.Id_vocke==Vocka.id WHERE id="+v.id;
                int result = sqlCommand.ExecuteNonQuery();
                return result;

            }
        }


    }
}
