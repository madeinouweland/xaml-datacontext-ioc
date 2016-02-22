using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataContextIoC
{
    public class MainViewModel : ObservableObject, IMainViewModel
    {
        private IIdGenerator _idGenerator;
        private INavigator _navigator;
        private PersonRepository _personRepository;

        public ObservableCollection<PersonViewModel> Persons { get; } = new ObservableCollection<PersonViewModel>();

        private IPersonViewModel _selectedPersonViewModel;
        public IPersonViewModel SelectedPersonViewModel
        {
            get { return _selectedPersonViewModel; }
            set
            {
                if (_selectedPersonViewModel != value)
                {
                    _selectedPersonViewModel = value;
                    NotifyOfPropertyChange(nameof(SelectedPersonViewModel));
                }
            }
        }

        public MainViewModel(
            IIdGenerator idGenerator,
            INavigator navigator,
            PersonRepository personRepository,
            IObservable<Data<int>> personId)
        {
            _idGenerator = idGenerator;
            _navigator = navigator;
            _personRepository = personRepository;
            personId.Subscribe(x => OnSelectedPersonIdChanged(x.New));

            foreach (var person in personRepository.Persons)
            {
                Persons.Add(new PersonViewModel(person));
            }
        }

        private void OnSelectedPersonIdChanged(int? personId)
        {
            //if (SelectedPersonViewModel != null)
            //{
            //    ((IDisposable)SelectedPersonViewModel).Dispose();
            //}
            if (personId == null)
            {

            }
            else
            {
                var person = _personRepository.ById(personId.Value);
                SelectedPersonViewModel = new PersonViewModel(person);
            }
        }


        public void AddPerson(string name)
        {
            //            Persons.Add(new PersonViewModel(new Person(_idGenerator.NextId(), name)));
        }

        public void RemovePerson(int id)
        {
            var viewModel = Persons.First(person => person.Id == id);
            //          Persons.Remove(viewModel);
        }

        public void UpdatePerson(int id, string name)
        {
            RemovePerson(id);
            //        Persons.Add(new PersonViewModel(new Person(id, name)));
        }

        public void SelectPerson(int id)
        {
            _navigator.ToPerson(id);
        }
    }
}
