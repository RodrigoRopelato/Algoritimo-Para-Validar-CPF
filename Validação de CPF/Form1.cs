using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validação_de_CPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbSituacao.Text = "";
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
                string stringCPF = ttbCPF.Text;
                if(stringCPF.Length == 11)
                    ValidarCPF(stringCPF);
                else
                    MessageBox.Show("O Campo do CPF esta incompleto!", "Mensagem do Sistema");
        }

        private void ValidarCPF(string cpf)
        {
            //para criar esse algoritimo foi utilizado como base o algoritimo do site: http://www.macoratti.net/alg_cpf.htm
            int resultado1 = 0;
            int resultado2 = 0;
            int dig1 = 0;
            int dig2 = 0;
            int[] vetorCpf = new int[11];
            for (int i = 0; i < vetorCpf.Length; i++)
                vetorCpf[i] = int.Parse(cpf[i].ToString());

            //primeira verificação, verifica os 9 primeiros digitos do CPF e faz o calculo para chegar no primeriro digito verificadr
            int num = 2;
            for (int i = 8; i >=0; i--)
            {
                resultado1 += vetorCpf[i] * num;
                num++;
            }
            //calcula e atribui o resultado do primeiro digito
            if (resultado1 % 11 < 2)
                dig1 = 0;
            else dig1 = 11 - (resultado1 % 11);

            //segunda verificação, inclui o primeiro digito verificador para chegar no segundo digito
            num = 2;
            for (int i = 9; i >= 0; i--)
            {
                resultado2 += vetorCpf[i] * num;
                num++;
            }
            //calcula e atribui o resultado do segundo digito
            if (resultado2 % 11 < 2)
                dig2 = 0;
            else dig2 = 11 - (resultado2 % 11);

            //compara digitos obtidos do algorito com os digitos fornecidos pelo usuario
            if (dig1 == vetorCpf[9] && dig2 == vetorCpf[10])
                lbSituacao.Text = "CPF Valido!";
            else
                lbSituacao.Text = "CPF Invalido!";
        }
    }
}
