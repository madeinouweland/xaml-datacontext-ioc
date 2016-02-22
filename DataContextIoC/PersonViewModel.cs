namespace DataContextIoC
{
    public class PersonViewModel
    {
        public PersonViewModel(Person person)
        {
            _person = person;
        }

        private Person _person;

        public string Name => _person.Name;

        public int Id => _person.Id;

        public string Description => Name + " (" + Id + ")";
    }
}
