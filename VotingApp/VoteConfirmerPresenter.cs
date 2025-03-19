using System.Data;

namespace VotingApp
{
    public class VoteConfirmerPresenter
    {
        private const int Zero = 0;

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
            DataTable dataTable = _voteConfirmer.GetPassportVoteInfo(passport);

            if (dataTable.Rows.Count == Zero)
            {
                _passportForm.Reply($"Паспорт «{passport.SerialNumber}» в списке участников дистанционного голосования НЕ НАЙДЕН");

                return;
            }

            string confirmText = Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]) ? "ПРЕДОСТАВЛЕН" : "НЕ ПРЕДОСТАВЛЯЛСЯ";
            _passportForm.Reply($"По паспорту «{passport.SerialNumber}» доступ к бюллетеню на дистанционном электронном голосовании {confirmText}");
        }
    }
}
