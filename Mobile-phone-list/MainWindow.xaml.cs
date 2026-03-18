using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mobile_phone_list
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Phone> phones;
        public MainWindow()
        {
            InitializeComponent();

            phones = new List<Phone>()
            {
                new Phone {Company = "Apple", Title = "IPhone 10", Price = 58000},
                new Phone {Company = "Samsung", Title = "Galaxy S10", Price = 65000},
                new Phone {Company = "Google", Title = "Pixel 4", Price = 50000},
                new Phone {Company = "OnePlus", Title = "OnePlus 7T", Price = 45000}
            };

            mainListBox.ItemsSource = phones;
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            phones.Add(new Phone
            {
                Title = titleView.Text,
                Company = companyView.Text,
                Price = Convert.ToDecimal(priceView.Text)
            });

            mainListBox.ItemsSource = null;
            mainListBox.ItemsSource = phones;

            titleView.Text = null;
            companyView.Text = null;
            priceView.Text = null;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            phones.Remove(mainListBox.SelectedItem as Phone);
            mainListBox.ItemsSource = null;
            mainListBox.ItemsSource = phones;
        }
    }
}