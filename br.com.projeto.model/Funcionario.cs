using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdVendas.br.com.projeto.model
{
    internal class Funcionario : Pessoa
    {
        private string rg { get; set; }
        private string cpf { get; set; }
        private string senha { get; set; }
        private string cargo { get; set; }
        private string nivel_acesso { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(string rg, string cpf, string senha, string cargo, string nivel_acesso) : base(nome, id, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)
        {
        }
    }
}