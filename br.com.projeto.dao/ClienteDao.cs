using bdVendas.br.com.projeto.conexao;
using bdVendas.br.com.projeto.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        #region ListarCLientes

        public DataTable listarClientes()
        {
            try
            {
                DataTable tabelaCliente = new DataTable();
                string sql = "select * from tb_clientes";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaCliente);

                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);

                return null;
            }
        }

        #endregion ListarCLientes

        #region AlterarCliente

        public void alterarCliente(Cliente obj)
        {
            try
            {
                string sql = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,cep=@cep,
                                  endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                                  where id=@id";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@enedereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);
                executacmd.Parameters.AddWithValue("@id", obj.id);

                conexao.Open();

                executacmd.ExecuteNonQuery();

                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro: " + erro);
            }
        }

        #endregion AlterarCliente
    }
}