namespace VotingApp
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            PassportForm passportForm = new();
            VoteConfirmer voteConfirmer = new();
            VoteConfirmerPresenter presenter = new(passportForm);

            passportForm.AddButtonListener(presenter.ConfirmPassport);

            Application.Run(passportForm);
            ApplicationConfiguration.Initialize();
        }
    }
}
