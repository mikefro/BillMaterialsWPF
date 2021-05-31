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

namespace BOMTableNavigator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DataAccess da = new DataAccess();

        //Constant List with all the assembledProducts
        public List<AssembledProduct> PRODUCTS = da.GetAssembledProducts();

        public MainWindow()
        {
            InitializeComponent();
            bomListBox.ItemSource = PRODUCTS;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
