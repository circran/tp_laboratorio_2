using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numero
{
    public class numero
    {
        private double _numero;

        //Inicializa _numero en 0
        public numero()
        {
            this._numero = 0;
        }

        //Inicializa _numero apartir de un string
        public numero(string str)
        {
            this.setNumero(str);
        }
        
        //Inicializa _numero apartir de un double
        public numero(double numeroDouble)
        {
            this._numero = numeroDouble;
        }

        //Retorna el valor almacenado en la variable _numero
        public double getNumero()
        {
            return this._numero;
        }

        //Recibe el numero como un string y utiliza el metodo validarNumero.
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }

        //Valida que se trate de un double valido, caso contrario retorna 0
        private static double validarNumero(string numeroString)
        {
            double retorno = 0;

            double.TryParse(numeroString, out retorno);

            return retorno;
        }
    }
}
