using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _46_Relations
{
    class Program
    {
        static void Main(string[] args)
        {
            var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cadastro;Integrated Security=True;";
            var con = new SqlConnection(constr);
            var SQL1 = "select * from Cliente";
            var SQL2 = "select * from Contatos";
            var cmd1 = new SqlCommand(SQL1, con);
            var cmd2 = new SqlCommand(SQL2, con);
            var ds = new DataSet("Clientes");
            var da1 = new SqlDataAdapter(cmd1);
            var da2 = new SqlDataAdapter(cmd2);
            da1.Fill(ds, "Cliente");
            da2.Fill(ds, "Contatos");
            var dtCliente = ds.Tables[0];
            var dtContatos = ds.Tables[1];
            DataRelation relation = ds.Relations.Add(
                "ClientesContatos",
                dtCliente.Columns["IdCliente"],
                dtContatos.Columns["IdCliente"]
                
                );

            foreach (DataRow cli in dtCliente.Rows)
            {
                Console.WriteLine("Nome Cliente: " + cli[1].ToString());
                foreach (DataRow cont in cli.GetChildRows(relation))
                {
                    Console.WriteLine(cont[0].ToString() + " - " + cont[1].ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
