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
            string passport = _passportForm.Passport;
            string reply = _voteConfirmer.Confirm(passport);

            _passportForm.Reply(reply);
        }
    }
}
