using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillMaterialsWPF
{
    public class AssembledProduct
    {
        public int productAssemblyID;

        public int GetProductAssemnblyID()
        {
            return productAssemblyID;
        }

        private void SetProductAssemblyID(int value)
        {
            productAssemblyID = value;
        }

        public string Name { get; set; }
        public List<String> Components { get; set; }

    }
}
