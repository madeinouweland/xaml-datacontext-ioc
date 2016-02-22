using System;
using System.Collections.ObjectModel;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DataContextIoC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public interface IViewModel
        {
            ObservableCollection<PersonViewModel> Persons { get; }
            IObservable<PersonFormView.IViewModel> PersonFormViewModel { get; }
            void AddPerson(string name);
            void RemovePerson(int id);
            void SelectPerson(int id);
        }

        public MainPage()
        {
            this.InitializeComponent();
            DataContextChanged += OnViewModelUpdate;
        }

        private void OnViewModelUpdate(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Bindings.Update();
            ViewModel.PersonFormViewModel.Subscribe(viewModel => PersonForm.DataContext = viewModel);
        }

        private IViewModel ViewModel { get { return DataContext as IViewModel; } }

        private void RemovePerson_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var pp = (sender as Button).DataContext as PersonViewModel;
            ViewModel.RemovePerson(pp.Id);
        }

        private void NewPersonName_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if(NewPersonName.Text.Length != 0 && e.Key == VirtualKey.Enter)
            {
                ViewModel.AddPerson(NewPersonName.Text);
                NewPersonName.Text = "";
            }
        }

        private void PersonsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedViewModel = ((sender as ListView).SelectedItem as FrameworkElement).DataContext as PersonViewModel;
            if(selectedViewModel != null)
            {
                ViewModel.SelectPerson(selectedViewModel.Id);
            }
        }
    }
}
