using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BillMaterialsWPF
{
    public class AssembledProduct
    {
        public int productAssemblyID { get; set; }
        public int componentID { get; set; }
        public int BOMLevel { get; set; }
        public string Name { get; set; }
        public List<AssembledProduct> Components { get; set; }

    }
}
