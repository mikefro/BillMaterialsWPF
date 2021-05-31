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
using BillMaterialsWPF;

namespace BOM_Navigator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static DataAccess da = new DataAccess();

        List<int> parentProductTree = new List<int>();

        //Constant List with all the assembledProducts
        public List<AssembledProduct> products;

        public MainWindow()
        {
            InitializeComponent();
            products = da.GetAssembledProducts();
            bomListBox.ItemsSource = products;
            levelTextBlock.Text = $"BOM LEVEL {products[0].bomLevel} ParentProductTree {parentProductTree.Count}";

        }
        private void bomListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AssembledProduct ap = null;

            ap = (AssembledProduct)bomListBox.SelectedItem;

            if (ap != null)
            {
                parentProductTree.Add(ap.componentID);

                products = new List<AssembledProduct>();
                products = da.GetComponents(ap.componentID);
                if (products.Count > 0)
                {
                    bomListBox.ItemsSource = null;
                    bomListBox.Items.Clear();
                    bomListBox.ItemsSource = products;

                    levelTextBlock.Text = $"BOM LEVEL {products[0].bomLevel} ParentProductTree {parentProductTree.Count}";

                    if (products[0].bomLevel > 1)
                        upButton.IsEnabled = true;
                }
            }
        }

        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            if (parentProductTree.Count !=0)
            {
                products = new List<AssembledProduct>();
                products = da.GetComponents(parentProductTree[parentProductTree.Count - 1]);
                if (products.Count > 0)
                {
                    bomListBox.ItemsSource = null;
                    bomListBox.Items.Clear();
                    bomListBox.ItemsSource = products;
                    parentProductTree.RemoveAt(parentProductTree.Count - 1);
                    levelTextBlock.Text = $"BOM LEVEL {products[0].bomLevel}";

                    if (products[0].bomLevel > 1)
                    {
                        
                    }
                    else
                    {
                        upButton.IsEnabled = false;

                    }
                }
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
          /*  
            var item = VisualTreeHelper.HitTest(bomListBox, Mouse.GetPosition(bomListBox)).VisualHit;

            // find ListViewItem (or null)
            while (item != null && !(item is ListBoxItem))
                item = VisualTreeHelper.GetParent(item);

            if (item != null)
            {
                int i = bomListBox.Items.IndexOf(((ListBoxItem)item).DataContext);

                var p = da.GetComponents(products[i].componentID);
                if (p.Count > 0)
                {
                    this.Cursor = Cursors.Hand;
                }

            }
         */   
        }
    }
}

