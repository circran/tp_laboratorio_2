using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        public Universitario() :base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Retorna un string con todos los datos de un universitario 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.ToString());
            retorno.AppendLine("LEGAJO NÚMERO: " + this.legajo);

            return retorno.ToString();
        }
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Usa la sobrecarga del == en el metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Universitario)
                retorno = this == (Universitario)obj;

            return retorno;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Un Universitario sera igual a otro si son el mismo tipo y si su dni o legajo son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.GetType() == pg2.GetType())
                if((pg1.DNI == pg2.DNI) || (pg1.legajo == pg2.legajo))
                    retorno = true;

            return retorno;
        }

        /// <summary>
        /// Operacion opuesta al == 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
