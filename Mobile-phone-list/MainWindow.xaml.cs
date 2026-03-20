using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        Phone tempPhone;

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
            decimal price;
            if (titleView.Text != null && titleView.Text != "" &&
                companyView.Text != null && companyView.Text != "" &&
                priceView.Text != null && priceView.Text != "" &&
                decimal.TryParse(priceView.Text, out price))
            {
                phones.Add(new Phone
                {
                    Title = titleView.Text,
                    Company = companyView.Text,
                    Price = price
                });
            }
            else
            {
                if (titleView.Text == null || titleView.Text == "" ||
                companyView.Text == null || companyView.Text == "")
                {
                    MessageBox.Show(
                        "Поля не должны быть пустыми!",
                        "Ошибка приложения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
                else if (priceView.Text == null || priceView.Text != "" ||
                !decimal.TryParse(priceView.Text, out price))
                {
                    MessageBox.Show(
                        "Поле \"Цена\" должно быть числом!", 
                        "Ошибка приложения",            
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error             
                    );
                }
            }

                mainListBox.ItemsSource = null;
            mainListBox.ItemsSource = phones;

            titleView.Text = null;
            companyView.Text = null;
            priceView.Text = null;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var selectedPhone = mainListBox.SelectedItem as Phone;

            if (selectedPhone == null)
            {
                MessageBox.Show("Выберите элемент для редактирования!");
                return;
            }

            tempPhone = selectedPhone;

            titleView.Text = tempPhone.Title;
            companyView.Text = tempPhone.Company;
            priceView.Text = tempPhone.Price.ToString();

            addButtonView.IsEnabled = false;
            trashButtonView.IsEnabled = false;
            editButtonView.IsEnabled = false;

            mainListBox.IsEnabled = false;

            saveButton.Visibility = Visibility.Visible;
            cancelButton.Visibility = Visibility.Visible;
        }
        
        private void TrashButton_Click(object sender, RoutedEventArgs e)
        {
            phones.Remove(mainListBox.SelectedItem as Phone);
            mainListBox.ItemsSource = null;
            mainListBox.ItemsSource = phones;
        }

        private void EndEditing()
        {
            titleView.Text = String.Empty;
            companyView.Text = String.Empty;
            priceView.Text = String.Empty;

            addButtonView.IsEnabled = true;
            trashButtonView.IsEnabled = true;
            editButtonView.IsEnabled = true;
            mainListBox.IsEnabled = true;

            saveButton.Visibility = Visibility.Collapsed;
            cancelButton.Visibility = Visibility.Collapsed;

            tempPhone = null;
        }        

        private void CancelButton_Click(object sender, RoutedEventArgs e) => EndEditing();

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (tempPhone != null)
            {
                if (titleView.Text == null || titleView.Text == "" ||
                companyView.Text == null || companyView.Text == "")
                {
                    MessageBox.Show(
                        "Поля не должны быть пустыми!",
                        "Ошибка приложения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
                else
                {
                    tempPhone.Title = titleView.Text;
                    tempPhone.Company = companyView.Text;
                }

                int price;
                if (int.TryParse(priceView.Text, out price))
                {
                    tempPhone.Price = price;
                }
                else
                {
                    MessageBox.Show(
                        "Поле \"Цена\" должно быть числом!",
                        "Ошибка приложения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }

                mainListBox.ItemsSource = null;
                mainListBox.ItemsSource = phones;
            }

            EndEditing();
        }
    }
}