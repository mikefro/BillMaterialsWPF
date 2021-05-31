using BillMaterialsWPF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOM_Navigator
{
    public class TreeProduct
    {
        List<int> parentProductTree;


        public TreeProduct()
        {
            parentProductTree = new List<int>();
        }
/*
        public void addProduct(List<AssembledProduct> product)
        {
            parentProductTree.Add(product);
        }

        public void removeComponents(List<AssembledProduct> product)
        {
            parentProductTree.Remove(product);
        }

        public List<AssembledProduct> getBOMLevel()
        {
            return parentProductTree[parentProductTree.Count - 1];
        }
*/
    }
}
