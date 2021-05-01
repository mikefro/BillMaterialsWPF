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
        public int componentID;

        public int GetProductAssemnblyID()
        {
            return productAssemblyID;
        }

        public void SeComponentID(int value)
        {
            componentID = value;
        }

        public int GetComponentID()
        {
            return componentID;
        }

        public void SetProductAssemblyID(int value)
        {
            productAssemblyID = value;
        }

        public string Name { get; set; }
        public List<AssembledProduct> Components { get; set; }

    }
}
