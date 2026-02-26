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
    /// Interaction logic for Book_Filter.xaml
    /// </summary>
    public partial class Book_Filter : Page
    {
        public Book_Filter()
        {
            InitializeComponent();
        }
        public Book_Filter(Book book)
        {

            InitializeComponent();
        }
        public Book_Filter(User user)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (LibiraryEntities ll = new LibiraryEntities())
            {
                var se = ll.Books.AsQueryable();

                if (combo.SelectedItem is ComboBoxItem selectedItem)
                {
                    string status = selectedItem.Content.ToString();

                    if (status == "Available Books")
                    {
                        se = se.Where(x => x.Quantity > 0);
                    }
                    else if (status == "Borrowed Books") 
                    {
                        se = se.Where(x => x.Quantity == 0);
                    }
                }

                if (o1.IsChecked == true)
                {
                    se = se.Where(x => x.Category == "Programming");
                }
                else if (o2.IsChecked == true)
                {
                    se = se.Where(x => x.Category == "Database");
                }
                else if (o3.IsChecked == true)
                {
                    se = se.Where(x => x.Category == "Computer Science");
                }
                else if (o4.IsChecked == true)
                {
                    se = se.Where(x => x.Category == "AI");
                }
                else if (chec.IsChecked == true)
                {
                    se = se.Where(x => x.Quantity > 0);
                }

                var s = se.ToList();

                this.NavigationService.Navigate(new Book_List(s));
            }

        }

    }
}
