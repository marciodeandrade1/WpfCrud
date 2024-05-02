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
using WpfCrud.Data;

namespace WpfCrud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProdutoDbContext context;
        Produto NewProduct = new Produto();
        Produto selectedProduct = new Produto();
        public MainWindow(ProdutoDbContext context)
        {
            this.context = context;
            InitializeComponent();
            GetProdutos();
            NewProductGrid.DataContext = context;
        }

        private void GetProdutos()
        {
            ProductDG.ItemsSource = context.Produtos.ToList();
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
            context.Produtos.Add(NewProduct);
            context.SaveChanges();
            GetProdutos();
            NewProduct = new Produto();
            NewProductGrid.DataContext = NewProduct;
        }
        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.Update(selectedProduct);
            context.SaveChanges();
            GetProdutos();
        }
        private void SelectProductToEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Produto;
            UpdateProductGrid.DataContext = selectedProduct;
        }
        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as Produto;
            context.Produtos.Remove(productToDelete);
            context.SaveChanges();
            GetProdutos();
        }
    }
}
