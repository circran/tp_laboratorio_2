using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifico que no se pueda agregar un alumno repetido a la universidad
        /// En caso de estar repetido se lanzara la excepcion AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void ValidacionAlumnoRepetidoException()
        {
            try
            {
                Universidad universidad = new Universidad();

                Alumno a1 = new Alumno(1, "Miguel", "Gimenez", "38304521", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

                universidad += a1;

                Alumno a2 = new Alumno(2, "Nicolas", "Vazquez", "38304521", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                //Agrego a la universidad un Alumno con el mismo DNI
                universidad += a2;

                Assert.Fail("Sin excepción para Alumno repetido: {0}.", a2.ToString());
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Verifica que no se pueda agregar letras en el numero de dni con formato String
        /// </summary>
        [TestMethod]
        public void ValidacionArchivosException()
        {
            //Trato de generar un archivo con una universidad nula
            try
            {
                Universidad u = null;
                Universidad.Guardar(u);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }
        }

        /// <summary>
        /// Comprueba que las Listas en la clase Universidad no contengan un valor nulo
        /// </summary>
        [TestMethod]
        public void ComprobarAtributosDeUniversidad()
        {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
            Assert.IsNotNull(universidad.Alumnos);
        }

        /// <summary>
        /// Verifica que solo se puedan cargar dni dentro de los limites permitidos
        /// Argentino: min 1 - max 89999999
        /// Extrajero:  min 89999999
        /// </summary>
        [TestMethod]
        public void NumeroDeDniValido()
        {

            //Verifica que el dni se pase correctamente de string a entero
            string dniCorrecto = "72321514";
            Profesor p1 = new Profesor(1, "Fernando", "Lopez", dniCorrecto, Persona.ENacionalidad.Argentino);

            Assert.AreEqual(72321514, p1.DNI);

            
            try
            {
                //Verifica que el dni incorrecto no sea cargado
                string dniSuperior = "90000000";
                Alumno a1 = new Alumno(1, "Fernando", "Lopez", dniSuperior, Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            try
            {
                Universidad universidad = new Universidad();

                //Agrego un dni con numero superior al permitido
                Alumno a1 = new Alumno(1, "Miguel", "Gimenez", "388w2451", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            try
            {
                //Verifica que un DNI inferior al permitido no sea cargado
                string dniInferior = "-1";
                Profesor p2 = new Profesor(1, "Fernando", "Lopez", dniInferior, Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
    }
}
