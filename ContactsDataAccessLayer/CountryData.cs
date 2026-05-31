using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public class clsCountryDataAcess
    {
        public static bool GetCountryInfoByName(string CountryName, ref int CountryID, ref string CountryCode, ref string PhoneCode)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    CountryID = (int)reader["CountryID"];

                    if (reader["Code"] != DBNull.Value)
                    {
                        CountryCode = (string)reader["Code"];
                    }
                    else
                    {
                        CountryCode = "";
                    }

                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }
                    else
                    {
                        PhoneCode = "";
                    }

                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool IsCountryExisit(string CountryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found = 1 FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool GetCountryInfoByID(int ID, ref string CountryName, ref string CountryCode, ref string PhoneCode)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("CountryID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    if (reader["CountryName"] != DBNull.Value)
                    {
                        CountryName = (string)reader["CountryName"];
                    }
                    else
                    {
                        CountryName = "";
                    }

                    if (reader["Code"] != DBNull.Value)
                    {
                        CountryCode = (string)reader["Code"];
                    }
                    else
                    {
                        CountryCode = "";
                    }

                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }
                    else
                    {
                        PhoneCode = "";
                    }
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool IsCountryExisit(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found = 1 FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("CountryID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static int AddNewCountry(string CountryName, string CountryCode, string PhoneCode)
        {
            int newID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "INSERT INTO Countries (CountryName, Code, PhoneCode) VALUES (@CountryName, @Code, @PhoneCode); SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("CountryName", CountryName);
            command.Parameters.AddWithValue("Code", CountryCode);
            command.Parameters.AddWithValue("PhoneCode", PhoneCode);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    newID = insertedID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                newID = -1;
            }
            finally
            {
                connection.Close();
            }
            return newID;
        }

        public static bool UpdateCountry(int ID, string CountryName, string CountryCode, string PhoneCode)
        {
            bool isUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE Countries SET CountryName = @CountryName, Code = @Code, PhoneCode = @PhoneCode WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("CountryID", ID);
            command.Parameters.AddWithValue("CountryName", CountryName);
            command.Parameters.AddWithValue("Code", CountryCode);
            command.Parameters.AddWithValue("PhoneCode", PhoneCode);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isUpdated = false;
            }
            finally
            {
                connection.Close();
            }
            return isUpdated;
        }

        public static bool DeleteCountry(int ID)
        {
            bool isDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM Countries WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("CountryID", ID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isDeleted = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isDeleted = false;
            }
            finally
            {
                connection.Close();
            }
            return isDeleted;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
    }
}
