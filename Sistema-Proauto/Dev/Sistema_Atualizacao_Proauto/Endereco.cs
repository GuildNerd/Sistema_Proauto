using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Atualizacao_Proauto
{
    public class Endereco
    {
        private string logradouro;
        private int numero;
        private string bairro;
        private string cep;
        public Endereco(string logradouro, int numero, string bairro, string cep)
        {
            this.logradouro = logradouro;
            this.numero = numero;
            this.bairro = bairro;
            this.cep = cep;
        }

        public string getLogradouro() { return this.logradouro; }
        public int getNumero() { return this.numero; }
        public string getBairro() { return this.bairro; }
        public string getCep() { return this.cep; }

        public void setLogradouro(string logradouro) { this.logradouro=logradouro; }
        public void setNumero(int numero) { this.numero = numero; }
        public void setBairro(string bairro) { this.bairro = bairro; }
        public void setCep(string cep) { this.cep = cep; }
    }
}
