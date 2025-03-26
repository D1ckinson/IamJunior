namespace VotingApp
{
    public class VoteConfirmerPresenterFactory
    {
        private readonly IModel _model;

        public VoteConfirmerPresenterFactory(IModel model)
        {
            model.ThrowIfNull();
            _model = model;
        }

        public VoteConfirmerPresenter Create(IView view)
        {
            view.ThrowIfNull();

            VoteConfirmerPresenter voteConfirmerPresenter = new(_model, view);
            view.UserConfirmPassportIndex += voteConfirmerPresenter.ConfirmPassport;

            return voteConfirmerPresenter;
        }
    }
}
