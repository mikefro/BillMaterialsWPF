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

        public List<AssembledProduct> PRODUCTS = da.GetAssembledProducts();

       // public List<string> PRODUCTS = new List<string> {"AL","pasar","la","BARCA"};


        public List<string> GetAssembledComponents(int assembledProductID)
        {
            return da.GetComponents(assembledProductID);
        }

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
    }
}
