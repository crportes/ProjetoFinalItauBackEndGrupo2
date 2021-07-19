using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ProjetoFinalItauBackEndGrupo2.models
{
    public class Conta
    {

        public int Numero { get; set; }
        public int Tipo { get; set; }
        public int Agencia { get; set; }

        public Double Saldo { get; set; }

        public int Codigo { get; set; }

        public static List<Conta> Lista(string sqlWhere = "")
        {
            var conta = new List<Conta>();
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            string sqlCnn = jAppSettings["ConexaoMysql"].ToString();
            using (var connection = new MySqlConnection(sqlCnn))
            {
                connection.Open();

                using (var command = new MySqlCommand($"SELECT * FROM conta {sqlWhere}", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            conta.Add(new Conta()
                            {
                                Numero = Convert.ToInt32(reader["numero"]),
                                Tipo = Convert.ToInt32(reader["tipo"]),
                                Agencia = Convert.ToInt32(reader["agencia"]),
                                Saldo = Convert.ToDouble(reader["saldo"]),
                                Codigo = Convert.ToInt32(reader["codigo"])
                            });
                        }
                    }
                }
            }

            return conta;
        }

        public static List<Conta> BuscaPorCliente(int codigoInterno)
        {
            return Conta.Lista("Where codigo = " + codigoInterno);
        }

        public static Conta BuscaPorId(int id)
        {
            return Conta.Lista("where codigo =" + id)[0];
        }
    }
}