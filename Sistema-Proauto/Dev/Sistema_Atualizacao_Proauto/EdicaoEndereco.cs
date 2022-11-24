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
    public partial class EdicaoEndereco : Form
    {
        private Cliente cliente;
        public EdicaoEndereco(Cliente cliente)
        {
            InitializeComponent();

            if (cliente != null)
            {
                // instanciando endereço e cliente para fazer as atualizações e salvar posteriormente
                Endereco endereco = new Endereco(cliente.getLogradouro(), cliente.getNumero(), cliente.getBairro(), cliente.getCep());
                this.cliente = new Cliente(cliente.getNome(), cliente.getCpf(), cliente.getPlaca(), cliente.getTelefone(), endereco);

                textBoxLogradouro.Text = endereco.getLogradouro();
                textBoxNumero.Text = endereco.getNumero().ToString();
                textBoxBairro.Text = endereco.getBairro();
                textBoxCEP.Text = endereco.getCep();
            }
            else
                MessageBox.Show("Erro: Cliente não encontrado.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.cliente.setEndereco(
                textBoxLogradouro.Text,
                int.Parse(textBoxNumero.Text),
                textBoxBairro.Text,
                textBoxCEP.Text
            );

            // cria arquivo temporário que receberá os dados atualizados
            string arquivoTemporario = Path.GetTempFileName();
            char separador = ';';

            using (var leitor = new StreamReader("usuarios.txt"))
            using (var escritor = new StreamWriter(arquivoTemporario))
            {
                string cpf = cliente.getCpf();
                string linha;

                while (!leitor.EndOfStream)
                {
                    linha = leitor.ReadLine();
                    // testa se a linha não é a que possui os dados antigos
                    if (linha.Split(separador)[0] != cpf)
                        escritor.WriteLine(linha);
                }
                // escreve a nova linha com os dados do usuário atualizados
                escritor.WriteLine(this.cliente.getCpf() + ";" +
                    this.cliente.getPlaca() + ";" +
                    this.cliente.getNome() + ";" +
                    this.cliente.getTelefone() + ";" +
                    this.cliente.getLogradouro() + ";" +
                    this.cliente.getNumero() + ";" +
                    this.cliente.getBairro() + ";" +
                    this.cliente.getCep() + ";"
                );
            }

            // apaga o arquivo com os dados antigos do usuário e salva o temporário como novo arquivo
            File.Delete("usuarios.txt");
            File.Move(arquivoTemporario, "usuarios.txt");

            DadosCliente paginaDadosCliente = new DadosCliente(this.cliente);
            paginaDadosCliente.Show();
            Close();
        }
    }
}
