using bdVendas.br.com.projeto.dao;
using bdVendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bdVendas.br.com.projeto.view
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Receber os dados dentro do objeto modelo de clientes
            Cliente obj = new Cliente();

            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = txtNumero.Text;
            obj.complemento = txtComplento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbEstado.Text;

            // Criar um objeto da classeDAO e chamar o metedo cadastrar cliente
            ClienteDao dao = new ClienteDao();
            dao.cadastrarCliente(obj);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();

            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCep.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbEstado.Text;
            obj.id = int.Parse(txtCodigo.Text);

            ClienteDao dao = new ClienteDao();

            TabelaCliente.DataSource = dao.listarClientes();
        }

        private void TabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}