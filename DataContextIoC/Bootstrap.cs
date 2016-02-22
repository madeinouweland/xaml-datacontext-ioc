using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContextIoC
{
    public class Bootstrap
    {
        private PersonInteractor _personInteractor;

        public MainPage.IViewModel RootViewModel => _personInteractor;

        public INavigator Navigator { get; }

        public Bootstrap()
        {
            Navigator = new Navigator();
            var viewModelMapper = new ViewModelNavigationMapper(this, Navigator);
            _personInteractor = new PersonInteractor(new IdGenerator(1000), Navigator, viewModelMapper.GetFoo());
            _personInteractor.AddPerson("Fred");
            _personInteractor.AddPerson("Barney");
        }

        public PersonFormView.IViewModel CreatePersonFormViewModel(int personId)
        {
            return new PersonFormInteractor(this._personInteractor, personId);
        }
    }

    public class ViewModelNavigationMapper
    {
        private Bootstrap _bootstrap;
        private INavigator _navigator;

        public ViewModelNavigationMapper(Bootstrap bootstrap, INavigator navigator)
        {
            _bootstrap = bootstrap;
            _navigator = navigator;
        }

        public IObservable<PersonFormView.IViewModel> GetFoo()
        {
            return _navigator.PersonId.Select(personId =>
            {
                if(personId.New.HasValue)
                {
                    return _bootstrap.CreatePersonFormViewModel(personId.New.Value);
                }
                else
                {
                    return null;
                }
            });
        }
    }
}
