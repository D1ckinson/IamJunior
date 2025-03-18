using Devart.Data.SQLite;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;

namespace VotingApp
{
    public class VoteConfirmer
    {
        private const string Space = " ";
        private const int PassportLength = 10;

        public static string Confirm(string passport)
        {
            if (IsPassportValid(ref passport, out string message) == false)
                return message;

            string commandText = string.Format("select * from passports where num='{0}' limit 1;", ComputeSha256Hash(passport));
            string connectionString = string.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");

            try
            {
                SQLiteConnection connection = new(connectionString);
                connection.Open();

                SQLiteDataAdapter sqLiteDataAdapter = new(new SQLiteCommand(commandText, connection));
                DataTable dataTable = new();

                sqLiteDataAdapter.Fill(dataTable);

                string result;

                if (dataTable.Rows.Count > 0)
                {
                    string confirmText = Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]) ? "ПРЕДОСТАВЛЕН" : "НЕ ПРЕДОСТАВЛЯЛСЯ";
                    result = $"По паспорту «{passport}» доступ к бюллетеню на дистанционном электронном голосовании {confirmText}";
                }
                else
                {
                    result = $"Паспорт «{passport}» в списке участников дистанционного голосования НЕ НАЙДЕН";
                }

                connection.Close();

                return result;
            }
            catch (SQLiteException exception)
            {
                if ((int)exception.ErrorCode != 1)
                    return exception.Message;

                return "Файл db.sqlite не найден. Положите файл в папку вместе с exe.";
            }
        }

        private static bool IsPassportValid(ref string passport, out string message)
        {
            message = string.Empty;

            if (string.IsNullOrEmpty(passport))
            {
                message = "Введите серию и номер паспорта";
                return false;
            }

            passport = passport.Replace(Space, string.Empty);

            if (passport.Length < PassportLength)
            {
                message = "Введите серию и номер паспорта";
                return false;
            }

            return true;
        }

        private static string ComputeSha256Hash(string rawData)
        {
            rawData.ThrowIfNull(nameof(rawData));

            byte[] buffer = BitConverter.GetBytes(rawData.GetHashCode());
            byte[] hash = SHA256.HashData(buffer);

            return string.Concat(hash);
        }
    }
}
