using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public static class LibreriaMetodos
    {
        /// <summary>
        /// Crea un bool "exito" en false
        /// Valida que el objeto recibido por parametro no sea nulo, en caso de serlo mantiene el boolean en false, en caso contrario lo convierte a true.
        /// </summary>
        /// <returns>Devuelve el bool exito</returns>
        public static bool ObjetoValido(Object objeto)
        {
            bool exito = false;

            if (objeto != null)
            {
                exito = true;
            }
            return exito;
        }

        /// <summary>
        /// Crea un bool "exito" en false
        /// Valida que el string recibido por parametro no sea nulo o vacio, en caso de serlo mantiene el boolean en false, en caso contrario lo convierte a true.
        /// </summary>
        /// <returns>Devuelve el bool exito</returns>
        public static bool StringValido(string texto)
        {
            bool exito = false;
            if (string.IsNullOrEmpty(texto))
            {
                exito = false;
            }
            else
            {
                exito = true;
            }
            return exito;
        }

        /// <summary>
        /// Crea un bool "exito" en false
        /// Valida que el string no contenga un "@" o ".com" manteniendo el boolean en false, en caso contrario lo convierte a true.
        /// </summary>
        /// <returns>Devuelve el bool exito</returns>
        public static bool EmailValido(string campo)
        {
            bool exito = false;
            if (!campo.Contains("@") || !campo.EndsWith(".com"))
            {
                exito = false;
            }
            else
            {
                exito = true;
            }
            return exito;
        }

        /// <summary>
        /// Valida que el string recibido por parametro no este vacio o sea nulo, luego valida que el string contenga un "@" o ".com" informando al usuario.
        /// </summary>
        public static void ValidarEmail(string email)
        {
            if (!LibreriaMetodos.StringValido(email))
            {
                throw new Exception("El campo no puede ser vacio");
            }
            if (!LibreriaMetodos.EmailValido(email))
            {
                throw new Exception("Mail incorrecto");
            }
        }

        /// <summary>
        /// En un try castea el string dateTime recibido por parametro a un DateTime "fechaDeNacimiento" o en un catch devuelve un mensaje al usuario.
        /// </summary>
        /// <returns>Devuelve un fechaDeNacimiento casteada a DateTime</returns>
        public static DateTime ValidarDateTime(string dateTime)
        {
            try
            {
                DateTime fechaDeNacimiento = DateTime.Parse(dateTime);
                return fechaDeNacimiento;
            }
            catch (Exception)
            {
                throw new Exception("Debe ingresar una fecha valida");
            }
        }

        /// <summary>
        /// Valida que el string recibido por parametro no este vacio o sea nulo.
        /// </summary>
        public static void ValidarCampoVacio(string campo)
        {
            if (string.IsNullOrEmpty(campo))
            {
                throw new Exception("El campo no puede estar vacio");
            }
        }

        /// <summary>
        /// Valida que el string recibido por parametro no este vacio o sea nulo.
        /// Valida que el largo del texto recibido por parametro sea menor o igual a 50
        /// </summary>
        /// <returns>Devuelve un string vacio, un texto menor o igual a 50 o un texto recortado a 50 caracteres</returns>
        public static string AcortarString(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;
            if (texto.Length <= 50)
                return texto;
            return texto.Substring(0, 50);
        }

    }
}
