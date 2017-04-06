using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numero;

namespace Calculadora
{
    public class calculadora
    {
        //Recibe 2 objetos del tipo numero y un string como operador. Valida que el operador sea correcto y 
        //realiza la operacion que corresponde.
        public static double Operar(Numero.numero numero1, Numero.numero numero2,string operador)
        {
            double resultado = 0;
            double primerNumero = numero1.getNumero();
            double segundoNumero = numero2.getNumero();

            operador = calculadora.ValidarOperador(operador);

            if (operador == "+")
                resultado = primerNumero + segundoNumero;
            else if (operador == "-")
                resultado = primerNumero - segundoNumero;
            else if (operador == "*")
                resultado = primerNumero * segundoNumero;
            else if (operador == "/" && segundoNumero != 0)
                resultado = primerNumero / segundoNumero;
            
            return resultado;
        }

        //Recibe el operador como string. Lo valida, en caso de no ser correcto retorna "+"
        public static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if (operador == "+")
                retorno = "+";
            if (operador == "-")
                retorno = "-";
            if (operador == "*")
                retorno = "*";
            if (operador == "/")
                retorno = "/";

            return retorno;
        }
    }
}
