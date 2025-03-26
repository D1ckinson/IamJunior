namespace VotingApp
{
    public interface IView
    {
        public void Reply(string message);

        public event Action<string>? UserConfirmPassportIndex;
    }
}
