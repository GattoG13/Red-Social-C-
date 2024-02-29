using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario
    {
        //Constructor
        public Administrador(string email, string contrasena) : base(email, contrasena)
        {
            base.Validar();
        }

        /// <returns>Devuelve un string "*Es administrador*"</returns>
        public override string Tipo()
        {
            return " * Es administrador *";
        }

        /// <summary>
        /// Convierte el objeto obj a un Administrador(unA).
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y que el Email sea igual al Email del objeto (unA)</returns>
        public override bool Equals(object? obj)
        {
            Administrador? unA = obj as Administrador;
            return unA != null && Email.ToLower() == unA.Email.ToLower();
        }
    }
}
