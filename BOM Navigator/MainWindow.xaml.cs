using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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
            levelTextBlock.Text = $"BOM LEVEL {products[0].BOMLevel}";

        }
        private void bomListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AssembledProduct ap;

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

                    levelTextBlock.Text = $"BOM LEVEL {products[0].BOMLevel}";

                    if (products[0].BOMLevel > 1)
                        upButton.IsEnabled = true;
                }
            }
        }

        private void upButton_Click(object sender, RoutedEventArgs e)
        {
            products = new List<AssembledProduct>();

            if (parentProductTree.Count > 1)
            {
                products = da.GetComponents(parentProductTree[parentProductTree.Count - 2]);
            }
            else
            {
                products = da.GetAssembledProducts();
                upButton.IsEnabled = false;
            }

            bomListBox.ItemsSource = null;
            bomListBox.Items.Clear();
            bomListBox.ItemsSource = products;
            parentProductTree.RemoveAt(parentProductTree.Count - 1);
            levelTextBlock.Text = $"BOM LEVEL {products[0].BOMLevel}";
        }

        /*
        private void ItemOnPreviewMouseDown(
            object sender, MouseButtonEventArgs e)
        {
            ListBoxItem lbi = (ListBoxItem)sender;
        //    AssembledProduct ap = (AssembledProduct) lbi;

        }
        */
        /*
        private void OnMouseMove(object sender, MouseEventArgs e)
                {

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
                            ListBoxItem listBoxItem = (ListBoxItem)sender;
                  //  listBoxItem.Style.

                        }
                        else
                        {
                            this.Cursor = Cursors.Arrow;
                        }

                    }
        */
                }
    }



