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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        User u;
        public Signup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtpass1.Password == txtpass2.Password)
            {
                MessageBox.Show("Password Matching");
            }
            else if (txtpass1.Password == "" || txtpass2.Password == "")
            {
                MessageBox.Show("Please enter password");
            }
            else
            {
                MessageBox.Show("Password Not Matching");
            }
            using (LibiraryEntities ll = new LibiraryEntities())

            {
                string select = "";
                if (o1.IsChecked == true)
                {
                    select = "member";
                }
                else if (o2.IsChecked == true)
                {
                    select = "librarian";
                }
                else
                {
                    MessageBox.Show("Please select a role");
                }

                u = new User
                {
                    FullName = txtname.Text,
                    Email = txtem.Text,
                    Password = txtpass1.Password,
                    Role = select
                };


                ll.Users.Add(u);
                ll.SaveChanges();
                MessageBox.Show("User Created Successfully");

                this.NavigationService.Navigate(new Book_Filter());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new login());
        }
    }
    
}
