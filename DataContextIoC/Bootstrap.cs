namespace DataContextIoC
{
    public class Bootstrap
    {
        private MainViewModel _mainViewModel;
        public IMainViewModel RootViewModel => _mainViewModel;

        private INavigator _navigator = new Navigator();
        public INavigator Navigator => _navigator;

        public Bootstrap()
        {
            _navigator = new Navigator();
            _mainViewModel = new MainViewModel(new IdGenerator(1000), _navigator, new PersonRepository(), _navigator.PersonId);
        }
    }
}
