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
    /// Interaction logic for Book_Borrow.xaml
    /// </summary>
    public partial class Book_Borrow : Page
    {
        public Book_Borrow()
        {
            InitializeComponent();
            load();
        }
        public Book_Borrow(Book book)
        {
            InitializeComponent();
            this.DataContext = book;
            load();
        }
        private void load()
        {
            using (LibiraryEntities ll = new LibiraryEntities())
            {
                var ss = ll.BorrowRecords.Include("Book")
                           .Where(x => x.Status == "Borrowed")
                           .ToList();
                lstBorrowed.ItemsSource = ss;
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            var selectRecord = lstBorrowed.SelectedItem as BorrowRecord;

            if (selectRecord == null)
            {
                MessageBox.Show("Please select a record to return.");
                return;
            }

            using (LibiraryEntities ll = new LibiraryEntities())
            {
                var re = ll.BorrowRecords.FirstOrDefault(X => X.Id == selectRecord.Id);

                if (re != null)
                {
                    re.Status = "Returned";
                    re.ReturnDate = DateTime.Now; 

                    var bookToUpdate = ll.Books.FirstOrDefault(x => x.Id == re.BookId);
                    if (bookToUpdate != null)
                    {
                        bookToUpdate.Quantity += 1;
                    }

                    ll.SaveChanges();
                    MessageBox.Show("Book returned successfully!");
                }
            }
            load(); 
        }
    }
}
