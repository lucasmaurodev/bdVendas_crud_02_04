using bdVendas.br.com.projeto.model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bdVendas.br.com.projeto.conexao;
using System.Data;

namespace bdVendas.br.com.projeto.dao
{
    public class FornecedoresDao
    {
        private MySqlConnection conexao;

        public FornecedoresDao()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarFornecedores

        public void CadastrarFornecedores(Fornecedores obj)
        {
            try
            {
                string sql = @"insert into tb_fornecedores( nome, email, cnpj, telefone, celular, cep, endereco, numero,complemento, bairro, cidade, estado) " +
                                              "values( @nome, @email, @cnpj, @telefone, @celular, @cep, @endereco, @numero,@complemento, @bairro, @cidade, @estado)";

                MySqlCommand executarcmd = new MySqlCommand(sql, conexao);

                executarcmd.Parameters.AddWithValue("@nome", obj.nome);
                executarcmd.Parameters.AddWithValue("@email", obj.email);
                executarcmd.Parameters.AddWithValue("cnpj", obj.cnpj);
                executarcmd.Parameters.AddWithValue("telefone", obj.telefone);
                executarcmd.Parameters.AddWithValue("celular", obj.celular);
                executarcmd.Parameters.AddWithValue("cep", obj.cep);
                executarcmd.Parameters.AddWithValue("endereco", obj.endereco);
                executarcmd.Parameters.AddWithValue("numero", obj.numero);
                executarcmd.Parameters.AddWithValue("complemento", obj.numero);
                executarcmd.Parameters.AddWithValue("bairro", obj.bairro);
                executarcmd.Parameters.AddWithValue("cidade", obj.cidade);
                executarcmd.Parameters.AddWithValue("estado", obj.estado);

                conexao.Open();
                executarcmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor Cadastrado com sucesso");

                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Aconteceu um erro:{erro}");
            }
        }

        #endregion CadastrarFornecedores

        #region ListarFornecedores

        public DataTable listarFornecedores()
        {
            try
            {
                DataTable tabelaFornecedores = new DataTable();
                string sql = "select * from tb_fornecedores";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedores);

                conexao.Close();

                return tabelaFornecedores;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + erro);

                return null;
            }
        }

        #endregion ListarFornecedores

        #region AlterarFornecedores

        public void ALterarFornecedores(Fornecedores obj)
        {
            try
            {
                string sql = @"update tb_fornecedores set nome=@nome, cnpj=@cnpj, email=@email, telefone=@telefone, celular=@celular, cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado";

                MySqlCommand executarcmd = new MySqlCommand(sql, conexao);

                executarcmd.Parameters.AddWithValue("@nome", obj.nome);
                executarcmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executarcmd.Parameters.AddWithValue("@email", obj.email);
                executarcmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executarcmd.Parameters.AddWithValue("@celular", obj.celular);
                executarcmd.Parameters.AddWithValue("@cep", obj.cep);
                executarcmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executarcmd.Parameters.AddWithValue("@numero", obj.numero);
                executarcmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executarcmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executarcmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executarcmd.Parameters.AddWithValue("@estado", obj.estado);

                conexao.Open();

                executarcmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor alterado com sucesso");

                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro:" + erro);
            }
        }

        #endregion AlterarFornecedores
    }
}