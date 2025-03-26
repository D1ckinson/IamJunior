using System.Data;

namespace VotingApp
{
    public class Repository
    {
        private readonly DatabaseContext _databaseContext = new();

        public Citizen? GetCitizen(Passport passport, string hash)
        {
            passport.ThrowIfNull();
            hash.ThrowIfEmpty();

            DataTable dataTable = _databaseContext.GetDataTable(passport.SerialNumber);

            if (dataTable.Rows.Count == Constants.Zero)
                return null;

            bool hasVoted = Convert.ToBoolean(dataTable.Rows[Constants.Zero].ItemArray[Constants.One]);

            return new(hasVoted);
        }
    }
}
