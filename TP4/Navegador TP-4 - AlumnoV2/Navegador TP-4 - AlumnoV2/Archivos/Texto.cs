using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;
            
        public Texto(string archivo)
        {
            this._archivo = Environment.CurrentDirectory + "\\" + archivo;
        }


        /// <summary>
        /// Escribe en un archivo de texto lo que recibe por el parametro datos
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter archivo = new StreamWriter(this._archivo, true))
                {
                    archivo.WriteLine(datos);
                    archivo.Close();
                }

                retorno = true;
                
            }
            catch (Exception e)
            {

                throw e;
            }

            return retorno;
        }

        /// <summary>
        /// Lee linea por linea un archivo texto, agregando cada linea en una lista de tipo String.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            bool retorno = false;
            string aux;
            
            try
            {
                using (StreamReader archivo = new StreamReader(this._archivo))
                {
                    while ((aux = archivo.ReadLine()) != null)
                    {
                        datos.Add(aux);
                    }
                }
                retorno = true;
            }
            catch (Exception e)
            {

                throw e;
            }

            return retorno;
        }
    }
}
