using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DataContextIoC
{
    public sealed partial class PersonFormView : UserControl
    {
        public interface IViewModel
        {
            string Name { get; set; }
            void Save();
        }

        public IViewModel ViewModel { get { return DataContext as IViewModel; } }

        public PersonFormView()
        {
            this.InitializeComponent();
            DataContextChanged += PersonFormView_DataContextChanged;
        }

        private void PersonFormView_DataContextChanged(Windows.UI.Xaml.FrameworkElement sender, Windows.UI.Xaml.DataContextChangedEventArgs args)
        {
            Bindings.Update();
        }

        private void UpdatePerson_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.Name = PersonName.Text;
            ViewModel.Save();
        }
    }
}
