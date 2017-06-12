using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    { 
        public enum EClases { Programacion , Laboratorio, Legislacion, SPD }

        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;

        #region Constructor
        
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura asociada al atributo Lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura asociada al atributo Lista de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura asociada al atributo Lista de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura asociada al indice de jornada que reciba
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Serealiza una universidad en formato xml. Guardandolo en donde este alojado .exe
        /// En caso de ser guardado correctamente retorna true sino, false
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad u)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml",u);
        }

        /// <summary>
        /// Lee el archivo xml, lo dezerealiza retornando la universidad como fue guardada.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out retorno);

            return retorno;
        }
        /// <summary>
        /// Retorna un string con todos los datos de la universidad. Cada jornada, cada alumno y profesor.
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad u)
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("JORNADA: ");

            foreach (Jornada jornada in u.jornada)
            {
                retorno.AppendLine(jornada.ToString());
                retorno.AppendLine("<------------------------------------------------------->");
            }

            return retorno.ToString();
        }
        /// <summary>
        /// Hace publico un string con todos los datos de la universidad 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Un alumno sera igual a una universidad si esta anotado en esta.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in u.alumnos)
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
        /// Un alumno sera distinto de una universidad si no esta anotado en esta
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Un Profesor sera igual a una universidad si este da clases en ella.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            bool retorno = false;

            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == p)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Un profesor sera disintito de una universidad si no da clases en ella
        /// </summary>
        /// <param name="u"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Si en la universidad hay un profesor que de esa clase, retornara el profesor.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;
                foreach (Profesor profesor in u.profesores)
                {
                    if (profesor == clase)
                    {
                        retorno = profesor;
                        break;
                    }
                }

                if (retorno == null)
                    throw new SinProfesorException();

                return retorno;


        }

        /// <summary>
        /// Retornara el primer profesor que no de la clase que recibe como parametro
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor != clase)
                {
                    retorno = profesor;
                    break;
                }
            }

            if (retorno == null)
                throw new SinProfesorException();

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Jornada jornada = null;
            byte flag = 0;
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == clase)
                {
                    jornada = new Jornada(clase, profesor);
                    flag = 1;
                    break;
                }
            }

            if(flag == 0)
            {
                throw new SinProfesorException();
            }              
            else
            {
                foreach (Alumno alumno in u.alumnos)
                {
                    if (alumno == clase)
                    {
                        jornada += alumno;
                    }
                }

                u.jornada.Add(jornada);    
            }

            return u;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return u;
        }

        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
                u.profesores.Add(p);

            return u;
        }
        #endregion
    }
}
