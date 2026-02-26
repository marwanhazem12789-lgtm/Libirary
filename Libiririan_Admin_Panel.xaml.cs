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
    /// Interaction logic for Libiririan_Admin_Panel.xaml
    /// </summary>
    public partial class Libiririan_Admin_Panel : Page
    {
        public Libiririan_Admin_Panel()
        {
            InitializeComponent();
            Page_Loaded();
        }


       private void Page_Loaded()
        {
            using(LibiraryEntities ll = new LibiraryEntities())
            {
                dgProducts.ItemsSource = ll.Books.ToList();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using(LibiraryEntities ll = new LibiraryEntities())
            {
                Book b = new Book();
                b.Title = txtTit.Text;
                b.Author = txtAuthor.Text;
                b.Category = txtCategory.Text;
                b.Quantity = int.TryParse(txtQuantity.Text , out int quantity) ? quantity : 0;
                b.ISBN = "TEMP-" + DateTime.Now.Ticks.ToString().Substring(10);
                b.Description = "No description";
                b.CoverImagePath = "Images/default.jpg";

                ll.Books.Add(b);
                ll.SaveChanges();

            }
           Page_Loaded();
           MessageBox.Show("Book added successfully!");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Book b = dgProducts.SelectedItem as Book;



            using (LibiraryEntities ll = new LibiraryEntities())
            {
                if (b != null)
                {
                    var bookToUpdate = ll.Books.FirstOrDefault(x => x.Id == b.Id);
                    if (bookToUpdate != null)
                    {
                        bookToUpdate.Title = txtTit.Text;
                        bookToUpdate.Author = txtAuthor.Text;
                        bookToUpdate.Category = txtCategory.Text;
                        bookToUpdate.Quantity = int.TryParse(txtQuantity.Text, out int quantity) ? quantity : 0;
                        ll.SaveChanges();
                        MessageBox.Show("Book updated successfully!");
                    }
                }
            }
             Page_Loaded();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Book b = dgProducts.SelectedItem as Book;
            if (b == null)
            { 
                MessageBox.Show("Please select a book to delete."); 
                return;
            }

            if (MessageBox.Show("Are you Sure To Delete This Book?" , "Quistion" , MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (LibiraryEntities ll = new LibiraryEntities())
                {
                     var selectedBook = ll.Books.FirstOrDefault(x => x.Id == b.Id);
                    if (selectedBook != null)
                    {
                        ll.Books.Remove(selectedBook);
                        ll.SaveChanges();
                        MessageBox.Show("Book deleted successfully!");
                    }
                }
                Page_Loaded();
            }
        }
       
        

        private void btnserach_Click(object sender, RoutedEventArgs e)
        {
            using (LibiraryEntities ll = new LibiraryEntities())
            {
                dgProducts.ItemsSource = ll.Books.Where(x => x.Title.Contains(txtTit.Text)).ToList();
            }
        }
    }
}
