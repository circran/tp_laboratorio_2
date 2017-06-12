using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Escribe y guarda el string recibido por el parametro datos en un archivo. Si se pudo guardar correctamente retorna true
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);

                sw.WriteLine(datos);

                sw.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
                
            }

            return retorno;
            
        }
        /// <summary>
        /// Lee un archivo que recibo por parametro, retornando por el parametro de salida, datos, un string con lo leido
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                StreamReader sw = new StreamReader(archivo);

                datos = sw.ReadToEnd();

                sw.Close();
                retorno = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);

            }

            return retorno;
        }
    }
}
