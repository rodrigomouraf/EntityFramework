using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters
{
    class Program
    {
        static void Main(string[] args)
        {
            var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cadastro;Integrated Security=True;";
            var con = new SqlConnection(constr);
            var SQL = "select * from Cliente";
            var cmd = new SqlCommand(SQL, con);
            var ds = new DataSet("CADASTRO");
            var da = new SqlDataAdapter(cmd);
            da.Fill(ds,"Cliente");
            var dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("ID Cliente: " + row[0].ToString());
                Console.WriteLine("Nome Cliente: " + row[1].ToString());
                Console.WriteLine("EMail Cliente: " + row[2].ToString());
            }
            dt.WriteXml("dados.xml");
            Console.ReadKey();
        }
    }
}
