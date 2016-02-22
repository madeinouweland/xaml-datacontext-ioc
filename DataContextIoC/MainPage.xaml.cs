using System;
using System.Collections.ObjectModel;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace DataContextIoC
{
    public sealed partial class MainPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            DataContextChanged += OnViewModelUpdate;
        }

        private void OnViewModelUpdate(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Bindings.Update();
        }

        private IMainViewModel ViewModel => DataContext as IMainViewModel;

        private void RemovePerson_Click(object sender, RoutedEventArgs e)
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

            var selectedViewModel =e.AddedItems[0] as PersonViewModel;
            if(selectedViewModel != null)
            {
                ViewModel.SelectPerson(selectedViewModel.Id);
            }
        }
    }
}
