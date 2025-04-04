using bdVendas.br.com.projeto.conexao;
using bdVendas.br.com.projeto.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bdVendas.br.com.projeto.dao
{
    public class ClienteDao
    {
        private MySqlConnection conexao;

        public ClienteDao()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarClientes

        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                //Definindo com Sql para o insert-
                string sql = @"insert into tb_clientes( nome, rg, cpf, email, telefone, celular, cep, endereco, numero,complemento, bairro, cidade, estado) " +
                                              "values( @nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero,@complemento, @bairro, @cidade, @estado)";

                //Organizar comando Sql

                MySqlCommand executadacmd = new MySqlCommand(sql, conexao);

                executadacmd.Parameters.AddWithValue("@nome", obj.nome);
                executadacmd.Parameters.AddWithValue("@rg", obj.rg);
                executadacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executadacmd.Parameters.AddWithValue("@email", obj.email);
                executadacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executadacmd.Parameters.AddWithValue("@celular", obj.celular);
                executadacmd.Parameters.AddWithValue("@cep", obj.cep);
                executadacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executadacmd.Parameters.AddWithValue("@numero", obj.numero);
                executadacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executadacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executadacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executadacmd.Parameters.AddWithValue("@estado", obj.estado);

                //Abrir a conexão e executar comando Sql

                conexao.Open();
                executadacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Cadastrado com sucesso");

                //Fechando a conexão com o banco de dados

                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Aconteceu um erro:{erro}");
            }
        }

        #endregion CadastrarClientes
    }
}