namespace VotingApp
{
    public class ArgumentNotEqualException(int comparableValue) : ArgumentOutOfRangeException()
    {
        public readonly int ComparableValue = comparableValue;
    }
}
