using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VockaVrstaRepository
    {
        public List<Vocka_Vrsta> GetAllVoce()
        {
            List<Vocka_Vrsta> results = new List<Vocka_Vrsta>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Vocka_Vrsta";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Vocka_Vrsta v = new Vocka_Vrsta();
                    v.id = sqlDataReader.GetInt32(0);
                    v.naziv = sqlDataReader.GetString(1);
                    v.broj_godina = sqlDataReader.GetInt32(2);
                    v.kolicina = sqlDataReader.GetInt32(3);
                    v.cena = sqlDataReader.GetDecimal(4);
                    v.id_vocke = sqlDataReader.GetInt32(5);

                    results.Add(v);
                }
            }

            return results;
        }

        


        public int InsertVoce(Vocka_Vrsta v)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = //string.Format("INSERT INTO Vocka_Vrsta VALUES ('{0}', {1}, {2}, {3}, {4}, {5})", v.naziv, v.broj_godina, v.kolicina, v.cena,v.id_vocke,0);
                 string.Format($"INSERT INTO Vocka_Vrsta(naziv,broj_godina,kolicina,cena,id_vocke" +
                $") VALUES('{v.naziv}','{v.broj_godina}'," +
                $"'{v.kolicina}','{v.cena}', '{v.id_vocke}' )");
                sqlConnection.Open();

                return sqlCommand.ExecuteNonQuery();
            }

        }

        public int UpdateVoce(Vocka_Vrsta v)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Vocka_Vrsta SET naziv='{0}', broj_godina={1}, kolicina={2}, cena={3} WHERE id={4}", v.naziv, v.broj_godina, v.kolicina, v.cena, v.id);
               // sqlCommand.CommandText = string.Format("UPDATE Vocka_Vrsta SET  broj_godina={0} WHERE id={1}", v.broj_godina, v.id);

                //sqlCommand.CommandText = "UPDATE Vocka_Vrsta SET naziv="+v.naziv+", broj_godina="+v.broj_godina+", kolicina="+v.kolicina+", cena="+v.cena+" FROM Vocka_Vrsta JOIN Vocka ON Vocka_Vrsta.Id_vocke==Vocka.id WHERE id="+v.id;
                int result = sqlCommand.ExecuteNonQuery();
                return result;

            }
        }

        public int UpdateVoce2(Vocka_Vrsta v)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Vocka_Vrsta SET Vocka_Vrsta.naziv='{0}', Vocka_Vrsta.broj_godina={1}, Vocka_Vrsta.kolicina={2}, Vocka_Vrsta.cena={3}, id_vocke={4} FROM Vocka_Vrsta  JOIN Vocka  ON Vocka_Vrsta.id_vocke=Vocka.Id WHERE Vocka_Vrsta.id={5}", v.naziv, v.broj_godina, v.kolicina, v.cena, v.id_vocke, v.id);
                // sqlCommand.CommandText = string.Format("UPDATE Vocka_Vrsta SET  broj_godina={0} WHERE id={1}", v.broj_godina, v.id);

                //sqlCommand.CommandText = "UPDATE Vocka_Vrsta SET naziv="+v.naziv+", broj_godina="+v.broj_godina+", kolicina="+v.kolicina+", cena="+v.cena+" FROM Vocka_Vrsta JOIN Vocka ON Vocka_Vrsta.Id_vocke==Vocka.id WHERE id="+v.id;
                int result = sqlCommand.ExecuteNonQuery();
                return result;

            }
        }

        public int DeleteVoce(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM Vocka_Vrsta WHERE id={0}", id);
                int result = sqlCommand.ExecuteNonQuery();
                return result;

            }
        }
    }
}
