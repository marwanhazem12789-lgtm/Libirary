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

namespace Library_Management_System
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (LibiraryEntities ll = new LibiraryEntities())
            {
                string username = txtname.Text;
                string password = txtpass1.Password;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter username and password");
                    return;
                }

                var user = ll.Users.FirstOrDefault(x => x.FullName == username && x.Password == password);

                if (user != null)
                {
                    if (user.Role == "member")
                    {
                        MessageBox.Show("Login Successe a Member" , "Successe" , MessageBoxButton.OK , MessageBoxImage.Information );
                        this.NavigationService.Navigate(new Book_Filter(user));
                    }
                    else if (user.Role == "Librarian")
                    {
                        MessageBox.Show("Login Successe a Libiririan", "Successe", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.NavigationService.Navigate(new Libiririan_Admin_Panel());
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password" , "Error" , MessageBoxButton.OK , MessageBoxImage.Error);
                }
            }
        }
    }
}
