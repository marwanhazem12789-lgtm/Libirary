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
    /// Interaction logic for Book_List.xaml
    /// </summary>
    public partial class Book_List : Page
    {
        public Book_List()
        {
            InitializeComponent();
        }
        public Book_List(List<Book> book)
        {
            InitializeComponent();
            lstBooks.ItemsSource = book;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var select = lstBooks.SelectedItem as Book;

            if (select == null)
            {
                MessageBox.Show("Please select a book to view details.");
                return;
            }
            this.NavigationService.Navigate(new Book_Details(select));
        }
    }
}
