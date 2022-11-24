using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sistema_Atualizacao_Proauto
{
    public partial class DadosCliente : Form
    {
        private Cliente cliente;
        // construtor de redirecionamento da página de login
        public DadosCliente(string cpf, string placa)
        {
            InitializeComponent();
            this.cliente = buscarUsuario(cpf, placa);

            if (cliente != null)
            {
                textBoxNome.Text = cliente.getNome();
                textBoxCPF.Text = cliente.getCpf();
                textBoxPlaca.Text = cliente.getPlaca();
                textBoxTelefone.Text = cliente.getTelefone();
                textBoxLogradouro.Text = cliente.getLogradouro();
                textBoxNumero.Text = cliente.getNumero().ToString();
                textBoxBairro.Text = cliente.getBairro();
                textBoxCEP.Text = cliente.getCep();
            }
            else
                MessageBox.Show("Erro: Cliente não encontrado.");
        }

        // construtor de retorno da página de edição de endereço
        public DadosCliente(Cliente cliente) {
            InitializeComponent();

            // insere os dados do cliente nos text boxes
            if (cliente != null)
            {
                textBoxNome.Text = cliente.getNome();
                textBoxCPF.Text = cliente.getCpf();
                textBoxPlaca.Text = cliente.getPlaca();
                textBoxTelefone.Text = cliente.getTelefone();
                textBoxLogradouro.Text = cliente.getLogradouro();
                textBoxNumero.Text = cliente.getNumero().ToString();
                textBoxBairro.Text = cliente.getBairro();
                textBoxCEP.Text = cliente.getCep();
            }
            else
                MessageBox.Show("Erro: Cliente não encontrado.");
        }

        public Cliente buscarUsuario(string cpf, string placa) // pode ser alterado para trabalhar com querys SQL
        {
            try
            {
                // lê os dados do usuário de um arquivo-texto e instancia um novo cliente com eles
                char separador = ';';
                string[] dados = new string[8];
                using (StreamReader leitor = new StreamReader("usuarios.txt"))
                {
                    while (!leitor.EndOfStream)
                    {
                        dados = leitor.ReadLine().Split(separador);
                        if (dados[0] == cpf && dados[1] == placa)
                        {
                            Endereco enderecoCliente = new Endereco(dados[4], int.Parse(dados[5]), dados[6], dados[7]);
                            Cliente cliente = new Cliente(dados[2], dados[0], dados[1], dados[3], enderecoCliente);
                            return cliente;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EdicaoEndereco paginaEdicaoEndereco = new EdicaoEndereco(this.cliente);
            paginaEdicaoEndereco.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Close();
        }
    }
}
