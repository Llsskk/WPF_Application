using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using eclient.Modelss;
using System.Data.SQLite;
using eclient.Views;


namespace eclient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dgPerson.ItemsSource = Person.GetList();
            dgCompany.ItemsSource = Company.GetList();
            dgOrgLegForms.ItemsSource = OrgLegForms.GetList();
            dgOrgRegistration.ItemsSource = OrgRegistration.GetList();
        }

        void Person_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowPerson();
            window.ShowDialog();
            dgPerson.ItemsSource = Person.GetList();
        }

        void Person_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var person = dgPerson.SelectedItem as Person;
            if (person != null)
            {
                var window = new WindowPerson(person);
                window.ShowDialog();
                dgPerson.ItemsSource = Person.GetList();
            }
        }

        void Person_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var person = dgPerson.SelectedItem as Person;
            if (person != null)
            {
                var dialog = MessageBox.Show("Удалить?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    Person.Delete(person);
                    dgPerson.ItemsSource = Person.GetList();
                }
            }
        }

        void Company_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowCompany();
            window.ShowDialog();
            dgCompany.ItemsSource = Company.GetList();
        }

        void Company_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var company = dgCompany.SelectedItem as Company;
            if (company != null)
            {
                var window = new WindowCompany(company);
                window.ShowDialog();
                dgCompany.ItemsSource = Company.GetList();
            }
        }

        void Company_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var company = dgCompany.SelectedItem as Company;
            if (company != null)
            {
                var dialog = MessageBox.Show("Удалить?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    Company.Delete(company);
                    dgCompany.ItemsSource = Company.GetList();
                }
            }
        }

        void OrgLegForms_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowOrgLegForms();
            window.ShowDialog();
            dgOrgLegForms.ItemsSource = OrgLegForms.GetList();
        }

        void OrgLegForms_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var orgLegForms = dgOrgLegForms.SelectedItem as OrgLegForms;
            if (orgLegForms != null)
            {
                var window = new WindowOrgLegForms(orgLegForms);
                window.ShowDialog();
                dgOrgLegForms.ItemsSource = OrgLegForms.GetList();
            }
        }

        void OrgLegForms_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var orgLegForms = dgOrgLegForms.SelectedItem as OrgLegForms;
            if (orgLegForms != null)
            {
                var dialog = MessageBox.Show("Удалить?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    OrgLegForms.Delete(orgLegForms);
                    dgOrgLegForms.ItemsSource = OrgLegForms.GetList();
                }
            }
        }

        void OrgRegistration_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowOrgRegistration();
            window.ShowDialog();
            dgOrgRegistration.ItemsSource = OrgRegistration.GetList();
        }

        void OrgRegistration_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var orgRegistration = dgOrgRegistration.SelectedItem as OrgRegistration;
            if (orgRegistration != null)
            {
                var window = new WindowOrgRegistration(orgRegistration);
                window.ShowDialog();
                dgOrgRegistration.ItemsSource = OrgRegistration.GetList();
            }
        }

        void OrgRegistration_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var orgRegistration = dgOrgRegistration.SelectedItem as OrgRegistration;
            if (orgRegistration != null)
            {
                var dialog = MessageBox.Show("Удалить?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    OrgRegistration.Delete(orgRegistration);
                    dgOrgRegistration.ItemsSource = OrgRegistration.GetList();
                }
            }
        }

    }
}

       
