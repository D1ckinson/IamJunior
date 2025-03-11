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

        public string ConfirmPassport(string passport)
        {
            passport.ThrowIfEmpty();
            passport = passport.Replace(Space, string.Empty);

            string result=string.Empty;

            if (passport == string.Empty)
                return "Введите серию и номер паспорта";

            if (passport.Length < PassportLength)
                return "Неверный формат серии или номера паспорта";

            string commandText = string.Format("select * from passports where num='{0}' limit 1;", ComputeSha256Hash(passport));
            string connectionString = string.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");

            try
            {
                SQLiteConnection connection = new(connectionString);
                connection.Open();

                SQLiteDataAdapter sqLiteDataAdapter = new(new SQLiteCommand(commandText, connection));

                DataTable dataTable1 = new();
                DataTable dataTable2 = dataTable1;

                sqLiteDataAdapter.Fill(dataTable2);

                if (dataTable1.Rows.Count > 0)
                {
                    string confirmText = Convert.ToBoolean(dataTable1.Rows[0].ItemArray[1]) ? "ПРЕДОСТАВЛЕН" : "НЕ ПРЕДОСТАВЛЯЛСЯ";
                    result = $"По паспорту «{passport}» доступ к бюллетеню на дистанционном электронном голосовании {confirmText}";
                }
                else
                {
                    result = $"Паспорт «{passport}» в списке участников дистанционного голосования НЕ НАЙДЕН";
                }

                connection.Close();
            }
            catch (SQLiteException exception)
            {
                if ((int)exception.ErrorCode != 1)
                    return result;

                return "Файл db.sqlite не найден. Положите файл в папку вместе с exe.";
            }

            return result;
        }

        private string ComputeSha256Hash(string rawData)
        {
            rawData.ThrowIfNull(nameof(rawData));

            byte[] buffer = BitConverter.GetBytes(rawData.GetHashCode());
            byte[] hash = SHA256.HashData(buffer);

            return string.Concat(hash);
        }
    }
}
