namespace VotingApp
{
    public class Citizen
    {
        public Citizen(bool hasVoted)
        {
            hasVoted.ThrowIfNull();
            HasVoted = hasVoted;
        }

        public bool HasVoted { get; }
    }
}
