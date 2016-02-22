using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataContextIoC
{
    public sealed partial class PersonView : UserControl
    {
        public IPersonViewModel ViewModel => DataContext as IPersonViewModel;

        public PersonView()
        {
            InitializeComponent();
            DataContextChanged += PersonFormView_DataContextChanged;
        }

        private void PersonFormView_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            Bindings.Update();
        }

        private void UpdatePerson_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.Name = PersonName.Text;
       //     ViewModel.Save();
        }
    }
}
