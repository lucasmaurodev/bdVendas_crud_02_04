using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdVendas.br.com.projeto.conexao
{
    public class ConnectionFactory
    {
        public MySqlConnection getconnection() // É criado um método com retorno MysqlConnection
        {
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;

            return new MySqlConnection(conexao);
        }
    }
}