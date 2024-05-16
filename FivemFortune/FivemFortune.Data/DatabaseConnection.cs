using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivemFortune.Data
{
    public class DatabaseConnection
    {
        MySql.Data.MySqlClient.MySqlConnection myConnection { get; set; }
        private string _connString;

        public DatabaseConnection(string connString)
        {
            _connString = connString;
            myConnection = new MySql.Data.MySqlClient.MySqlConnection(_connString);
        }

        public List<T> ExecuteQuery<T>(string Query, Func<MySqlDataReader, T> mapFunction)
        {
            List<T> result = new List<T>();

            using (MySqlConnection cnn = new MySqlConnection(_connString))
            {
                cnn.Open();
                using (MySqlTransaction transaction = cnn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(Query, cnn, transaction))
                        {
                            using (MySqlDataReader dataReader = command.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    T obj = mapFunction(dataReader);
                                    result.Add(obj);
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction rolled back. Error: " + ex.Message);
                    }
                }
            }

            return result;
        }

        public T ExecuteQuerySingle<T>(string Query, Func<MySqlDataReader, T> mapFunction)
        {
            T result;

            using (MySqlConnection cnn = new MySqlConnection(_connString))
            {
                cnn.Open();
                using (MySqlTransaction transaction = cnn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(Query, cnn, transaction))
                        {
                            using (MySqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    result = mapFunction(dataReader);
                                }
                                else
                                {
                                    result = default(T);
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction rolled back. Error: " + ex.Message);
                        result = default(T);
                    }
                }
            }

            return result;
        }
        public void ExecuteUpdateQuerry(string query)
        {
            using (MySqlConnection cnn = new MySqlConnection(_connString))
            {
                cnn.Open();
                using (MySqlTransaction transaction = cnn.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(query, cnn, transaction))
                        {
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction rolled back. Error: " + ex.Message);
                    }
                }
            }
        }

    }
}
