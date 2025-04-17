using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdVendas.br.com.projeto.model
{
    public class Pessoa
    {
        public string nome { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, int id, string email, string telefone, string celular, string cep, string endereco, string numero, string complemento, string bairro, string cidade, string estado)
        {
            this.nome = nome;
            this.id = id;
            this.email = email;
            this.telefone = telefone;
            this.celular = celular;
            this.cep = cep;
            this.endereco = endereco;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cidade = cidade;
            this.estado = estado;
        }
    }
}