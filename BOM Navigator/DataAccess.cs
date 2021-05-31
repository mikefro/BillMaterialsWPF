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
            string sql = $"SELECT distinct Production.Product.Name as Name,ProductAssemblyID,ComponentID,BOMLevel" +
                                            $" FROM Production.BillOfMaterials " +
                                            $"JOIN Production.Product on Product.ProductID = componentId " +
                                            $"WHERE EndDate is null and BOMLevel = 1 " +
                                            "order by name ";

            string esequele = $"SELECT distinct Product.Name as Name,ProductAssemblyID,BOMLevel " +
                                            $"FROM AdventureWorks2016.Production.BillOfMaterials " +
                                            $"JOIN AdventureWorks2016.Production.Product on ProductID = ProductAssemblyID " +
                                            $"WHERE EndDate is null and BOMLevel = 1";

            string skl = "SELECT  distinct ComponentID,Product.Name as Name FROM AdventureWorks2016.Production.BillOfMaterials " +
                "JOIN AdventureWorks2016.Production.Product on Product.ProductID = ComponentID " +
                "WHERE EndDate is null and BOMLevel = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                products = conn.Query<AssembledProduct>(skl).ToList();
            }
            return products;
        }

        //Return a component List of a assembled product
        public List<AssembledProduct> GetComponents(int productAssemblyID)
        {
            List<AssembledProduct> components;
            string sql = $"SELECT Production.Product.Name as Name,ProductAssemblyID,ComponentID,BOMLevel" +
                                $" FROM Production.BillOfMaterials " +
                                $"JOIN Production.Product on Product.ProductID = ComponentID " +
                                $"WHERE ProductAssemblyID = {productAssemblyID} and EndDate is null";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                components = conn.Query<AssembledProduct>(sql).ToList();
            }
            return components;
        }
    }
}
