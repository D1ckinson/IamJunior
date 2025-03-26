using System.Security.Cryptography;

namespace VotingApp
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Hasher hasher = new(SHA256.Create());
            VoteConfirmer voteConfirmer = new(hasher);

            VoteConfirmerPresenterFactory presenterFactory = new(voteConfirmer);
            PassportForm passportForm = new(presenterFactory);

            passportForm.CreatePresenter();

            Application.Run(passportForm);
            ApplicationConfiguration.Initialize();
        }
    }
}
