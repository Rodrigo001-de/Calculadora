using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {

        double valorVisor = 0, valorAnterior = 0;
        string operacao = "";
        bool primeiraOperacao = true, botaoIgual = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn0_Click(object sender, EventArgs e) //Envento Click dos botões
        {
            if (txtVisor.Text == "0" || botaoIgual == true) //Se o visor estiver com o número 0
            {
                txtVisor.Clear();    //É para limpá-lo
                botaoIgual = false; //e deixa a variável botaoigual como false
            }

            Button botaoAcionado = (Button)sender; //O objeto botão que foi clicado será carregado

            switch (botaoAcionado.Name) //Verifica o nome do botão acionado
            {
                case "btn1":                    //Caso seja btn1
                    txtVisor.Text += "1";       //A propriedade Text do visor receberá o número 1
                    break;                      //Parar a verificação

                case "btn2":                    //Caso seja btn2
                    txtVisor.Text += "2";       //A propriedade Text do visor receberá o número 2
                    break;                      //Parar a verificação

                case "btn3":                    //Caso seja btn3
                    txtVisor.Text += "3";       //A propriedade Text do visor receberá o número 3
                    break;                      //Parar a verificação

                case "btn4":                    //Caso seja btn4
                    txtVisor.Text += "4";       //A propriedade Text do visor receberá o número 4
                    break;                      //Parar a verificação

                case "btn5":                    //Caso seja btn5
                    txtVisor.Text += "5";       //A propriedade Text do visor receberá o número 5
                    break;                      //Parar a verificação

                case "btn6":                    //Caso seja btn6
                    txtVisor.Text += "6";       //A propriedade Text do visor receberá o número 6
                    break;                      //Parar a verificação

                case "btn7":                    //Caso seja btn7
                    txtVisor.Text += "7";       //A propriedade Text do visor receberá o número 7
                    break;                      //Parar a verificação

                case "btn8":                    //Caso seja btn8
                    txtVisor.Text += "8";       //A propriedade Text do visor receberá o número 8
                    break;                      //Parar a verificação

                case "btn9":                    //Caso seja btn9
                    txtVisor.Text += "9";       //A propriedade Text do visor receberá o número 9
                    break;                      //Parar a verificação

                case "btn0":                    //Caso seja btn0
                    txtVisor.Text += "0";       //A propriedade Text do visor receberá o número 0
                    break;                      //Parar a verificação

                case "btnVirgula":                //Caso seja btnVirgula
                    if (txtVisor.Text == "")      //e se o txtVisor não tiver nenhum número
                    {
                        txtVisor.Text += "0,";    //A propriedade Text do visor receberá 0,
                    }
                    else                          //Senão   
                    {
                        txtVisor.Text += ",";     //Receberá ,
                    }
                    break;
                default:
                    break;
            }
        }   
        
        private void btnLimpar_Click(object sender, EventArgs e) //Botão responsável por limpar os campos e os atributos, "resetando" as configuraçãoes da calculadora
        {
            txtVisor.Clear();
            txtHistorico.Clear();
            valorAnterior = 0;
            valorVisor = 0;

            operacao = "";
            primeiraOperacao = true;
            botaoIgual = false;
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {
                valorAnterior = Convert.ToDouble(txtVisor.Text);

                if (botaoIgual == false)
                {
                    txtHistorico.Text += txtVisor.Text;
                }

                txtVisor.Clear();
                operacao = "/";
                primeiraOperacao = false;
            }
            else
            {
                ObjetoCalculo novoCalculo = new ObjetoCalculo();

                valorVisor = Convert.ToDouble(txtVisor.Text);

                txtHistorico.Text += operacao + txtVisor.Text;

                //txtVisor.Text = Convert.ToString(valorAnterior / valorVisor);
                txtVisor.Text = Convert.ToString(novoCalculo.Calculo());

                operacao = "/";
                txtHistorico.Text += "=" + txtVisor.Text;
                valorAnterior = Convert.ToDouble(txtVisor.Text);
                botaoIgual = true;
            }
        }

        private void btnIgual_Click(object sender, EventArgs e) //botão responsável por montar o resultado da operações
        {
            ObjetoCalculo novoCalculo = new ObjetoCalculo();

            valorVisor = Convert.ToDouble(txtVisor.Text);

            txtHistorico.Text += operacao + txtVisor.Text;

            txtVisor.Text = Convert.ToString(novoCalculo.Calculo());

            txtHistorico.Text += "=" + txtVisor.Text;

            valorAnterior = Convert.ToDouble(txtVisor.Text);

            botaoIgual = true;
            primeiraOperacao = true;
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (primeiraOperacao)
            {
                operacao = "√";
            }

            valorVisor = Convert.ToDouble(txtVisor.Text);
            txtHistorico.Text += operacao + txtVisor.Text;

            ObjetoCalculo novoCalculo = new ObjetoCalculo();

            novoCalculo.valorVisor = this.valorVisor;
            novoCalculo.valorAnterior = this.valorAnterior;
            novoCalculo.operacao = this.operacao;

            txtVisor.Text = Convert.ToString(novoCalculo.Calculo());

            operacao = "√";
            txtHistorico.Text += "=" + txtVisor.Text;
            valorAnterior = Convert.ToDouble(txtVisor.Text);

            if (novoCalculo.operacao != "√")
            {
                txtHistorico.Text += "=" + operacao + txtVisor.Text;

                valorVisor = Convert.ToDouble(txtVisor.Text);

                novoCalculo.operacao = this.operacao;
                novoCalculo.valorVisor = this.valorVisor;

                txtVisor.Text = Convert.ToString(novoCalculo.Calculo());

                txtHistorico.Text += "=" + txtVisor.Text;
            }
        }

        /*
         public double Calculo() //Método para verificar qual operação deverá ser realizada
         {
             switch (operacao)
             {
                 case "+":
                     valorAnterior = valorAnterior + valorVisor;
                     break;

                 case "-":
                     valorAnterior = valorAnterior - valorVisor;
                     break;

                 case "x":
                     valorAnterior = valorAnterior * valorVisor;
                     break;

                 case "/":
                     valorAnterior = valorAnterior / valorVisor;
                     break;

                 default:
                     break;
             }

             return valorAnterior;
         }
            */

        private void btnBackspace_Click(object sender, EventArgs e) //Botão reponsável por apagar o último número
        {
            txtVisor.Text = txtVisor.Text.Remove(txtVisor.Text.Length - 1);
        }

        private void btnAdicao_Click(object sender, EventArgs e) //Botão responsável por realizar somas
        {
            if (primeiraOperacao) //Se for a primeira operação realizada
            {
                valorAnterior = Convert.ToDouble(txtVisor.Text); //o valor passa a ser o que estiver no txtVisor

                if (botaoIgual == false) //se o botaoIgual estiver como false
                {
                    txtHistorico.Text += txtVisor.Text; //o txtHistorico adiciona o que estiver no txtVisor 
                }

                txtVisor.Clear(); //Limpa o txtVisor
                operacao = "+"; //determina que a operação realizada é adição 
                primeiraOperacao = false; //primeiraOperacao passa a ser false
            } 
            else //senão
            {
                valorVisor = Convert.ToDouble(txtVisor.Text); //converte o número do txtVisor

                txtHistorico.Text += operacao + txtVisor.Text; //o txtHistorico recebe a operacao e á soma com o que estiver no txtVisor

                //txtVisor.Text = Convert.ToString(valorAnterior + valorVisor); // realiza a soma dos números e exibe no txtVisor
                //txtVisor.Text = Convert.ToString(Calculo())  // realiza a soma dos números e exibe no txtVisor

                ObjetoCalculo novoCalculo = new ObjetoCalculo(); //instância a classe e cria o objeto novoCalculo

                //atribui os valores das variáveis globais às propriedades do objeto novoCalculo
                novoCalculo.valorVisor = this.valorVisor;
                novoCalculo.valorAnterior = this.valorAnterior;
                novoCalculo.operacao = this.operacao;

                txtVisor.Text = Convert.ToString(ObjetoCalculo.novoCalculo.Calculo());

                operacao = "+"; //determina que a operação realizada é adição
                txtHistorico.Text += "=" + txtVisor.Text; //txtHistorico recebe o sinal de =, + o que estiver no txtVisor
                valorAnterior = Convert.ToDouble(txtVisor.Text); //valor anterior passa a ser numeral
                botaoIgual = true; //a variável botaoIgual passa a ser true
            }
        }
    }
}
