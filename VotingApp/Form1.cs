using Devart.Data.SQLite;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;

namespace VotingApp
{
    public partial class VoteConfirmerForm : Form
    {
        public VoteConfirmerForm()
        {
            InitializeComponent();
        }

        public void AddButtonListener(EventHandler eventHandler)
        {
            eventHandler.ThrowIfNull();

            _confirmButton.Click += eventHandler;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (_passportTextbox.Text.Trim() == "")
            {
                MessageBox.Show("������� ����� � ����� ��������");

                return;
            }

            string rawData = _passportTextbox.Text.Trim().Replace(" ", string.Empty);

            if (rawData.Length < 10)
            {
                _textResult.Text = "�������� ������ ����� ��� ������ ��������";

                return;
            }

            string commandText = string.Format("select * from passports where num='{0}' limit 1;", ComputeSha256Hash(rawData));
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
                    string result = Convert.ToBoolean(dataTable1.Rows[0].ItemArray[1]) ? "������������" : "�� ��������������";

                    _textResult.Text = $"�� �������� �{_passportTextbox.Text}� ������ � ��������� �� ������������� ����������� ����������� {result}";
                }
                else
                {
                    _textResult.Text = $"������� �{_passportTextbox.Text}� � ������ ���������� �������������� ����������� �� ������";
                }

                connection.Close();
            }
            catch (SQLiteException exception)
            {
                if ((int)exception.ErrorCode != 1)
                    return;

                MessageBox.Show("���� db.sqlite �� ������. �������� ���� � ����� ������ � exe.");
            }
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
