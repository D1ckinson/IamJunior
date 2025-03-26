namespace VotingApp
{
    public class VoteConfirmer : IModel
    {
        private readonly IHasher _hasher;
        private readonly Repository _repository;

        public VoteConfirmer(IHasher hasher)
        {
            hasher.ThrowIfNull();

            _hasher = hasher;
            _repository = new();
        }

        public bool? Process(Passport passport)
        {
            passport.ThrowIfNull();

            Citizen? citizen = _repository.GetCitizen(passport, _hasher.Hash(passport.SerialNumber));

            if (citizen is null)
                return null;

            return citizen.HasVoted;
        }
    }
}
