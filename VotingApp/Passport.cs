namespace VotingApp
{
    public class Passport
    {
        private const char Space = ' ';
        private const int SerialNumberLength = 10;

        public Passport(string serialNumber)
        {
            serialNumber.ThrowIfEmpty();
            serialNumber = serialNumber.Trim(Space);

            serialNumber.Length.ThrowIfNotEqual(SerialNumberLength);

            SerialNumber = serialNumber;
        }

        public string SerialNumber { get; }
    }
}
