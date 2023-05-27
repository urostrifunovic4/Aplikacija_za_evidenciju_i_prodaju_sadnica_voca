using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UkupnoRepository
    {
        public List<Ukupno> GetAll()
        {
            List<Ukupno> results = new List<Ukupno>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Ukupno";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Ukupno u = new Ukupno();
                    u.id = sqlDataReader.GetInt32(0);
                    u.kolicina = sqlDataReader.GetInt32(1);
                    u.cena = sqlDataReader.GetDecimal(2);

                    results.Add(u);
                }
            }

            return results;
        }


        public int Update(Ukupno u)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Ukupno SET kolicina={0}, cena={1} WHERE id={2}", u.kolicina, u.cena, 1);
                // sqlCommand.CommandText = string.Format("UPDATE Vocka_Vrsta SET  broj_godina={0} WHERE id={1}", v.broj_godina, v.id);

                //sqlCommand.CommandText = "UPDATE Vocka_Vrsta SET naziv="+v.naziv+", broj_godina="+v.broj_godina+", kolicina="+v.kolicina+", cena="+v.cena+" FROM Vocka_Vrsta JOIN Vocka ON Vocka_Vrsta.Id_vocke==Vocka.id WHERE id="+v.id;
                int result = sqlCommand.ExecuteNonQuery();
                return result;

            }
        }





    }
}
