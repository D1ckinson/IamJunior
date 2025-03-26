using Devart.Data.SQLite;
using System.Data;
using System.Reflection;

namespace VotingApp
{
    public class DatabaseContext
    {
        public DataTable GetDataTable(string serialNumberHash)
        {
            try
            {
                SQLiteConnection connection = new(GetConnectionString());
                connection.Open();

                SQLiteDataAdapter sqLiteDataAdapter = new(GetCommand(connection, serialNumberHash));
                DataTable dataTable = new();

                sqLiteDataAdapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
            catch (SQLiteException exception)
            {
                if ((int)exception.ErrorCode == Constants.One)
                    throw new FileNotFoundException("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");

                throw;
            }
        }

        private string GetConnectionString()
        {
            string? location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            location.ThrowIfNull();

            string path = Path.Combine(location, "db.sqlite");

            return $"Data Source={path}";
        }

        private static SQLiteCommand GetCommand(SQLiteConnection connection, string serialNumberHash)
        {
            string commandParameter = "@num";
            string commandText = $"SELECT * FROM passports WHERE num = {commandParameter} LIMIT 1;";

            SQLiteCommand command = new(commandText, connection);
            command.Parameters.AddWithValue(commandParameter, (serialNumberHash));

            return command;
        }
    }
}
