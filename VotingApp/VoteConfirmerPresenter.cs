namespace VotingApp
{
    public class VoteConfirmerPresenter
    {
        private readonly PassportForm _passportForm;
        private readonly VoteConfirmer _voteConfirmer;

        public VoteConfirmerPresenter(PassportForm passportForm, VoteConfirmer voteConfirmer)
        {
            passportForm.ThrowIfNull();
            voteConfirmer.ThrowIfNull();

            _passportForm = passportForm;
            _voteConfirmer = voteConfirmer;
        }

        public void ConfirmPassport(object? sender, EventArgs e)
        {
            Passport passport = new(_passportForm.Passport);

            bool? result = _voteConfirmer.GetPassportVoteInfo(passport);

            if (result == null)
            {
                _passportForm.Reply($"Паспорт «{passport.SerialNumber}» в списке участников дистанционного голосования НЕ НАЙДЕН");

                return;
            }

            string confirmText = (bool)result ? "ПРЕДОСТАВЛЕН" : "НЕ ПРЕДОСТАВЛЯЛСЯ";
            _passportForm.Reply($"По паспорту «{passport.SerialNumber}» доступ к бюллетеню на дистанционном электронном голосовании {confirmText}");
        }
    }
}
