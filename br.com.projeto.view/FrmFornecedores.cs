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
    }
}