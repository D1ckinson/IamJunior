using System.Security.Cryptography;

namespace VotingApp
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Hasher hasher = new(SHA256.Create());

            PassportForm passportForm = new();
            VoteConfirmer voteConfirmer = new(hasher);
            VoteConfirmerPresenter presenter = new(passportForm, voteConfirmer);

            passportForm.AddButtonListener(presenter.ConfirmPassport);

            Application.Run(passportForm);
            ApplicationConfiguration.Initialize();
        }
    }
}
