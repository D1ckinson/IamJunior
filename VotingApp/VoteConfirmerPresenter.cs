namespace VotingApp
{
    public class VoteConfirmerPresenter
    {
        private readonly IView _view;
        private readonly IModel _model;

        public VoteConfirmerPresenter(IModel model, IView view)
        {
            model.ThrowIfNull();
            view.ThrowIfNull();

            _view = view;
            _model = model;
        }

        public void ConfirmPassport(string serialNumber)
        {
            if (serialNumber == string.Empty)
            {
                _view.Reply("Введите серию и номер паспорта");

                return;
            }

            try
            {
                Passport passport = new(serialNumber);

                bool? result = _model.Process(passport);

                if (result is null)
                {
                    _view.Reply($"Паспорт «{passport.SerialNumber}» в списке участников дистанционного голосования НЕ НАЙДЕН");

                    return;
                }

                string confirmText = (bool)result ? "ПРЕДОСТАВЛЕН" : "НЕ ПРЕДОСТАВЛЯЛСЯ";
                _view.Reply($"По паспорту «{passport.SerialNumber}» доступ к бюллетеню на дистанционном электронном голосовании {confirmText}");
            }
            catch (ArgumentNotEqualException exception)
            {
                _view.Reply($"Должно быть {exception.ComparableValue} символов");
            }
            catch (FileNotFoundException exception)
            {
                _view.Reply(exception.Message);
            }
        }
    }
}
