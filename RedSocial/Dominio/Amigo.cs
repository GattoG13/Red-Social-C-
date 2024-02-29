using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Amigo
    {
        public Miembro EmailAmigo { get; set; }

        //Constructor
        public Amigo(Miembro emailAmigo)
        {
            EmailAmigo = emailAmigo;
            Validar();
        }

        /// <summary>
        /// Valida que el objeto EmailAmigo no sea nulo.
        /// </summary>
        public void Validar()
        {
            if (!LibreriaMetodos.ObjetoValido(EmailAmigo))
            {
                throw new Exception("El miembro es incorrecto");
            }
        }
        /// <summary>
        /// Convierte el objeto obj a un Amigo(unM).
        /// </summary>
        /// <returns>Valida que el objeto no sea nulo y que el Email sea igual al Email del objeto (unM)</returns>
        public override bool Equals(object? obj)
        {
            Amigo? unM = obj as Amigo;
            return unM != null && (EmailAmigo == unM.EmailAmigo);
        }
        
         
    }
}
