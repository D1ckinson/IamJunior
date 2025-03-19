using Devart.Data.SQLite;
using System.Data;
using System.Reflection;

namespace VotingApp
{
    public class VoteConfirmer
    {
        private readonly IHasher _hasher;

        public VoteConfirmer(IHasher hasher)
        {
            hasher.ThrowIfNull();
            _hasher = hasher;
        }

        public DataTable GetPassportVoteInfo(Passport passport)
        {
            passport.ThrowIfNull();

            try
            {
                SQLiteConnection connection = new(GetConnectionString());
                connection.Open();

                SQLiteDataAdapter sqLiteDataAdapter = new(GetCommand(connection, passport.SerialNumber));
                DataTable dataTable = new();

                sqLiteDataAdapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
            catch (SQLiteException exception)
            {
                if ((int)exception.ErrorCode != 1)
                    throw;

                throw new FileNotFoundException("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
            }
        }

        private static string GetConnectionString()
        {
            string? location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = Path.Combine(location, "db.sqlite");

            return $"Data Source={path}";
        }

        private SQLiteCommand GetCommand(SQLiteConnection connection, string serialNumber)
        {
            string commandParameter = "@num";
            string commandText = $"SELECT * FROM passports WHERE num = {commandParameter} LIMIT 1;";

            SQLiteCommand command = new(commandText, connection);
            command.Parameters.AddWithValue(commandParameter, _hasher.Hash(serialNumber));

            return command;
        }
    }
}
