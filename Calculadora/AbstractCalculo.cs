using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
   public abstract class AbstractCalculo : Form1
    { 
        // propriedades autoimplementadas abstratas
        public abstract double valorVisor { set; get; }
        public abstract double valorAnterior { set; get; }
        public abstract double valorResultado { set; get; }
        public abstract string operacao { set; get; }

        public abstract double Calculo(); // Método abstrato do tipo double
        }
    }

