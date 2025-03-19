using Devart.Data.SQLite;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;

namespace VotingApp
{
    public partial class PassportForm : Form
    {
        public PassportForm()
        {
            InitializeComponent();
        }

        public string Passport => _passportTextbox.Text;

        public void AddButtonListener(EventHandler eventHandler)
        {
            eventHandler.ThrowIfNull();
            _confirmButton.Click += eventHandler;
        }

        public void Reply(string message) =>
            _replyTextbox.Text = message;
    }
}