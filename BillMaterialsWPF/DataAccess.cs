using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BillMaterialsWPF
{
    public class DataAccess
    {
        static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2016; 
            Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; 
            ApplicationIntent = ReadWrite; MultiSubnetFailover = False";


        //Return all the assembled products of the database
        public List<AssembledProduct> GetAssembledProducts()
        {
            List<AssembledProduct> products;
            string sql = $"SELECT distinct Production.Product.Name as Name,ProductAssemblyID" +
                                $" FROM Production.BillOfMaterials " +
                                $"JOIN Production.Product on Product.ProductID = ProductAssemblyID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                products = conn.Query<AssembledProduct>(sql).ToList();
            }
            return products;
        }


        //Return a component List of a assembled product
        public List<AssembledProduct> GetComponents(int productAssemblyID)
        {
            List<AssembledProduct> components;
            string sql = $"SELECT Production.Product.Name as Name,ProductAssemblyID,ComponentID" +
                                $" FROM Production.BillOfMaterials " +
                                $"JOIN Production.Product on Product.ProductID = ComponentID " +
                                $"WHERE ProductAssemblyID = {productAssemblyID}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                components = conn.Query<AssembledProduct>(sql).ToList();
            }
            return components;
        }
    }
}
