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

namespace BillMaterialsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DataAccess da = new DataAccess();

        //Constant List with all the assembledProducts
        public List<AssembledProduct> PRODUCTS = da.GetAssembledProducts();

        //Set all the components into every Assembled Products
        public void SetAssembledComponents()
        {
            foreach (AssembledProduct assembledProduct in PRODUCTS)
            {
                assembledProduct.Components = da.GetComponents(assembledProduct.productAssemblyID);
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            SetAssembledComponents();
            productsListBox.ItemsSource = PRODUCTS;
        }

        //Show the components of a selected Assembled Product into Components ListBox
        private void getComponentsButton_Click(object sender, RoutedEventArgs e)
        {
            AssembledProduct ap = (AssembledProduct) productsListBox.SelectedItem;
            componentsListBox.ItemsSource = ap.Components;
        }

        //Close the aplication
        private void closeAppButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
