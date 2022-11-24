using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Atualizacao_Proauto
{
    public class Cliente
    {
        private string nome;
        private string cpf;
        private string placa;
        private string telefone;
        private Endereco endereco;
        public Cliente(string nome, string cpf, string placa, string telefone, Endereco endereco)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.placa = placa;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public string getNome() { return this.nome; }
        public string getCpf() { return this.cpf; }
        public string getPlaca() { return this.placa; }
        public string getTelefone() { return this.telefone; }
        public string getLogradouro() { return this.endereco.getLogradouro(); }
        public int getNumero() { return this.endereco.getNumero(); }
        public string getBairro() { return this.endereco.getBairro(); }
        public string getCep() { return this.endereco.getCep(); }

        public void setEndereco(string logradouro, int numero, string bairro, string cep){
            this.endereco.setLogradouro(logradouro);
            this.endereco.setNumero(numero);
            this.endereco.setBairro(bairro);
            this.endereco.setCep(cep);
        }
    }
}
