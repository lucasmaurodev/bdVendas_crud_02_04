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
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Fornecedores obj = new Fornecedores();
            obj.nome = txtNome.Text;
            obj.email = txtEmail.Text;
            obj.cnpj = txtCnpj.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCep.Text;
            obj.numero = txtNumero.Text;
            obj.complemento = txtComplento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbEstado.Text;

            FornecedoresDao dao = new FornecedoresDao();
            dao.CadastrarFornecedores(obj);

            LimparFormulario();
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

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            FornecedoresDao obj = new FornecedoresDao();

            tabelaFornecedores.DataSource = obj.listarFornecedores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Fornecedores obj = new Fornecedores();
            obj.nome = txtNome.Text;
            obj.cnpj = txtCnpj.Text;
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
            obj.id = int.Parse(txtCodigo.Text);

            FornecedoresDao daon = new FornecedoresDao();

            daon.ALterarFornecedores(obj);

            tabelaFornecedores.DataSource = daon.listarFornecedores();

            LimparFormulario();
        }

        private void tabelaFornecedores_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = tabelaFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtCnpj.Text = tabelaFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = tabelaFornecedores.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = tabelaFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = tabelaFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtCep.Text = tabelaFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = tabelaFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = tabelaFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtComplento.Text = tabelaFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = tabelaFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = tabelaFornecedores.CurrentRow.Cells[11].Value.ToString();
            cbEstado.Text = tabelaFornecedores.CurrentRow.Cells[12].Value.ToString();

            tabFornecedores.SelectedTab = tabPage1;
        }

        private void tabelaFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tabelaFornecedores.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo == null)
            {
                return;
            }

            Fornecedores obj = new Fornecedores();
            obj.id = int.Parse(txtCodigo.Text);

            FornecedoresDao dao = new FornecedoresDao();

            dao.ExcluirFornecedores(obj);

            tabelaFornecedores.DataSource = dao.listarFornecedores();
        }
    }
}