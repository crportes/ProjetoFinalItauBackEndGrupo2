using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.IO;

namespace 	ProjetoFinalItauBackEndGrupo2.models
{
    public class Cliente
    {

        public int CodigoInterno { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento{get;set;}
       public String Telefone {get;set;}
        public List<Conta> Contas { get { return Conta.BuscaPorCliente(this.CodigoInterno); } }

        public static List<Cliente> Lista(string sqlWhere = "")
        {
            var clientes = new List<Cliente>();
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            string sqlCnn = jAppSettings["ConexaoMysql"].ToString();
            using (var connection = new MySqlConnection(sqlCnn))
            {
                connection.Open();

                using (var command = new MySqlCommand($"SELECT * FROM cliente {sqlWhere}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente()
                            {
                                CodigoInterno = Convert.ToInt32(reader["codcliente"]),
                                Nome = reader["nome"].ToString(),
                                Email = reader["email"].ToString(),
                                CPF = reader["cpf"].ToString(),
                                DataNascimento = Convert.ToDateTime(reader["datanasc"]),
                                Telefone =reader ["telefone"].ToString()

                            });
                        }
                    }
                }
            }

            return clientes;
        }

        public static Cliente BuscaPorId(int id)
        {
            var clientes = Cliente.Lista("where codcliente =" + id);
            return clientes.Count > 0 ? clientes[0] : null;
        }
    }
}