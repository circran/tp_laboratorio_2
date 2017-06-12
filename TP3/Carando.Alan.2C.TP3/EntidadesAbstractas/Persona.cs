using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Extranjero, Argentino }

        private string _apellido;
        private string _nombre;
        private int _dni;
        private ENacionalidad _nacionalidad;

        #region Constructores

        public Persona()
        {
            //this._apellido = "";
            //this._nombre = "";
            //this._nacionalidad = ENacionalidad.Extranjero;
            //this._dni = 0;
        }

        public Persona(string nombre,string apellido,ENacionalidad nacionalidad) :this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre,string apellido,int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre,string apellido, string dni,ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de Lectura y Escritura asociada al atributo dni
        /// Pasa el dni en formato string a int y luego valida que este sea correcto
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura asociada al atributo _dni
        /// Valida que el numero de dni sea correcto y lo carga en el atributo
        /// </summary>
        public int DNI
        {
            get { return this._dni; }
           
            set
            {  
                this._dni = this.ValidarDni(this._nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura asociada al atributo _nombre
        /// Valida que el nombre contenga caracteres validos y luego lo guarda en el atributo
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura asociada al atributo _apellido
        /// Valida que el apellido contenga caracteres validos y luego lo guarda en el atributo
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad de lectura y escritura asociada al atributo _nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999. 
        /// Caso contrario, se lanzará la excepción DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Extranjero:
                    {
                        if (dato < 89999999)
                            throw new NacionalidadInvalidaException();
                        break;
                    }
                    
                case ENacionalidad.Argentino:
                    {
                        if (dato < 1 || dato > 89999999)
                            throw new DniInvalidoException();
                        break;
                    }
            }

            return dato;
        }

        /// <summary>
        /// Trata de pasar el string recivo en dato a entero, de ser posible valida que este dentro los limites 
        /// correspondientes para su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;

            if (int.TryParse(dato, out retorno))
            {
                retorno = this.ValidarDni(nacionalidad, retorno);
            }
                

            return retorno;
        }

        /// <summary>
        /// Valida que el el string que recibo como parametro contenta solo caracteres validos 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char letra in dato)
            {
                if (!char.IsLetter(letra))
                {
                    dato = "";
                    break;
                }
            }
            return dato;
        }

        /// <summary>
        /// Retorna un string con todos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            retorno.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());

            return retorno.ToString();
        }

        #endregion
    }
}
