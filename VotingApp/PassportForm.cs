namespace VotingApp
{
    public partial class PassportForm : Form, IView
    {
        private readonly VoteConfirmerPresenterFactory _presenterFactory;

        public PassportForm(VoteConfirmerPresenterFactory presenterFactory)
        {
            presenterFactory.ThrowIfNull();
            _presenterFactory = presenterFactory;

            InitializeComponent();
        }

        public event Action<string>? UserConfirmPassportIndex;

        public void Reply(string message) =>
            _replyTextbox.Text = message;

        public VoteConfirmerPresenter CreatePresenter() =>
            _presenterFactory.Create(this);
    }
}