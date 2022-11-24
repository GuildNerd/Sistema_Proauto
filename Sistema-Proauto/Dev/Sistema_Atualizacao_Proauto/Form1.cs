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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            bool resposta = buscarUsuario(textBoxCPF.Text, textBoxPlaca.Text);
            if (resposta == true)
            {
                DadosCliente formDadosCliente = new DadosCliente(textBoxCPF.Text, textBoxPlaca.Text);
                formDadosCliente.Show();
                Hide();
            }
            else
            {
                if (textBoxCPF.Text != "")
                {
                    if (textBoxPlaca.Text != "")
                        MessageBox.Show("CPF e(ou) placa não encontrado(s). Tente novamente.");
                    else
                        MessageBox.Show("Você precisa preencher o campo de placa corretamente. Não utilize símbolos, somente letras e números.");
                }
                else
                    MessageBox.Show("Você precisa preencher o campo de CPF. Não utilize símbolos ou letras, somente números.");
            }
        }

        public bool buscarUsuario(string cpf, string placa) // pode ser alterado para trabalhar com querys SQL
        {
            // utiliza arquivos-texto para buscar se os dados são válidos
            try
            {
                char separador = ';' ;
                string[] dados = new string[8];
                using (StreamReader leitor = new StreamReader("usuarios.txt"))
                {
                    while (!leitor.EndOfStream)
                    {
                        dados = leitor.ReadLine().Split(separador);
                        if (dados[0] == cpf && dados[1] == placa)
                            return true;
                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return false;
            }
        }
    }
}
