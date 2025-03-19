namespace VotingApp
{
    public class Passport
    {
        private const string Space = " ";
        private const int SerialNumberLength = 10;

        public Passport(string serialNumber)
        {
            serialNumber.ThrowIfEmpty();
            serialNumber = serialNumber.Replace(Space, string.Empty);

            if (serialNumber.Length < SerialNumberLength)
                throw new ArgumentOutOfRangeException(serialNumber);

            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; }
    }
}
