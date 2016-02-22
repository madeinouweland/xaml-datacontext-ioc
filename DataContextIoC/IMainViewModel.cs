using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataContextIoC
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        ObservableCollection<PersonViewModel> Persons { get; }
        IPersonViewModel SelectedPersonViewModel { get; }
        void AddPerson(string name);
        void RemovePerson(int id);
        void SelectPerson(int id);
    }
}
