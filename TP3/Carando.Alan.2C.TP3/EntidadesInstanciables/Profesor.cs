using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {

        private static Random _random;
        private Queue<Universidad.EClases> _clasesDelDia;

        #region Constructores

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
            this._randomClase();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
            this._randomClase();
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Asigna una clase al azar al profesor.
        /// </summary>
        private void _randomClase()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
        }
        /// <summary>
        /// Retorna un string con las clases que da este profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                retorno.AppendLine(item.ToString());
            }

            return retorno.ToString();
        }
        /// <summary>
        /// Retorna un string con los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine(this.ParticiparEnClase());

            return retorno.ToString();
        }
        /// <summary>
        /// Retorna un string con los datos del profesor haciendolos publicos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region operadores
        /// <summary>
        /// Un profesor es igual a una clase si da esa clase
        /// </summary>
        /// <param name="p"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases item in p._clasesDelDia)
            {
                if(item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Un Profesor es distinto a una clase si no da esa clase
        /// </summary>
        /// <param name="p"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }

        #endregion
    }
}
