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
        public List<AssembledProduct> COMPONENTS, SUBCOMPONENTS;

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

            foreach (AssembledProduct assembledProduct in PRODUCTS)
            {
                assembledProduct.Components = da.GetComponents(assembledProduct.productAssemblyID);
            }

            productsListBox.ItemsSource = PRODUCTS;
        }


        //Show the components of a selected Assembled Product into Components ListBox
        /*        private void getComponentsButton_Click(object sender, RoutedEventArgs e)
                {
                    AssembledProduct ap = (AssembledProduct) productsListBox.SelectedItem;
                    COMPONENTS = da.GetComponents(ap.productAssemblyID);

                    foreach (AssembledProduct assembledProduct in COMPONENTS)
                    {
                        assembledProduct.Components = da.GetComponents(assembledProduct.GetComponentID());
                    }
                    componentsListBox.ItemsSource = COMPONENTS;

                }
        */

        //Close the aplication
        private void closeAppButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        //Show the components of a selected component Product into SubComponents ListBox
        /*      private void getSubComponentsButton_Click(object sender, RoutedEventArgs e)
                {
                    AssembledProduct ap = (AssembledProduct)componentsListBox.SelectedItem;
                    SUBCOMPONENTS = da.GetComponents(ap.componentID);

                    foreach (AssembledProduct assembledProduct in SUBCOMPONENTS)
                    {
                        assembledProduct.Components = da.GetComponents(assembledProduct.GetComponentID());
                    }

                    subComponentsListBox.ItemsSource = SUBCOMPONENTS;
                }
        */

        //replace click method by SelectionItem Change on the productsListbox
        private void productsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AssembledProduct ap = (AssembledProduct)productsListBox.SelectedItem;

            COMPONENTS = da.GetComponents(ap.productAssemblyID);

            foreach (AssembledProduct assembledProduct in COMPONENTS)
            {
                assembledProduct.Components = da.GetComponents(assembledProduct.GetComponentID());
            }
            componentsListBox.ItemsSource = COMPONENTS;
        }

        //replace click method by SelectionItem Change on the componentsListbox
        private void componentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AssembledProduct ap = (AssembledProduct)componentsListBox.SelectedItem;

            if (ap != null)
            {
                SUBCOMPONENTS = da.GetComponents(ap.componentID);

                foreach (AssembledProduct assembledProduct in SUBCOMPONENTS)
                {
                    assembledProduct.Components = da.GetComponents(assembledProduct.GetComponentID());
                }

                subComponentsListBox.ItemsSource = SUBCOMPONENTS;
            }
            else
            {
                subComponentsListBox.ItemsSource = null;
                subComponentsListBox.Items.Clear();
            }


        }
    }
}

