namespace VotingApp
{
    public class VoteConfirmerPresenter
    {
        private readonly PassportForm _passportForm;

        public VoteConfirmerPresenter(PassportForm passportForm)
        {
            passportForm.ThrowIfNull();
            _passportForm = passportForm;
        }

        public void ConfirmPassport(object? sender, EventArgs e)
        {
            string passport = _passportForm.Passport;
            string reply = VoteConfirmer.Confirm(passport);

            _passportForm.Reply(reply);
        }
    }
}
