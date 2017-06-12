using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {

        /// <summary>
        /// Serealiza cualquier tipo que reciba como parametro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    XmlSerializer s = new XmlSerializer(typeof(T));

                    s.Serialize(sw, datos);
                    sw.Close();

                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Desealiza y retorna por la variable de salida los datos 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    XmlSerializer s = new XmlSerializer(typeof(T));

                    datos = (T)s.Deserialize(sr);
                    sr.Close();
                    retorno = true;
                }

            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
