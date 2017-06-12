using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.IO;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Constructor

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Retornara un string con todos los datos de una jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            //retorno.AppendLine("JORNADA:");
            retorno.Append("CLASE DE "+this._clase);
            retorno.Append("POR " + this._instructor.ToString());
            retorno.AppendLine("ALUMNOS: ");

            foreach (Alumno alumno in this._alumnos)
            {
                retorno.AppendLine(alumno.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Guardara un archivo de texto con nombre Jornada.txt, con todos los datos de una jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada j)
        {
            Texto texto = new Texto();

            return texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", j.ToString());
        }

        /// <summary>
        /// Retornara un string con todo el contenido del archivo.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string retorno;
            Texto texto = new Texto();

            texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out retorno);

            return retorno; 
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Una jornada es igual a un alumno si el alumno forma parte de ella
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in j._alumnos)
            {
                if(alumno == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Una jornada sera distinta de un alumno si el alumno no forma parte de ella
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Un alumno se podra sumar a la jornada si no forma ya parte de ella
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j._alumnos.Add(a);
            }

            return j;
        }

        #endregion
    }
}
