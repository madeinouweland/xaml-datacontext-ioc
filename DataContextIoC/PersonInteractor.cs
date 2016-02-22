using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataContextIoC
{
    public class PersonInteractor : MainPage.IViewModel
    {
        private IIdGenerator _idGenerator;
        private INavigator _navigator;

        public PersonInteractor(IIdGenerator idGenerator, INavigator navigator, IObservable<PersonFormView.IViewModel> childViewModel)
        {
            _idGenerator = idGenerator;
            _navigator = navigator;
            PersonFormViewModel = childViewModel;
        }

        public ObservableCollection<PersonViewModel> Persons { get; }
            = new ObservableCollection<PersonViewModel>();
        public IObservable<PersonFormView.IViewModel> PersonFormViewModel { get; private set; }

        public void AddPerson(string name)
        {
            Persons.Add(new PersonViewModel(new Person(_idGenerator.NextId(), name)));
        }

        public void RemovePerson(int id)
        {
            var viewModel = Persons.First(person => person.Id == id);
            Persons.Remove(viewModel);
        }

        public void UpdatePerson(int id, string name)
        {
            RemovePerson(id);
            Persons.Add(new PersonViewModel(new Person(id, name)));
        }

        public Person FindById(int id)
        {
            var vm = Persons.First(p => p.Id == id);
            return new Person(vm.Id, vm.Name);
        } 

        public void SelectPerson(int id)
        {
            _navigator.ToPerson(id);
        }
    }
}
