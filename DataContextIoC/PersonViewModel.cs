using System.Diagnostics;

namespace DataContextIoC
{
    [DebuggerDisplay("Id: {Id}, Name: {Name}")]
    public class PersonViewModel : ObservableObject, IPersonViewModel
    {
        public PersonViewModel(Person person)
        {
            _person = person;
            _name = person.Name;
        }

        private Person _person;


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyOfPropertyChange(nameof(Name));
                }
            }
        }

        public int Id => _person.Id;

        public string Description => Name + " (" + Id + ")";
    }
}
