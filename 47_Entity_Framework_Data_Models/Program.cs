using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _47_Entity_Framework_Data_Models
{ //E aula 48
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void ConsultaCliente3()
        {
            var db = new CadastroEntities();
            var qry = from c in db.Contatos
                      select new
                      { Nome = c.Cliente.NomeCliente, Contato = c.Contato1 };
            foreach (var cli in qry)
            {
                Console.WriteLine(cli.Nome + " - " + cli.Contato);
            }
            Console.ReadKey();
        }

        private static void ConsultaClientes2()
        {
            var db = new CadastroEntities();
            var qry = from cli in db.Clientes
                      where cli.NomeCliente.Contains("r")
                      orderby cli.IdCliente descending
                      select cli;
            foreach (var c in qry)
            {
                Console.WriteLine(c.IdCliente.ToString() + " - " + c.NomeCliente + " - " + c.Email);
            }
            Console.ReadKey();
        }

        private static void ConsultarClientes1()
        {
            var db = new CadastroEntities();
            foreach (var cli in db.Clientes)
            {
                Console.WriteLine(cli.NomeCliente);
                foreach (var cont in cli.Contatos)
                {
                    Console.WriteLine(cont.Tipo);
                    Console.WriteLine(cont.Contato1);

                }

            }
            Console.ReadKey();
        }

        private static void PersistirObjetos()
        {
            var db = new CadastroEntities();
            var cli = new Cliente()
            {
                NomeCliente = "Stephane",
                Email = "Zé_roela@enchemuitosaco",

            };

            var cont1 = new Contato()
            {
                Tipo = "Email",
                Contato1 = "Stéphane",
                Cliente = cli
            };

            var cont2 = new Contato()
            {
                Tipo = "Telefone",
                Contato1 = "99897-4546",
                Cliente = cli
            };

            db.Contatos.Add(cont1);
            db.Contatos.Add(cont2);
            db.SaveChanges();

            Console.WriteLine("Registros inseridos com sucesso! ");
            Console.ReadKey();
        }
    }
}
