using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public abstract class Usuario
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }

        //Constructor
        public Usuario(string email, string contrasena)
        {
            Email = email;
            Contrasena = contrasena;
        }
        
        //Validaciones
        public void Validar()
        {
            ValidarEmail();
            ValidarContrasena();
        }

        /// <summary>
        /// Valida que el string recibido por parametro no este vacio o sea nulo, luego valida que el string contenga un "@" o ".com" informando al usuario.
        /// </summary>
        public void ValidarEmail()
        {
            LibreriaMetodos.ValidarEmail(Email);
        }

        /// <summary>
        /// Valida que el string no sea nulo o vacio.
        /// </summary>
        public void ValidarContrasena()
        {
            if (!LibreriaMetodos.StringValido(Contrasena))
            {
                throw new Exception("El campo no puede ser vacio");
            }
        }

        // Sobreescribe lo que se muestra en consola.
        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta += $"Email : {Email} \n";
            respuesta += $"Contrasena : {Contrasena} \n";
            respuesta += $"Tipo de usuario : {Tipo()} \n";
            return respuesta;
        }

        public abstract string Tipo();

        /// <summary>
        /// Convierte el objeto obj a un Usuario.
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y compara el Email del Usuario con el Email del objeto(unU)</returns>
        public override bool Equals(object? obj)
        {
            Usuario? unU = obj as Usuario;
            return unU != null && Email.ToLower() == unU.Email.ToLower();
        }
    }
}
