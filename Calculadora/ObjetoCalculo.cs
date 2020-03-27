using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    // classe objetoCalculo herdado  a classe abstrata AbstractCalculo 
    public class ObjetoCalculo : AbstractCalculo
    {
        internal static ObjetoCalculo novoCalculo;

        // Propriedades referentes ao cáculo a ser realizado, herdadoda classe abstrata AbstractCalculo
        public override double valorVisor { set; get; }
        public override double valorAnterior { set; get; }
        public override double valorResultado { set; get; }

        public override string operacao { set; get; }

        // método para realizar a operação de cálculo, herdado da classe abstrata AbstractCalculo
        public override double Calculo()
        {
        
                switch (operacao)
                {
                    case "+":
                        valorResultado = valorAnterior + valorVisor;
                        break;

                    case "-":
                        valorResultado = valorAnterior - valorVisor;
                        break;

                    case "x":
                        valorResultado = valorAnterior * valorVisor;
                        break;

                    case "/":
                        valorResultado = valorAnterior / valorVisor;
                        break;

                    case "√":
                        /*double valorRaiz = valorVisor;

                        for (int i = 0; i < 10; i++)
                        {
                            valorRaiz = (valorRaiz / 2) + valorVisor / (2 * valorRaiz);
                        }

                        valorResultado = valorRaiz;*/
                        break;

                    default:
                        break;
                }
            
        }
    }
}

        
           
        
