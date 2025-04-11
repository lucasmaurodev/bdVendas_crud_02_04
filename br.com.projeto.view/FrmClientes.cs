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

            LimparFormulario();
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

            dao.alterarCliente(obj);

            MessageBox.Show("Cliente Alterado com sucesso");

            TabelaCliente.DataSource = dao.listarClientes();
            LimparFormulario();
        }

        private void TabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = TabelaCliente.CurrentRow.Cells[0].Value.ToString();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ClienteDao obj = new ClienteDao();

            TabelaCliente.DataSource = obj.listarClientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == null)
            {
                return;
            }

            Cliente obj = new Cliente();

            obj.id = int.Parse(txtCodigo.Text);

            ClienteDao dao = new ClienteDao();

            dao.exluirCliente(obj);

            TabelaCliente.DataSource = dao.listarClientes();
        }

        private void TabelaCliente_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = TabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = TabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = TabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = TabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = TabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = TabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = TabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtCep.Text = TabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = TabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = TabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplento.Text = TabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = TabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = TabelaCliente.CurrentRow.Cells[12].Value.ToString();
            cbEstado.Text = TabelaCliente.CurrentRow.Cells[13].Value.ToString();

            tabClientes.SelectedTab = tabPage1;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;

            ClienteDao dao = new ClienteDao();

            TabelaCliente.DataSource = dao.BuscarCliente(nome);

            if (TabelaCliente.Rows.Count == 0)
            {
                TabelaCliente.DataSource = dao.BuscarCliente(nome);
            }
        }

        #region LimparFormulario

        public void LimparFormulario()
        {
            foreach (Control control in tabPage1.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                if (control is MaskedTextBox)
                {
                    ((MaskedTextBox)control).Clear();
                }
            }
        }

        #endregion LimparFormulario

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }
    }
}