using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VockaRepository
    {

        public List<Vocka> GetAllVoce()
        {
            List<Vocka> results = new List<Vocka>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Vocka";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Vocka v = new Vocka();
                    v.id = sqlDataReader.GetInt32(0);
                    v.naziv = sqlDataReader.GetString(1);

                    results.Add(v);
                }
            }

            return results;
        }


        public int DeleteVoce(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM Vocka WHERE id={0}", id);
                int result = sqlCommand.ExecuteNonQuery();
                return result;

            }
        }


        public int InsertVoce(Vocka v)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText =// string.Format("INSERT INTO Vocka VALUES ('{0}')", v.naziv);
                    string.Format($"INSERT INTO Vocka(naziv" +
                $") VALUES('{v.naziv}')");
                sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();
            }

        }


        public int UpdateVoce(Vocka v)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Vocka SET naziv='{0}' WHERE id={1}", v.naziv, v.id);
                // sqlCommand.CommandText = string.Format("UPDATE Vocka_Vrsta SET  broj_godina={0} WHERE id={1}", v.broj_godina, v.id);

                //sqlCommand.CommandText = "UPDATE Vocka_Vrsta SET naziv="+v.naziv+", broj_godina="+v.broj_godina+", kolicina="+v.kolicina+", cena="+v.cena+" FROM Vocka_Vrsta JOIN Vocka ON Vocka_Vrsta.Id_vocke==Vocka.id WHERE id="+v.id;
                int result = sqlCommand.ExecuteNonQuery();
                return result;

            }
        }










    }
}
