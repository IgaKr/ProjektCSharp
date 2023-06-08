using Laboratorium4.DataBaseRepository.Interfaces;
using Laboratorium4.ExtensionMethods;
using Laboratorium4.Models;
using Laboratorium4.Resources;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Laboratorium4.DataBaseRepository
{
    internal class SqlServerRepository : IDataBaseRepository
    {
        private readonly SqlConnection _connection = default!;

        public SqlServerRepository()
        {
            _connection = new SqlConnection();
            var stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.IntegratedSecurity = true;
            stringBuilder.DataSource = @"(localdb)\MSSQLLocalDB";
            stringBuilder.InitialCatalog = "DaneOsobowe";

            _connection.ConnectionString = stringBuilder.ConnectionString;
        }
        #region Public methods
        public List<string> GetAllNames()
        {
            var result = new List<string>();
            var sql = Queries.GetAllNames;


            OpenConnectionIfNeeded();
            using (_connection)
            {
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetFieldValue<string>("Imie"));
                        }
                    }
                }
            }
            return result; 
        }

        public int GetNameId(string name)
        {
            var result = -1;

            var sql = Queries.GetIdByName;

            var nameParameter = CreateSqlParameter(name, "@NAME");

            OpenConnectionIfNeeded();
            using (_connection)
            {
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(nameParameter);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader.GetFieldValue<int>("Id");
                        }
                    }
                }
            }

            return result;
        }

        public int GetNamesCount()
        {
            var result = 0;

            var sql = Queries.GetNameCount;

            OpenConnectionIfNeeded();
            using (_connection)
            {
                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    result = cmd.ExecuteScalar().ToInt();
                }
            }

            return result;
        }

        public void InsertNewName(string name)
        {
            var sql = "INSERT INTO IMIONA(Imie) VALUES (@NAME)";
            var nameParameter = CreateSqlParameter(name, "@NAME");
            OpenConnectionIfNeeded();
            using (_connection)
            {
                using (var cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(nameParameter);
                    var wynik = cmd.ExecuteNonQuery(); 
               }
            }
        }

        public void InsertNewPerson(Person person)
        {
            var queryInsertImie = "INSERT INTO IMIONA(Imie) VALUES (@NAME)";
            var queryInsertNazwisko = "INSERT INTO NAZWISKA(Nazwisko) VALUES (@LASTNAME)";
            var nameParameter = CreateSqlParameter(person.Name, "@NAME");
            var lastnameParameter = CreateSqlParameter(person.LastName, "@LASTNAME");

            OpenConnectionIfNeeded();
            using (_connection)
            {
                using (var transaction = _connection.BeginTransaction())
                {
                    using (var command = _connection.CreateCommand())
                    {
                        try
                        {
                            command.Transaction = transaction;
                            command.CommandText = queryInsertImie;
                            command.Parameters.Add(nameParameter);
                            command.ExecuteNonQuery();

                            throw new Exception("");
                            command.CommandText = queryInsertNazwisko;
                            command.Parameters.Clear();
                            command.Parameters.Add(lastnameParameter);
                            command.ExecuteNonQuery();

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
        }

        public List<string> GetAllSurnames()
        {
            var result = new List<string>();
            OpenConnectionIfNeeded();
            using (_connection)
            {
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "SELECT Nazwisko FROM Nazwiska";
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                result.Add(row[column.ColumnName].ToString()!);
                            }
                        }

                    }
                }
            }
            return result;
        }
        #endregion
        #region Private methods
        private void OpenConnectionIfNeeded()
        {
			try
			{
               if(_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
			catch (Exception e)
			{

			}
        }
        private SqlParameter CreateSqlParameter(string value, string parameterName)
        {
            var nameParameter = new SqlParameter
            {
                ParameterName = parameterName,
                Value = value,
                DbType = DbType.String,
                Size = 50
            };
            return nameParameter;   
        }

        public void SaveGoldRate(Laboratorium3.Models.GoldDTO goldRate)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
